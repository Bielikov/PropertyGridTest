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
      /// ����� ������������� ����� �� ������
      /// </summary>
      public override bool GetStandardValuesSupported(
         ITypeDescriptorContext context)
      {
         return true;
      }

      /// <summary>
      /// ... � ������ �� ������
      /// </summary>
      public override bool GetStandardValuesExclusive(
         ITypeDescriptorContext context)
      {
         // false - ����� ������� �������
         // true - ������ ����� �� ������
         return true;
      }

      /// <summary>
      /// � ��� � ������
      /// </summary>
      public override StandardValuesCollection GetStandardValues(
         ITypeDescriptorContext context)
      {
         // ���������� ������ ���������� ��������
         return new StandardValuesCollection(_valueList);
      }
   }
}
