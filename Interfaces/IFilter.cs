using MyPhotoshop.Parameters;

namespace MyPhotoshop.Interfaces
{

	
	public interface IFilter
	{
        /// <summary>
        /// ���� ����� ������ ���������� �������� ����������, ������� ���������� � NumericUpDown-��������
        /// ����� �� �������� ������ �������
        /// </summary>
        /// <returns></returns>
  	    ParameterInfo[] GetParameters();
        /// <summary>
        /// ���� ����� ��������� ����������, ������� ���� ������������, � ��������� �������� ���� ����������
        /// ����� ������� parameters � �������� ����� ����� �������, ������������� ������� GetParameters
        /// </summary>
        /// <param name="original"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
		Photo Process(Photo original, double[] parameters);
	}
}

