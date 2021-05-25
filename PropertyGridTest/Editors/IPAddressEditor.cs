using PropertyGridTest.Data;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridTest.Editors
{
    /// <summary>
    /// Модальный редактор IP адреса для PropertyGrid
    /// </summary>
    public class IPAddressEditor : UITypeEditor
    {

        /// <summary>
        /// Реализация метода редактирования
        /// </summary>
        public override Object EditValue(
           ITypeDescriptorContext context,
           IServiceProvider provider,
           Object value)
        {
            if ((context != null) && (provider != null))
            {
                IWindowsFormsEditorService svc =
                   (IWindowsFormsEditorService)
                   provider.GetService(typeof(IWindowsFormsEditorService));

                if (svc != null)
                {
                    using (IPAddressEditorForm ipfrm =
                       new IPAddressEditorForm((IPAddress)value))
                    {
                        if (svc.ShowDialog(ipfrm) == DialogResult.OK)
                        {
                            value = ipfrm.IP;
                        }
                    }
                }
            }

            return base.EditValue(context, provider, value);
        }

        /// <summary>
        /// Возвращаем стиль редактора - модальное окно
        /// </summary>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null)
                return UITypeEditorEditStyle.Modal;
            else
                return base.GetEditStyle(context);
        }

    }
}
