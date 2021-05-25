using System;

namespace PropertyGridTest
{
    /// <summary>
    /// Атрибут для поддержки динамически показываемых свойств
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    class DynamicPropertyFilterAttribute : Attribute
    {
        string _propertyName;

        /// <summary>
        /// Название свойства, от которого будет зависить видимость  
        /// </summary>
        public string PropertyName
        {
            get { return _propertyName; }
        }

        string _showOn;

        /// <summary>
        /// Значения свойства от которого зависит видимость 
        /// (через запятую, если несколько), при котором свойство, к
        /// которому применен атрибут, будет видимо. 
        /// </summary>
        public string ShowOn
        {
            get { return _showOn; }
        }

        /// <summary>
        /// Конструктор  
        /// </summary>
        /// <param name="propName">Название свойства, от которого будет зависить видимость</param>
        /// <param name="value">Значения свойства, через запятую, если несколько, при котором свойство, к
        /// которому применен атрибут, будет видимо.</param>
        public DynamicPropertyFilterAttribute(string propName, string value)
        {
            _propertyName = propName;
            _showOn = value;
        }
    }

}
