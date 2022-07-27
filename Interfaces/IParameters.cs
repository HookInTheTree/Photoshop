using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop.Interfaces
{
    public interface IParameters
    {
        /// <summary>
        /// Метод для будет возвращать информацию о настройках
        /// </summary>
        /// <returns>
        /// ParametersInfo[] - настройки 
        /// </returns>
        ParameterInfo[] GetDescription();

        /// <summary>
        ///  Будет устанавливать поля класса в соответствие с массивом переданных величин
        /// </summary>
        /// <param name="parameters"></param>
        void SetValues(double[] values);
    }
}
