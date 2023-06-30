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

            var reflectionFilter = new TransformFilter<EmptyParameters>(
                "Отразить по горизонтали",
                (size, parameters) => size,
                (point, size, parameters) => new Point(size.Width - point.X - 1, point.Y)
            );

            var rotationFilter = new TransformFilter<EmptyParameters>(
                "Поворот на 90 градусов против ч.с",
                (size, parameters) => new Size(size.Height, size.Width),
                (point, size, parameters) => new Point(point.Y, point.X)
            );

            Func<Size, RotationParameters, Size> sizeRotator = (size, parameters) =>
            {
                var angle = Math.PI * parameters.Angle / 180;
                return new Size(
                    (int)(size.Width * Math.Abs(Math.Cos(angle)) + size.Height * Math.Abs(Math.Sin(angle))),
                    (int)(size.Height * Math.Abs(Math.Cos(angle)) + size.Width * Math.Abs(Math.Sin(angle))));
            };

            Func<Point, Size, RotationParameters, Point?> pointRotator = (point, oldSize, parameters) =>
            {
                var newSize = sizeRotator(oldSize, parameters);
                var angle = Math.PI * parameters.Angle / 180;
                point = new Point(point.X - newSize.Width / 2, point.Y - newSize.Height / 2);
                var x = oldSize.Width / 2 + (int)(point.X * Math.Cos(angle) + point.Y * Math.Sin(angle));
                var y = oldSize.Height / 2 + (int)(-point.X * Math.Sin(angle) + point.Y * Math.Cos(angle));
                if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height) return null;
                return new Point(x, y);
            };

            var angleRotationFilter = new TransformFilter<RotationParameters>(
                "Повернуть на указанное количество градусов",
                sizeRotator,
                pointRotator
            );

			window.AddFilter(lightenigFilter);
			window.AddFilter(grayscaleFilter);
            window.AddFilter(reflectionFilter);
            window.AddFilter(rotationFilter);
            window.AddFilter(angleRotationFilter);
            Application.Run(window);
		}
	}
}
