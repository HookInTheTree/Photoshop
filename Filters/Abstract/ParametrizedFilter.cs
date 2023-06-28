using MyPhotoshop.Interfaces;
using MyPhotoshop.Parameters;

namespace MyPhotoshop.Filters.Abstract
{
    public abstract class ParametrizedFilter<TParameters> :IFilter
        where TParameters:IParameters, new()
    {
        private readonly string name;
        public ParametrizedFilter(string name)
        {
            this.name = name;
        }

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

        public override string ToString()
        {
            return name;
        }

    }
}
