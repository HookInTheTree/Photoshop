using MyPhotoshop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Parameters
{
    public class RotationParameters : IParameters
    {
        public double Angle { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[] {
                new ParameterInfo {
                    Name = "Градус поворота",
                    DefaultValue = 0,
                    MaxValue = 360,
                    MinValue = 0,
                    Increment = 1
                }
             };
        }

        public void SetValues(double[] values)
        {
            Angle = values[0];
        }
    }
}
