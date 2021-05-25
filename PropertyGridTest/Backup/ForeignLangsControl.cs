using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridTest
{
   /// <summary>
   /// Control ��� ������� ����������� ������
   /// </summary>
   public partial class ForeignLangsControl : UserControl
   {
      /// <summary>
      /// �����������
      /// </summary>
      /// <param name="fl">������ ������ ��� ����������� �������</param>
      public ForeignLangsControl(ForeignLangs fl)
      {
         InitializeComponent();

         _foreignLangs = fl;

         foreach( string lang in fl.ForeignLangsList )
         {
            CheckLanguage(lang);
         }
      }

      // �������� ���� � CheckedListBox
      private void CheckLanguage( string lang )
      {
          int i = 0;
          foreach( object it in checkedListBox1.Items )
          {
             if (lang == it.ToString())
             {
                checkedListBox1.SetItemChecked(i, true);
                return;
             }
             i++;
          }
      }

      // ������� ������ ��������� ������
      private ForeignLangs _foreignLangs;

      /// <summary>
      /// ������� ������ ��������� ������
      /// </summary>
      public ForeignLangs Foreignlangs
      {
         get 
         {
            // ��������������� ������ �������� ���������� ������
            _foreignLangs.ForeignLangsList.Clear();
            foreach (object it in checkedListBox1.CheckedItems)
            {
               _foreignLangs.ForeignLangsList.Add(it.ToString());
            }
            return _foreignLangs; 
         }
         set { _foreignLangs = value; }
      }

      // ��������� ��������������
      private void btnOK_Click(object sender, EventArgs e)
      {
         ((IWindowsFormsEditorService)Tag).CloseDropDown();
      }
   }
}
