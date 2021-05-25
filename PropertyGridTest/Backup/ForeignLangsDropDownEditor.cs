using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridTest
{
   /// <summary>
   /// ���������� �������� �� ������� ����������� ������ ��� PropertyGrid
   /// </summary>
   public class ForeignLangsDropDownEditor : UITypeEditor 
   {

      /// <summary>
      /// ���������� ������ ��������������
      /// </summary>
      public override Object EditValue(
         ITypeDescriptorContext context, 
         IServiceProvider provider, 
         Object value)
      {
         if( (context != null) && (provider != null) ) 
         {
            // Access the Property Browser's UI display service
            IWindowsFormsEditorService svc =
               (IWindowsFormsEditorService)
               provider.GetService(typeof(IWindowsFormsEditorService));
   
            if( svc!= null ) 
            {
               ForeignLangsControl flctrl = new ForeignLangsControl((ForeignLangs)value);
               //ipTextBox.Text = value.ToString();
               flctrl.Tag = svc;

               svc.DropDownControl(flctrl);

               value = flctrl.Foreignlangs;
            }
         }

         return base.EditValue(context, provider, value);
      }

      /// <summary>
      /// ���������� ����� ��������� - ���������� ����
      /// </summary>
      public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
      {
         if (context != null)
            return UITypeEditorEditStyle.DropDown;
         else
            return base.GetEditStyle(context);
      }

   }
}
