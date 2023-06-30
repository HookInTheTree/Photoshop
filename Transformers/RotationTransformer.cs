using MyPhotoshop.Interfaces;
using MyPhotoshop.Parameters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Transformers
{
    public class RotationTransformer : ITransformer<RotationParameters>
    {
        public Point? TransformPoint(Point point, Size size, RotationParameters parameters)
        {
            var newSize = TransformSize(size, parameters);
            var angle = Math.PI * parameters.Angle / 180;
            point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);
            var x = size.Width / 2 + (int)(point.X * Math.Cos(angle) + point.Y * Math.Sin(angle));
            var y = size.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));
            if (x < 0 || x >= size.Width || y < 0 || y >= size.Height) return null;
            return new Point(x, y);
        }

        public Size TransformSize(Size size, RotationParameters parameters)
        {
            var angle = Math.PI * parameters.Angle / 180;
            return new Size(
                (int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
                (int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle))));
        }
    }
}
