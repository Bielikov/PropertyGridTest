using PropertyGridTest.Data;
using PropertyGridTest.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace PropertyGridTest.Editors
{
    /// <summary>
    /// ��������� ��������, ��������������� ������� ����� ������������
    /// </summary>
    public class SexEditor : UITypeEditor
    {
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            // �������� �������� � �������� � �������, ����������������
            // ������ ������� ����� ������������ SEX
            string resourcename = ((SEX)e.Value).ToString();

            // ������� �������� �� ��������
            Bitmap sexImage =
               (Bitmap)Resources.ResourceManager.GetObject(resourcename);
            Rectangle destRect = e.Bounds;
            sexImage.MakeTransparent();

            // � ������������
            e.Graphics.DrawImage(sexImage, destRect);
        }
    }
}
