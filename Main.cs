using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using MyPhotoshop.Parameters;
using System;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();

			var lightenigFilter = new PixelFilter<LighteningParameters>("Осветление/затемнение", (pixel, parameters) => pixel * parameters.Coefficient);
			var grayscaleFilter = new PixelFilter<GrayscaleParameters>("Оттенки серого", (pixel, parameters) =>
			{
				var lightness = 0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B;
				return new Pixel(lightness, lightness, lightness);
			});

			window.AddFilter(lightenigFilter);
			window.AddFilter(grayscaleFilter);
			Application.Run (window);
		}
	}
}
