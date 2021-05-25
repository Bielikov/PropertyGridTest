using PropertyGridTest.Data;
using PropertyGridTest.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace PropertyGridTest.Editors
{
    /// <summary>
    /// Добавляет картинки, соответствующие каждому члену перечисления
    /// </summary>
    public class SexEditor : UITypeEditor
    {
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            // картинки хранятся в ресурсах с именами, соответствующими
            // именам каждого члена перечисления SEX
            string resourcename = ((SEX)e.Value).ToString();

            // достаем картинку из ресурсов
            Bitmap sexImage =
               (Bitmap)Resources.ResourceManager.GetObject(resourcename);
            Rectangle destRect = e.Bounds;
            sexImage.MakeTransparent();

            // и отрисовываем
            e.Graphics.DrawImage(sexImage, destRect);
        }
    }
}
