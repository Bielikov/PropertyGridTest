using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyGridTest
{
   /// <summary>
   /// ������ IP �����
   /// </summary>
   public class IPAddress
   {
      /// <summary>
      /// �����������
      /// </summary>
      public IPAddress(string ip)
      {
         _ip = ip;
      }

      private string _ip;

      /// <summary>
      /// ���������� ������ � IP �������
      /// </summary>
      public string IP
      {
         get { return _ip; }
         set { _ip = value; }
      }

      /// <summary>
      /// ������������� � ���� ������
      /// </summary>
      public override string ToString()
      {
         return _ip;
      }
   }
}
