using System.ComponentModel;

namespace PropertyGridTest
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