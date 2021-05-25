using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Diagnostics;
using PropertyGridTest.Properties;

namespace PropertyGridTest
{
   /// <summary>
   /// ���� CollectionEditor ��� �������������� ������ ��������� �������� -
   /// ��� ������� ��������� � ����������� ��������� ����
   /// </summary>
   class PhoneNumbersCollectionEditor : CollectionEditor
   {
      /// <summary>
      /// �����������
      /// </summary>
      public PhoneNumbersCollectionEditor(Type t) : base(t)
      {
         Trace.WriteLine("PhoneNumbersCollectionEditor() ctor");
      }

      /// <summary>
      /// ���������� ����� �������� ����� ��������� - ��� ����������/��������������
      /// �������� � ��������� ����
      /// </summary>
      protected override CollectionForm CreateCollectionForm()
      {
         CollectionForm collform = base.CreateCollectionForm();

         // ���������� ���� ���������� �������� � � ��� 
         // ��������������� ��������� � ������ ����
         collform.Load += delegate(object sender, EventArgs e)
         {
            System.Diagnostics.Trace.WriteLine("collform.Load()");
            collform.HelpButton = false;

            #region �������������� ��������� ���� � ����� ���������
            // ���� ��� ��������� ������ ��� �� ���������, ��� 
            // ������� ������ ����� ������
            try
            {
               collform.Size = Settings.Default.PhoneNumbersCollectFormSize;
               collform.Location = Settings.Default.PhoneNumbersCollectFormLocation;
               collform.WindowState = Settings.Default.PhoneNumbersCollectFormState;
            }
            catch
            {
               Trace.WriteLine("PhoneNumbersCollectionEditor::CreateCollectionForm() exception");
            }

            collform.Text = "������ ��������� ��������";
            #endregion

            #region ����������� � ������������ �������� �� �����
            Label BlaBlaProperties = new Label();
            string MembersText = "&��������:";
            string PropertiesText = "&������ ���������:";

            // ���������� ��� �������� �� ����� � ��������
            // ������������ �������
            foreach (Control ctrl in collform.Controls)
            {
               foreach (Control ctrl1 in ctrl.Controls)
               {
                  if (ctrl1.GetType().ToString() ==
                     "System.Windows.Forms.Label" &&
                     ( ctrl1.Text == "&Members:" || ctrl1.Text == "&�����:" ))
                  {
                     ctrl1.Text = MembersText;
                  }

                  if (ctrl1.GetType().ToString() ==
                     "System.Windows.Forms.Label" &&
                     (ctrl1.Text.Contains("&properties") || ctrl1.Text.Contains("&C�������")))
                  {
                     BlaBlaProperties = (Label)ctrl1;
                     BlaBlaProperties.Text = PropertiesText;
                  }

                  if (ctrl1.GetType().ToString() ==
                     "System.ComponentModel.Design.CollectionEditor+FilterListBox")
                  {
                     // ��� ����� ���������� ����������, �� ����� ����
                     // ����������� ���������� ����� � ������ ������� �� ����
                     //((ListBox)ctrl1).SelectedValueChanged +=
                     //   delegate(object sndr, EventArgs ea)
                     //   {
                     //      Trace.WriteLine("SelectedValueChanged()");
                     //      BlaBlaProperties.Text = PropertiesText ;
                     //   };

                     // ������ ������ ����������� - ��� �������� - 
                     // �� ����� ������� � ���������
                     ((ListBox)ctrl1).SelectedIndexChanged +=
                        delegate(object sndr, EventArgs ea)
                        {
                           BlaBlaProperties.Text = PropertiesText;
                        };
                  }

                  if (ctrl1.GetType().ToString() ==
                     "System.Windows.Forms.Design.VsPropertyGrid")
                  {
                     // � �� �������������� � PropertyGrid
                     ((PropertyGrid)ctrl1).SelectedGridItemChanged +=
                        delegate(Object sndr, SelectedGridItemChangedEventArgs segichd)
                        {
                           BlaBlaProperties.Text = PropertiesText;
                        };

                     // ����� ������� ��������� ���� � ����������� �� ���������� � ������ ����� 
                     ((PropertyGrid)ctrl1).HelpVisible = true;
                     ((PropertyGrid)ctrl1).HelpBackColor = System.Drawing.SystemColors.Info;
                  }

               }
            }
            #endregion
         };

         // ���������� ���� ���������� �������� � � ��� ��������� ��������� � ������ ����
         collform.FormClosing += delegate(Object sender, FormClosingEventArgs e)
         {
            System.Diagnostics.Trace.WriteLine("collform.FormClosing()");

            #region ���������� ��������� ����
            Settings.Default.PhoneNumbersCollectFormState = collform.WindowState;
            if (collform.WindowState == FormWindowState.Normal)
            {
               Settings.Default.PhoneNumbersCollectFormSize = collform.Size;
               Settings.Default.PhoneNumbersCollectFormLocation = collform.Location;
            }
            else
            {
               Settings.Default.PhoneNumbersCollectFormSize = collform.RestoreBounds.Size;
               Settings.Default.PhoneNumbersCollectFormLocation = collform.RestoreBounds.Location;
            }
            #endregion
         };

         return collform;
      }

   }
}
