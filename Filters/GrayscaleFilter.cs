using MyPhotoshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class GrayscaleFilter:IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }

        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < original.width; x++)
            {
                for (int y = 0; y < original.height; y++)
                {
                    var lightness = 0.3 * original[x, y].R + 0.59 * original[x, y].G + 0.11 * original[x, y].B;
                    result[x, y] = new Pixel(lightness, lightness, lightness);
                }
            }
            return result;
        }
    }
}
