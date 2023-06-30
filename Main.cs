using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using MyPhotoshop.Parameters;
using System;
using System.Windows.Forms;
using System.Drawing;
using MyPhotoshop.Transformers;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();

			var lightenigFilter = new PixelFilter<LighteningParameters>(
				"����������/����������",
				(pixel, parameters) => pixel * parameters.Coefficient
			);

			var grayscaleFilter = new PixelFilter<EmptyParameters>(
				"������� ������",
				(pixel, parameters) =>
				{
					var lightness = 0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B;
					return new Pixel(lightness, lightness, lightness);
				}
			);

            //var reflectionFilter = new TransformFilter<EmptyParameters>(
            //    "�������� �� �����������",
            //    (size, parameters) => size,
            //    (point, size, parameters) => new Point(size.Width - point.X - 1, point.Y)
            //);

            //var rotationFilter = new TransformFilter<EmptyParameters>(
            //    "������� �� 90 �������� ������ �.�",
            //    (size, parameters) => new Size(size.Height, size.Width),
            //    (point, size, parameters) => new Point(point.Y, point.X)
            //);


            var angleRotationFilter = new TransformFilter<RotationParameters>(
                "��������� �� ��������� ���������� ��������",
                new RotationTransformer()
            );

			window.AddFilter(lightenigFilter);
			window.AddFilter(grayscaleFilter);
            //window.AddFilter(reflectionFilter);
            //window.AddFilter(rotationFilter);
            window.AddFilter(angleRotationFilter);
            Application.Run(window);
		}
	}
}
