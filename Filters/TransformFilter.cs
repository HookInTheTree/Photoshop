using MyPhotoshop.Filters.Abstract;
using MyPhotoshop.Interfaces;
using MyPhotoshop.Parameters;
using System;
using System.Drawing;

namespace MyPhotoshop.Filters
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters :IParameters, new()
    {
        private readonly ITransformer<TParameters> Transformer;

        public TransformFilter(
            string name,
            ITransformer<TParameters> transformer) : base(name)
        {
            Transformer = transformer;
        }

        public override Photo Process(Photo photo, TParameters parameters)
        {
            var oldSize = new Size(photo.width, photo.height);
            var newSize = Transformer.TransformSize(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);
            
            for (int x = 0; x < newSize.Width; x++)
            for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = Transformer.TransformPoint(point, oldSize, parameters);
                    if (oldPoint != null)
                        result[x, y] = photo[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }
    }
}
