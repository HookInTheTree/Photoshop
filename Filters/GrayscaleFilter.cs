﻿using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class GrayscaleFilter:PixelFilter
    {
        public override ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }

        public override Pixel ProcessPixel(Pixel pixel, double[] parametes)
        {
            var lightness = 0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B;
            return new Pixel(lightness, lightness, lightness);
        }
    }
}
