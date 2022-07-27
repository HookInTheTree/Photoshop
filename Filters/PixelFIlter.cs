using MyPhotoshop.Data;
using MyPhotoshop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public abstract class PixelFilter : ParametrizedFilter
    {
        public PixelFilter(IParameters parameters) : base(parameters) { }
        public override Photo Process(Photo original, IParameters parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < original.width; x++)
            {
                for (int y = 0; y < original.height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], parameters);
                }
            }
            return result;
        }
        public abstract Pixel ProcessPixel(Pixel pixel, IParameters parameters);

    }
}
