using MyPhotoshop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public class GrayscaleParameters : IParameters
    {
        public double Coefficient { get; set; }
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[0];
        }

        public void SetValues(double[] values)
        {
        }
    }
}
