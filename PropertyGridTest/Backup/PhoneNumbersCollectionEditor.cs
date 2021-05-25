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
   /// Свой CollectionEditor для редактирования списка телефонов абонента -
   /// для задания заголовка и запоминания положения окна
   /// </summary>
   class PhoneNumbersCollectionEditor : CollectionEditor
   {
      /// <summary>
      /// Конструктор
      /// </summary>
      public PhoneNumbersCollectionEditor(Type t) : base(t)
      {
         Trace.WriteLine("PhoneNumbersCollectionEditor() ctor");
      }

      /// <summary>
      /// Перекрытый метод создания формы редактора - для сохранения/восстановления
      /// размеров и положения окна
      /// </summary>
      protected override CollectionForm CreateCollectionForm()
      {
         CollectionForm collform = base.CreateCollectionForm();

         // подключаем свой обработчик открытия и в нем 
         // восстанавливаем положение и размер окна
         collform.Load += delegate(object sender, EventArgs e)
         {
            System.Diagnostics.Trace.WriteLine("collform.Load()");
            collform.HelpButton = false;

            #region Восстановление положения окна и смена заголовка
            // пока это положение первый раз не сохранено, при 
            // попытке чтения будет кирдык
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

            collform.Text = "Номера телефонов абонента";
            #endregion

            #region Русификация и кастомизация надписей на форме
            Label BlaBlaProperties = new Label();
            string MembersText = "&Телефоны:";
            string PropertiesText = "&Номера телефонов:";

            // перебираем все контролы на форме и заменяем
            // неправильные надписи
            foreach (Control ctrl in collform.Controls)
            {
               foreach (Control ctrl1 in ctrl.Controls)
               {
                  if (ctrl1.GetType().ToString() ==
                     "System.Windows.Forms.Label" &&
                     ( ctrl1.Text == "&Members:" || ctrl1.Text == "&Члены:" ))
                  {
                     ctrl1.Text = MembersText;
                  }

                  if (ctrl1.GetType().ToString() ==
                     "System.Windows.Forms.Label" &&
                     (ctrl1.Text.Contains("&properties") || ctrl1.Text.Contains("&Cвойства")))
                  {
                     BlaBlaProperties = (Label)ctrl1;
                     BlaBlaProperties.Text = PropertiesText;
                  }

                  if (ctrl1.GetType().ToString() ==
                     "System.ComponentModel.Design.CollectionEditor+FilterListBox")
                  {
                     // это самый правильный обработчик, но после него
                     // срабатывает обработчик формы и меняет надпись на свою
                     //((ListBox)ctrl1).SelectedValueChanged +=
                     //   delegate(object sndr, EventArgs ea)
                     //   {
                     //      Trace.WriteLine("SelectedValueChanged()");
                     //      BlaBlaProperties.Text = PropertiesText ;
                     //   };

                     // вместо одного правильного - два обходных - 
                     // на смену индекса в листвоксе
                     ((ListBox)ctrl1).SelectedIndexChanged +=
                        delegate(object sndr, EventArgs ea)
                        {
                           BlaBlaProperties.Text = PropertiesText;
                        };
                  }

                  if (ctrl1.GetType().ToString() ==
                     "System.Windows.Forms.Design.VsPropertyGrid")
                  {
                     // и на редактирование в PropertyGrid
                     ((PropertyGrid)ctrl1).SelectedGridItemChanged +=
                        delegate(Object sndr, SelectedGridItemChangedEventArgs segichd)
                        {
                           BlaBlaProperties.Text = PropertiesText;
                        };

                     // также сделать доступным окно с подсказками по параметрам в нижней части 
                     ((PropertyGrid)ctrl1).HelpVisible = true;
                     ((PropertyGrid)ctrl1).HelpBackColor = System.Drawing.SystemColors.Info;
                  }

               }
            }
            #endregion
         };

         // подключаем свой обработчик закрытия и в нем сохраняем положение и размер окна
         collform.FormClosing += delegate(Object sender, FormClosingEventArgs e)
         {
            System.Diagnostics.Trace.WriteLine("collform.FormClosing()");

            #region Сохранение положения окна
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
