using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridUtils
{
   /// <summary>
   /// ����� ��� ��������� ������� �� ���������� ��� ������ doc ������ 
   /// </summary>
   class DocFileEditor : FileNameEditor
   {
      /// <summary>
      /// ��������� ������� ���������� 
      /// </summary>
      protected override void InitializeDialog(OpenFileDialog ofd)
      {
         ofd.CheckFileExists = false;
         ofd.Filter = "Doc files (*.doc)|*.doc|All files (*.*)|*.*";
      }
   }
}