using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyGridTest
{
   /// <summary>
   /// ’ранит список иностранных €зыков
   /// </summary>
   public class ForeignLangs
   {
      private List<string> _foreignLangsList = new List<string>();

      /// <summary>
      /// —обственно список
      /// </summary>
      public List<string> ForeignLangsList
      {
         get { return _foreignLangsList; }
         set { _foreignLangsList = value; }
      }

      /// <summary>
      /// ѕредставление в виде строки
      /// </summary>
      public override string ToString()
      {
         // пара первых букв каждого €зыка через точку с зап€той
         string langs = "";
         foreach (string s in _foreignLangsList)
         {
            langs += s.Substring(0, 2) + ";";
         }

         return langs;
      }
   }
}
