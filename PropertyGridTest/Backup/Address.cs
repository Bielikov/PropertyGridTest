using System.ComponentModel;

namespace PropertyGridTest
{
   /// <summary>
   /// ������, �������� � �����
   /// </summary>
   [TypeConverter(typeof(ExpandableObjectConverter))]
   class AddressData
   {
      /// <summary>
      /// �����������
      /// </summary>
      public AddressData(string town, string street, uint house) 
      {
         _town = town;
         _street = street;
         _house = house;
      }

      private string _town;

      /// <summary>
      /// �����
      /// </summary>
      [DisplayName("�����")]
      [Description("������������ ����������� ������")]
      public string Town
      {
         get { return _town; }
         set { _town = value; }
      }

      private string _street;

      /// <summary>
      /// �����
      /// </summary>
      [DisplayName("�����")]
      [Description("�������� �����")]
      public string Street
      {
         get { return _street; }
         set { _street = value; }
      }

      private uint _house;

      /// <summary>
      /// ����� ����
      /// </summary>
      [DisplayName("���")]
      [Description("����� ����")]
      public uint House
      {
         get { return _house; }
         set { _house = value; }
      }

      /// <summary>
      /// ������������� � ���� ������
      /// </summary>
      public override string ToString()
      {
         return _town + ", " + _street + " - " + _house;
      }

   }
}
