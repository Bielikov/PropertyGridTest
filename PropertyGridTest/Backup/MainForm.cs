using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using PropertyGridTest.Properties;

namespace PropertyGridTest
{
   /// <summary>
   /// Главное окно приложения
   /// </summary>
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      // редактируемые данные
      private PersonData _personData = new PersonData();

      #region Load/Close
      private void MainForm_Load(object sender, EventArgs e)
      {
         Trace.WriteLine("MainForm_Load()");

         //устанавливаем редактируемый объект
         propertyGrid1.SelectedObject = _personData;

         // восстанавливаем положение окна
         RestorePos();

         // и разделителя колонок в гриде
         RestoreGridSplitterPos();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         Trace.WriteLine("MainForm_FormClosing()");

         // запоминаем положение окна
         SavePos();

         // и разделителя в гриде
         SaveGridSplitterPos();

         // сохраним возможно измененные значения параметров
         Settings.Default.Save();
      }
      #endregion

      #region Сохранение/восстановление положения окна

      // Сохранение положения окна
      private void SavePos()
      {
         Settings.Default.MainFormState = WindowState;
         if (WindowState == FormWindowState.Normal)
         {
            Settings.Default.MainFormSize = Size;
            Settings.Default.MainFormLocation = Location;
         }
         else
         {
            Settings.Default.MainFormSize = RestoreBounds.Size;
            Settings.Default.MainFormLocation = RestoreBounds.Location;
         }

         Trace.WriteLine("MainForm::SavePos(): " + 
            Settings.Default.MainFormSize + ", " +
            Settings.Default.MainFormLocation + ", " +
            Settings.Default.MainFormState );
      }

      // Восстановление положения окна
      private void RestorePos()
      {
         // пока это положение первый раз не сохранено, при 
         // попытке чтения будет кирдык
         try
         {
            Size = Settings.Default.MainFormSize;
            Location = Settings.Default.MainFormLocation;
            WindowState = Settings.Default.MainFormState;
         }
         catch
         {
            Trace.WriteLine("MainForm::RestorePos() exception");
         }

         Trace.WriteLine("MainForm::RestorePos(): " +
            Size + ", " +
            Location + ", " +
            WindowState);
      }

      /// <summary>
      /// Сохранение положения разделителя в гриде
      /// </summary>
      private void SaveGridSplitterPos()
      {
         Type type = propertyGrid1.GetType();
         FieldInfo field = type.GetField("gridView", BindingFlags.NonPublic | BindingFlags.Instance);

         object valGrid = field.GetValue(propertyGrid1);
         Type gridType = valGrid.GetType();
         Settings.Default.GridSplitterPos = (int)gridType.InvokeMember("GetLabelWidth",
                    BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance,
                    null,
                    valGrid, new object[] { });

         Trace.WriteLine("SaveGridSplitterPos(): " + Settings.Default.GridSplitterPos);
      }

      /// <summary>
      /// Восстановление положения разделителя в гриде
      /// </summary>
      private void RestoreGridSplitterPos()
      {
         try
         {
            Type type = propertyGrid1.GetType();
            FieldInfo field = type.GetField("gridView", BindingFlags.NonPublic | BindingFlags.Instance);

            object valGrid = field.GetValue(propertyGrid1);
            Type gridType = valGrid.GetType();
            gridType.InvokeMember("MoveSplitterTo",
               BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance,
               null,
               valGrid, new object[] { Settings.Default.GridSplitterPos });

            Trace.WriteLine("RestoreGridSplitterPos(): " + Settings.Default.GridSplitterPos);
         }
         catch
         {
            Trace.WriteLine("MainForm::RestoreGridSplitterPos() exception");
         }
      }

      #endregion

      private void btnOK_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         propertyGrid1.Refresh();
      }
   }
}