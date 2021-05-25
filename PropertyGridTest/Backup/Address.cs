using System.ComponentModel;

namespace PropertyGridTest
{
   /// <summary>
   /// Данные, входящие в адрес
   /// </summary>
   [TypeConverter(typeof(ExpandableObjectConverter))]
   class AddressData
   {
      /// <summary>
      /// Конструктор
      /// </summary>
      public AddressData(string town, string street, uint house) 
      {
         _town = town;
         _street = street;
         _house = house;
      }

      private string _town;

      /// <summary>
      /// Город
      /// </summary>
      [DisplayName("Город")]
      [Description("Наименование населенного пункта")]
      public string Town
      {
         get { return _town; }
         set { _town = value; }
      }

      private string _street;

      /// <summary>
      /// Улица
      /// </summary>
      [DisplayName("Улица")]
      [Description("Название улицы")]
      public string Street
      {
         get { return _street; }
         set { _street = value; }
      }

      private uint _house;

      /// <summary>
      /// Номер дома
      /// </summary>
      [DisplayName("Дом")]
      [Description("Номер дома")]
      public uint House
      {
         get { return _house; }
         set { _house = value; }
      }

      /// <summary>
      /// Представление в виде строки
      /// </summary>
      public override string ToString()
      {
         return _town + ", " + _street + " - " + _house;
      }

   }
}
