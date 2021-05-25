using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PropertyGridTest
{
   class PossibleValuesTypeConverter : DoubleConverter
   {
      static double[] _valueList = { 3.62, 4.12, 5.10, 10.30 }; 
      /// <summary>
      /// Будем предоставлять выбор из списка
      /// </summary>
      public override bool GetStandardValuesSupported(
         ITypeDescriptorContext context)
      {
         return true;
      }

      /// <summary>
      /// ... и только из списка
      /// </summary>
      public override bool GetStandardValuesExclusive(
         ITypeDescriptorContext context)
      {
         // false - можно вводить вручную
         // true - только выбор из списка
         return true;
      }

      /// <summary>
      /// А вот и список
      /// </summary>
      public override StandardValuesCollection GetStandardValues(
         ITypeDescriptorContext context)
      {
         // возвращаем список допустимых значений
         return new StandardValuesCollection(_valueList);
      }
   }
}
