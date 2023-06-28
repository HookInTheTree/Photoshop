using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using MyPhotoshop.Parameters;
using System;
using System.Windows.Forms;
using System.Drawing;
namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();

			var lightenigFilter = new PixelFilter<LighteningParameters>(
				"Осветление/затемнение",
				(pixel, parameters) => pixel * parameters.Coefficient
			);

			var grayscaleFilter = new PixelFilter<EmptyParameters>(
				"Оттенки серого",
				(pixel, parameters) =>
				{
					var lightness = 0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B;
					return new Pixel(lightness, lightness, lightness);
				}
			);

			var reflectionFilter = new TransformFilter(
				"Отразить по горизонтали",
				(size) => size,
				(point, size) => new Point(size.Width - point.X - 1, point.Y)
			);

			var rotationFilter = new TransformFilter(
				"Поворот на 90 градусов против ч.с",
				(size) => new Size(size.Height, size.Width),
				(point, size) => new Point(point.Y, point.X)
			);

			window.AddFilter(lightenigFilter);
			window.AddFilter(grayscaleFilter);
			window.AddFilter(reflectionFilter);
            window.AddFilter(rotationFilter);
            Application.Run(window);
		}
	}
}
