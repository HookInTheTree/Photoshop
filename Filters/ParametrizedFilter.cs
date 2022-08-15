using MyPhotoshop.Data;
using MyPhotoshop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter<TParameters> :IFilter
        where TParameters:IParameters, new()
    {
        public Photo Process(Photo photo, double[] values)
        {
            var parameters = new TParameters();
            parameters.SetValues(values);
            return Process(photo, parameters);
        }

        public abstract Photo Process(Photo photo, TParameters parameters);

        public ParameterInfo[] GetParameters()
        {
            return new TParameters().GetDescription();
        }


    }
}
