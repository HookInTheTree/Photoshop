using MyPhotoshop.Interfaces;
using System.Linq;
using System.Reflection;

namespace MyPhotoshop.Parameters
{
    public static class Extensions
    {
        public static ParameterInfo[] GetDescription(this IParameters parameters)
        {
            return parameters
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttribute<ParameterInfo>() != null)
                .Select(x => x.GetCustomAttribute<ParameterInfo>())
                .ToArray();
        }

        public static void SetValues(this IParameters parameters, double[] values)
        {
            var properties = parameters?.GetType()
                                        .GetProperties()
                                        .Where(p => p.GetCustomAttribute<ParameterInfo>() != null)
                                        .ToArray();

            for (var i = 0; i < values?.Length; i++)
                properties[i].SetValue(parameters, values[i]);
        }
    }
}
