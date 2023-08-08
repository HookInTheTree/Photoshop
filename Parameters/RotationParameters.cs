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
        [ParameterInfo(Name = "Градус поворота", DefaultValue = 0, MaxValue = 360, MinValue = 0, Increment = 1)]
        public double Angle { get; set; }
    }
}
