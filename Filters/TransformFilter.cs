using MyPhotoshop.Filters.Abstract;
using MyPhotoshop.Parameters;
using System;
using System.Drawing;

namespace MyPhotoshop.Filters
{
    public class TransformFilter : ParametrizedFilter<EmptyParameters>
        
    {
        private readonly Func<Size, Size> sizeTransformFunc;
        private readonly Func<Point, Size, Point> pointTransform; 
        public TransformFilter(
            string name,
            Func<Size, Size> sizeProcessor,
            Func<Point, Size, Point> transformProcessor) : base(name)
        {
            sizeTransformFunc = sizeProcessor;
            pointTransform = transformProcessor;
        }

        public override Photo Process(Photo photo, EmptyParameters parameters)
        {
            var oldSize = new Size(photo.width, photo.height);
            var newSize = sizeTransformFunc(oldSize);
            var result = new Photo(newSize.Width, newSize.Height);
            
            for (int x = 0; x < newSize.Width; x++)
            for (int y = 0; y < newSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = pointTransform(point, oldSize);
                    result[x, y] = photo[oldPoint.X, oldPoint.Y];
                }

            return result;
        }
    }
}
