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
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        private readonly Func<Size, Size> sizeTransformer;
        private readonly Func<Point, Size, Point?> pointTransformer;
        public Size OriginalSize { get; private set; }

        public Size ResultSize { get; private set; }

        public FreeTransformer(
            Func<Size, Size> sizeTransformer,
            Func<Point, Size, Point?> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        public void Prepare(Size size, EmptyParameters parameters)
        {
            OriginalSize = size;
            ResultSize = sizeTransformer(size);
        }

        public Point? TransformPoint(Point point)
        {
            return pointTransformer(point, OriginalSize);
        }
    }
}
