using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using PropertyGridTest.Properties;

namespace PropertyGridTest
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
