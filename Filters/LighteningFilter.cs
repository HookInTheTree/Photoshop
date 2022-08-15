using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using MyPhotoshop.Interfaces;
using System;

namespace MyPhotoshop
{
    public class LighteningFilter : PixelFilter<LighteningParameters>
    {
        public override string ToString()
        {
            return "Осветление/затемнение";
        }

        public override Pixel ProcessPixel(Pixel pixel, LighteningParameters parameters)
        {
            return pixel * parameters.Coefficient;
        }
    }
}

