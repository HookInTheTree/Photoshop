using MyPhotoshop.Data;
using MyPhotoshop.Filters.Abstract;
using MyPhotoshop.Interfaces;
using System;


namespace MyPhotoshop.Filters
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParameters, new()
    {
        private readonly Func<Pixel, TParameters, Pixel> processor;

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> pixelProcessor):base(name)
        {
            this.processor = pixelProcessor;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < original.width; x++)
            {
                for (int y = 0; y < original.height; y++)
                {
                    result[x, y] = processor(original[x, y], parameters);
                }
            }
            return result;
        }

    }
}
