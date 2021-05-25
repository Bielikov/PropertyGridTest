using System.ComponentModel;

namespace PropertyGridTest.Data
{
   enum SEX
   {
      [Description("Муж.")]
      Man,
      [Description("Жен.")]
      Woman,
      [Description("Неизв.")]
      Unknown
   }
}