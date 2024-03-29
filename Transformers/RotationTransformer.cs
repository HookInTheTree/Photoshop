﻿using MyPhotoshop.Interfaces;
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
        public Size ResultSize { get; private set; }
        public Size OriginalSize { get; private set; }
        public double Angle { get; private set; }

        public Point? TransformPoint(Point point)
        {
            var newSize = ResultSize;
            point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);
            var x = OriginalSize.Width / 2 + (int)(point.X * Math.Cos(Angle) + point.Y * Math.Sin(Angle));
            var y = OriginalSize.Height / 2 + (int)(-point.X * Math.Sin(Angle) + point.Y * Math.Cos(Angle));
            if (x < 0 || x >= OriginalSize.Width || y < 0 || y >= OriginalSize.Height) return null;
            return new Point(x, y);
        }

        public void Prepare(Size size, RotationParameters parameters)
        {
            OriginalSize = size;
            Angle = Math.PI * parameters.Angle / 180;
            ResultSize =  new Size(
                (int)(size.Width * Math.Abs(Math.Cos(Angle)) + size.Height * Math.Abs(Math.Sin(Angle))),
                (int)(size.Height * Math.Abs(Math.Cos(Angle)) + size.Width * Math.Abs(Math.Sin(Angle))));
        }
    }
}
