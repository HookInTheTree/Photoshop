using MyPhotoshop.Data;
using MyPhotoshop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter:IFilter
    {
        public IParameters parameters;
        public ParametrizedFilter(IParameters paramtrs)
        {
            parameters = paramtrs;
        }

        public Photo Process(Photo photo, double[] values)
        {
            parameters.SetValues(values);
            return Process(photo, parameters);
        }

        public abstract Photo Process(Photo photo, IParameters parameters);

        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDescription();
        }


    }
}
