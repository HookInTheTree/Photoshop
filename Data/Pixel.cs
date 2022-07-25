using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Data
{
    public struct Pixel
    {
        private double _r;
        public double R
        {
            get { return _r; }
            set
            {
                _r = CheckValue(value);
            }
        }
        private double _g;
        public double G
        {
            get { return _g; }
            set
            {
                _g = CheckValue(value);
            }
        }
        private double _b;
        public double B
        {
            get { return _b; }
            set
            {
                _b = CheckValue(value);
            }
        }

        public Pixel(double _R, double _G, double _B)
        {
            _r = _g = _b = 0;
            R = _R;
            G = _G;
            B = _B;
        }

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            else if (value > 1) return 1;
            else return value;
        }
        private double CheckValue(double value)
        {
            if (value > 1 || value < 0)
            {
                throw new Exception(string.Format("Wrong channel value {0} (the value must be between 0 and 1", value));
            }
            return value;
        }

        public static Pixel operator * (Pixel pixel, double num)
        {
            return new Pixel(
                   Trim(pixel.R * num),
                   Trim(pixel.G * num),
                   Trim(pixel.B * num)
                );
        }

        public static Pixel operator * (double num, Pixel pixel)
        {
            return pixel * num;
        }

    }
}
