using System;

namespace PropertyGridTest
{
    /// <summary>
    /// ������� ��� ��������� ����������� ������������ �������
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    class DynamicPropertyFilterAttribute : Attribute
    {
        string _propertyName;

        /// <summary>
        /// �������� ��������, �� �������� ����� �������� ���������  
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
        }

        string _showOn;

        /// <summary>
        /// �������� �������� �� �������� ������� ��������� 
        /// (����� �������, ���� ���������), ��� ������� ��������, �
        /// �������� �������� �������, ����� ������. 
        /// </summary>
        public string ShowOn
        {
            get { return _showOn; }
        }

        /// <summary>
        /// �����������  
        /// </summary>
        /// <param name="propName">�������� ��������, �� �������� ����� �������� ���������</param>
        /// <param name="value">�������� ��������, ����� �������, ���� ���������, ��� ������� ��������, �
        /// �������� �������� �������, ����� ������.</param>
        public DynamicPropertyFilterAttribute(string propName, string value)
        {
            _propertyName = propName;
            _showOn = value;
        }
    }

}
