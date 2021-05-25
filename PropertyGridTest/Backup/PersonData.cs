using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using PropertyGridUtils;
using System.Diagnostics;
using System.Collections.Specialized;

namespace PropertyGridTest
{
   /// <summary>
   /// Данные для редактирования в PropertyGrid
   /// </summary>
   [TypeConverter(typeof(PropertySorter))]
   class PersonData : FilterablePropertyBase
   {
      /// <summary>
      /// Конструктор
      /// </summary>
      public PersonData()
      {
         _phones.Add(new PhoneNumber("Домашний", "111111"));
         _phones.Add(new PhoneNumber("Рабочий", "222222"));
         _phones.Add(new PhoneNumber("Мобильный", "3333333333"));

         _foreignLangs.ForeignLangsList.Add("Албанский");

         _children.Add("Таня");
         _children.Add("Ваня");
         _children.Add("Маня");
      }

      private int _id = 999;

      /// <summary>
      /// Идентификатор
      /// </summary>
      [DisplayName("ID")]
      [Description("Идентификатор")]
      [Category("1. Идентификация")]
      [ReadOnly(true)]
      public int Id
      {
         get { return _id; }
         set { _id = value; }
      }

      private string _name = "Иванов Иван Иванович";

      /// <summary>
      /// ФИО
      /// </summary>
      [DisplayName("ФИО")]
      [Description("Фамилия Имя Отчество")]
      [Category("1. Идентификация")]
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      private SEX _sex = SEX.Man;

      /// <summary>
      /// Пол
      /// </summary>
      [DisplayName("Пол")]
      [Description("Пол")]
      [Category("2. Общие")]
      [TypeConverter(typeof(EnumTypeConverter))]
      [Editor(typeof(SexEditor), typeof(UITypeEditor))]
      [PropertyOrder(10)]
      public SEX Sex
      {
         get { return _sex; }
         set { _sex = value; }
      }

      private DateTime _birthday = new DateTime(1950, 2, 23);

      /// <summary>
      /// День рождения
      /// </summary>
      [DisplayName("День рождения")]
      [Description("День рождения он день рождения и есть")]
      [Category("2. Общие")]
      [PropertyOrder(20)]
      public DateTime Birthday
      {
         get { return _birthday; }
         set { _birthday = value; }
      }

      private StringCollection _children = new StringCollection();

      /// <summary>
      /// День рождения
      /// </summary>
      [DisplayName("Дети")]
      [Description("Дети")]
      [Category("2. Общие")]
      [PropertyOrder(30)]
      [Editor(
        "System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor,System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
      )]
      public StringCollection Children
      {
         get { return _children; }
         set { _children = value; }
      }

      private AddressData _address = new AddressData("Бобруйск", "Ленина", 10);

      /// <summary>
      /// Адрес
      /// </summary>
      [DisplayName("Место жительства")]
      [Description("Адрес")]
      [PropertyOrder(30)]
      [Category("3. Дополнительно")]
      public AddressData Address
      {
         get { return _address; }
         set { _address = value; }
      }

      private bool _insurance = true;

      /// <summary>
      /// Наличие страховки
      /// </summary>
      [DisplayName("Наличие страховки")]
      [Description("Наличие страховки")]
      [PropertyOrder(40)]
      [Category("3. Дополнительно")]
      [TypeConverter(typeof(BooleanTypeConverter))]
      public bool Insurance
      {
         get { return _insurance; }
         set { _insurance = value; }
      }

      private List<PhoneNumber> _phones = new List<PhoneNumber>();

      /// <summary>
      /// Список телефонов
      /// </summary>
      [DisplayName("Телефоны")]
      [Description("Список номеров телефонов")]
      [PropertyOrder(50)]
      [Category("3. Дополнительно")]
      [TypeConverter(typeof(CollectionTypeConverter))]
      [Editor(typeof(PhoneNumbersCollectionEditor), typeof(UITypeEditor))]
      public List<PhoneNumber> Phones
      {
         get { return _phones; }
         set { _phones = value; }
      }

      private string _personalFileName = "ivanov.doc";

      /// <summary>
      /// Имя файла личного дела
      /// </summary>
      [DisplayName("Личное дело")]
      [Description("Имя файла личного дела")]
      [Category("3. Дополнительно")]
      [PropertyOrder(20)]
      [Editor(typeof(DocFileEditor), typeof(UITypeEditor))]
      [DynamicPropertyFilter("Post", "Уборщик,Инженер,Начальник отдела,Начальник сектора,Секретарь")]
      public string PersonalFileName
      {
         get { return _personalFileName; }
         set { _personalFileName = value; }
      }

      private IPAddress _ipAddress = new IPAddress("192.168.1.1");

      /// <summary>
      /// IP адрес компьютера рабочего места
      /// </summary>
      [DisplayName("IP адрес")]
      [Description("IP адрес компьютера рабочего места")]
      [PropertyOrder(70)]
      [Category("3. Дополнительно")]
      [Editor(typeof(IPAddressEditor), typeof(UITypeEditor))]
      public IPAddress IpAddress
      {
         get { return _ipAddress; }
         set { _ipAddress = value; }
      }

      private ForeignLangs _foreignLangs = new ForeignLangs();

      /// <summary>
      /// Какими иностранными языками владеет
      /// </summary>
      [DisplayName("Иностранные языки")]
      [Description("Какими иностранными языками владеет")]
      [PropertyOrder(60)]
      [Category("3. Дополнительно")]
      [Editor(typeof(ForeignLangsDropDownEditor), typeof(UITypeEditor))]
      public ForeignLangs ForeignLangs
      {
         get { return _foreignLangs; }
         set { _foreignLangs = value; }
      }

      private string _post = "Директор";

      /// <summary>
      /// Должность
      /// </summary>
      [DisplayName("Должность")]
      [Description("Занимаемая должность согласно штатного расписания")]
      [Category("3. Дополнительно")]
      [PropertyOrder(10)]
      [TypeConverter(typeof(PostTypeConverter))]
      public string Post
      {
         get { return _post; }
         set { _post = value; }
      }

      private double _dailyAllowance = 3.62;

      // выбор double из списка допустимых значений
      /// <summary>
      /// Суточные
      /// </summary>
      [DisplayName("Суточные")]
      [Description("Размер суточных в коммандировках, руб/день")]
      [PropertyOrder(45)]
      [TypeConverter(typeof(PossibleValuesTypeConverter))]
      [Category("3. Дополнительно")]
      public double DailyAllowance
      {
         get { return _dailyAllowance; }
         set { _dailyAllowance = value; }
      }
      
      private string _password = "пароль";

      /// <summary>
      /// Пароль
      /// </summary>
      [DisplayName("Пароль")]
      [Description("Пароль для доступа на сервер компании")]
      [Category("3. Дополнительно")]
      [PropertyOrder(80)]
      [PasswordPropertyText(true)]
      public string Password
      {
         get { return _password; }
         set { _password = value; }
      }
   }
}
