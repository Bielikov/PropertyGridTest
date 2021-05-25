using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyGridTest
{
   /// <summary>
   /// ������ ������ ����������� ������
   /// </summary>
   public class ForeignLangs
   {
      private List<string> _foreignLangsList = new List<string>();

      /// <summary>
      /// ���������� ������
      /// </summary>
      public List<string> ForeignLangsList
      {
         get { return _foreignLangsList; }
         set { _foreignLangsList = value; }
      }

      /// <summary>
      /// ������������� � ���� ������
      /// </summary>
      public override string ToString()
      {
         // ���� ������ ���� ������� ����� ����� ����� � �������
         string langs = "";
         foreach (string s in _foreignLangsList)
         {
            langs += s.Substring(0, 2) + ";";
         }

         return langs;
      }
   }
}
