using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using PropertyGridTest.Properties;

namespace PropertyGridTest
{
   /// <summary>
   /// TypeConverter для списка должностей
   /// </summary>
   class PostTypeConverter : StringConverter
   {
      /// <summary>
      /// Будем предоставлять выбор из списка
      /// </summary>
      public override bool GetStandardValuesSupported(
         ITypeDescriptorContext context )
      {
         return true;
      }

      /// <summary>
      /// ... и только из списка
      /// </summary>
      public override bool GetStandardValuesExclusive(
         ITypeDescriptorContext context )
      {
         // false - можно вводить вручную
         // true - только выбор из списка
         return true;
      }

      /// <summary>
      /// А вот и список
      /// </summary>
      public override StandardValuesCollection GetStandardValues(
         ITypeDescriptorContext context )
      {
         // возвращаем список строк из настроек программы
         // (базы данных, интернет и т.д.)
         return new StandardValuesCollection( Settings.Default.PostList );
      }
   }
}
