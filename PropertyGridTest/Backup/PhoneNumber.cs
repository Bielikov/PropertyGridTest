using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PropertyGridTest
{
   /// <summary>
   /// ������ ������ ����������� ������
   /// </summary>
   class PhoneNumber
   {
      public PhoneNumber( string desc, string numb )
      {
         _desc = desc;
         _number = numb;
      }

      public PhoneNumber() : this("��� ����", "???")
      {
      }

      private string _desc;

      /// <summary>
      /// ��������
      /// </summary>
      [DisplayName("��������")]
      [Description("�������� ������ ��������")]
      public string Desc
      {
         get { return _desc; }
         set { _desc = value; }
      }

      private string _number;

      /// <summary>
      /// ���������� �����
      /// </summary>
      [DisplayName("�����")]
      [Description("����� ��������")]
      public string Number
      {
         get { return _number; }
         set { _number = value; }
      }

      /// <summary>
      /// ������������� � ���� ������, ������������ ��� ������ ������ ��������� 
      /// ��� �������������� � PropertyGrid
      /// </summary>
      public override string ToString()
      {
         return _desc;
      }
   }
}
