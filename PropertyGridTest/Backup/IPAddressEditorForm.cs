using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PropertyGridTest
{
   /// <summary>
   /// ����� ��� �������������� ip-������
   /// </summary>
   public partial class IPAddressEditorForm : Form
   {
      public IPAddressEditorForm(IPAddress ip)
      {
         InitializeComponent();

         IP = ip;
      }

      /// <summary>
      /// �������������� ������������� ip � MaskedTextBox
      /// � � ���������� ����
      /// </summary>
      public IPAddress IP
      {
         // MaskedTextBox �������� �������� ����� ip ��������� �� 3-� ������
         // ��� ������� ����� �������
         get { return new IPAddress(IPmaskedTextBox.Text.Replace(" ", "")); }

         // � ����� �������� - ���� ��������� ���������
         set 
         {
            // ���� ����� IP ������ 3 ������, MaskedTextBox �� �������� :(
            // ���� �� ��� ������������� ���������� ���������
            // ���� ����� � �����
            Regex r = new Regex(@"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$");
            Match m = r.Match(value.IP);
            string ip4maskedit = "";
            bool firstgroup = true;
            foreach( Group g in m.Groups )
            {
               if (firstgroup)
               {
                  firstgroup = false;
                  continue;
               }

               string s = g.ToString();
               while (s.Length < 3)
                  s += " ";

               ip4maskedit += s;
            }

            IPmaskedTextBox.Text = ip4maskedit; 
         }
      }
   }
}