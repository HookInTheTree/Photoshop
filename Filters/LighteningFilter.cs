using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using MyPhotoshop.Interfaces;
using System;

namespace MyPhotoshop
{
    public class LighteningFilter : PixelFilter
    {
        public LighteningFilter() : base(new LighteningParameters()) { }
        public override string ToString()
        {
            return "Осветление/затемнение";
        }

        public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
        {
            return pixel * (parameters as LighteningParameters).Coefficient;
        }
    }
}

