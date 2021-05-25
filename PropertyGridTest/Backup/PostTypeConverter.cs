using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using PropertyGridTest.Properties;

namespace PropertyGridTest
{
   /// <summary>
   /// TypeConverter ��� ������ ����������
   /// </summary>
   class PostTypeConverter : StringConverter
   {
      /// <summary>
      /// ����� ������������� ����� �� ������
      /// </summary>
      public override bool GetStandardValuesSupported(
         ITypeDescriptorContext context )
      {
         return true;
      }

      /// <summary>
      /// ... � ������ �� ������
      /// </summary>
      public override bool GetStandardValuesExclusive(
         ITypeDescriptorContext context )
      {
         // false - ����� ������� �������
         // true - ������ ����� �� ������
         return true;
      }

      /// <summary>
      /// � ��� � ������
      /// </summary>
      public override StandardValuesCollection GetStandardValues(
         ITypeDescriptorContext context )
      {
         // ���������� ������ ����� �� �������� ���������
         // (���� ������, �������� � �.�.)
         return new StandardValuesCollection( Settings.Default.PostList );
      }
   }
}
