using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyGridTest
{
   /// <summary>
   /// Хранит IP адрес
   /// </summary>
   public class IPAddress
   {
      /// <summary>
      /// Конструктор
      /// </summary>
      public IPAddress(string ip)
      {
         _ip = ip;
      }

      private string _ip;

      /// <summary>
      /// Собственно строка с IP адресом
      /// </summary>
      public string IP
      {
         get { return _ip; }
         set { _ip = value; }
      }

      /// <summary>
      /// Представление в виде строки
      /// </summary>
      public override string ToString()
      {
         return _ip;
      }
   }
}
