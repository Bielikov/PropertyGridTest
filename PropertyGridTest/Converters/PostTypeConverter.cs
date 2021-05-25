using PropertyGridTest.Properties;
using System.ComponentModel;

namespace PropertyGridTest.Converters
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
