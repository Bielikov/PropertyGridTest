using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PropertyGridTest
{
   /// <summary>
   /// Данные одного телефонного номера
   /// </summary>
   class PhoneNumber
   {
      public PhoneNumber( string desc, string numb )
      {
         _desc = desc;
         _number = numb;
      }

      public PhoneNumber() : this("еще один", "???")
      {
      }

      private string _desc;

      /// <summary>
      /// Описание
      /// </summary>
      [DisplayName("Описание")]
      [Description("Описание номера телефона")]
      public string Desc
      {
         get { return _desc; }
         set { _desc = value; }
      }

      private string _number;

      /// <summary>
      /// Собственно номер
      /// </summary>
      [DisplayName("Номер")]
      [Description("Номер телефона")]
      public string Number
      {
         get { return _number; }
         set { _number = value; }
      }

      /// <summary>
      /// Представление в виде строки, используется для показа списка вариантов 
      /// при редактировании в PropertyGrid
      /// </summary>
      public override string ToString()
      {
         return _desc;
      }
   }
}
