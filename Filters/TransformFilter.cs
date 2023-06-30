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
        private readonly Func<Size, TParameters, Size> sizeTransformFunc;
        private readonly Func<Point, Size, TParameters, Point?> pointTransform; 
        public TransformFilter(
            string name,
            Func<Size, TParameters, Size> sizeProcessor,
            Func<Point, Size, TParameters, Point?> transformProcessor) : base(name)
        {
            sizeTransformFunc = sizeProcessor;
            pointTransform = transformProcessor;
        }

        public override Photo Process(Photo photo, TParameters parameters)
        {
            var oldSize = new Size(photo.width, photo.height);
            var newSize = sizeTransformFunc(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);
            
            for (int x = 0; x < newSize.Width; x++)
            for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize, parameters);
                    if (oldPoint != null)
                        result[x, y] = photo[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }
    }
}
