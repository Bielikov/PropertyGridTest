using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridUtils
{
   /// <summary>
   /// Класс для установки фильтра по расширению при выборе doc файлов 
   /// </summary>
   class DocFileEditor : FileNameEditor
   {
      /// <summary>
      /// Настройка фильтра расширений 
      /// </summary>
      protected override void InitializeDialog(OpenFileDialog ofd)
      {
         ofd.CheckFileExists = false;
         ofd.Filter = "Doc files (*.doc)|*.doc|All files (*.*)|*.*";
      }
   }
}