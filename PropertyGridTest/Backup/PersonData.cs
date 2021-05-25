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
   /// ������ ��� �������������� � PropertyGrid
   /// </summary>
   [TypeConverter(typeof(PropertySorter))]
   class PersonData : FilterablePropertyBase
   {
      /// <summary>
      /// �����������
      /// </summary>
      public PersonData()
      {
         _phones.Add(new PhoneNumber("��������", "111111"));
         _phones.Add(new PhoneNumber("�������", "222222"));
         _phones.Add(new PhoneNumber("���������", "3333333333"));

         _foreignLangs.ForeignLangsList.Add("���������");

         _children.Add("����");
         _children.Add("����");
         _children.Add("����");
      }

      private int _id = 999;

      /// <summary>
      /// �������������
      /// </summary>
      [DisplayName("ID")]
      [Description("�������������")]
      [Category("1. �������������")]
      [ReadOnly(true)]
      public int Id
      {
         get { return _id; }
         set { _id = value; }
      }

      private string _name = "������ ���� ��������";

      /// <summary>
      /// ���
      /// </summary>
      [DisplayName("���")]
      [Description("������� ��� ��������")]
      [Category("1. �������������")]
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      private SEX _sex = SEX.Man;

      /// <summary>
      /// ���
      /// </summary>
      [DisplayName("���")]
      [Description("���")]
      [Category("2. �����")]
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
      /// ���� ��������
      /// </summary>
      [DisplayName("���� ��������")]
      [Description("���� �������� �� ���� �������� � ����")]
      [Category("2. �����")]
      [PropertyOrder(20)]
      public DateTime Birthday
      {
         get { return _birthday; }
         set { _birthday = value; }
      }

      private StringCollection _children = new StringCollection();

      /// <summary>
      /// ���� ��������
      /// </summary>
      [DisplayName("����")]
      [Description("����")]
      [Category("2. �����")]
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

      private AddressData _address = new AddressData("��������", "������", 10);

      /// <summary>
      /// �����
      /// </summary>
      [DisplayName("����� ����������")]
      [Description("�����")]
      [PropertyOrder(30)]
      [Category("3. �������������")]
      public AddressData Address
      {
         get { return _address; }
         set { _address = value; }
      }

      private bool _insurance = true;

      /// <summary>
      /// ������� ���������
      /// </summary>
      [DisplayName("������� ���������")]
      [Description("������� ���������")]
      [PropertyOrder(40)]
      [Category("3. �������������")]
      [TypeConverter(typeof(BooleanTypeConverter))]
      public bool Insurance
      {
         get { return _insurance; }
         set { _insurance = value; }
      }

      private List<PhoneNumber> _phones = new List<PhoneNumber>();

      /// <summary>
      /// ������ ���������
      /// </summary>
      [DisplayName("��������")]
      [Description("������ ������� ���������")]
      [PropertyOrder(50)]
      [Category("3. �������������")]
      [TypeConverter(typeof(CollectionTypeConverter))]
      [Editor(typeof(PhoneNumbersCollectionEditor), typeof(UITypeEditor))]
      public List<PhoneNumber> Phones
      {
         get { return _phones; }
         set { _phones = value; }
      }

      private string _personalFileName = "ivanov.doc";

      /// <summary>
      /// ��� ����� ������� ����
      /// </summary>
      [DisplayName("������ ����")]
      [Description("��� ����� ������� ����")]
      [Category("3. �������������")]
      [PropertyOrder(20)]
      [Editor(typeof(DocFileEditor), typeof(UITypeEditor))]
      [DynamicPropertyFilter("Post", "�������,�������,��������� ������,��������� �������,���������")]
      public string PersonalFileName
      {
         get { return _personalFileName; }
         set { _personalFileName = value; }
      }

      private IPAddress _ipAddress = new IPAddress("192.168.1.1");

      /// <summary>
      /// IP ����� ���������� �������� �����
      /// </summary>
      [DisplayName("IP �����")]
      [Description("IP ����� ���������� �������� �����")]
      [PropertyOrder(70)]
      [Category("3. �������������")]
      [Editor(typeof(IPAddressEditor), typeof(UITypeEditor))]
      public IPAddress IpAddress
      {
         get { return _ipAddress; }
         set { _ipAddress = value; }
      }

      private ForeignLangs _foreignLangs = new ForeignLangs();

      /// <summary>
      /// ������ ������������ ������� �������
      /// </summary>
      [DisplayName("����������� �����")]
      [Description("������ ������������ ������� �������")]
      [PropertyOrder(60)]
      [Category("3. �������������")]
      [Editor(typeof(ForeignLangsDropDownEditor), typeof(UITypeEditor))]
      public ForeignLangs ForeignLangs
      {
         get { return _foreignLangs; }
         set { _foreignLangs = value; }
      }

      private string _post = "��������";

      /// <summary>
      /// ���������
      /// </summary>
      [DisplayName("���������")]
      [Description("���������� ��������� �������� �������� ����������")]
      [Category("3. �������������")]
      [PropertyOrder(10)]
      [TypeConverter(typeof(PostTypeConverter))]
      public string Post
      {
         get { return _post; }
         set { _post = value; }
      }

      private double _dailyAllowance = 3.62;

      // ����� double �� ������ ���������� ��������
      /// <summary>
      /// ��������
      /// </summary>
      [DisplayName("��������")]
      [Description("������ �������� � ��������������, ���/����")]
      [PropertyOrder(45)]
      [TypeConverter(typeof(PossibleValuesTypeConverter))]
      [Category("3. �������������")]
      public double DailyAllowance
      {
         get { return _dailyAllowance; }
         set { _dailyAllowance = value; }
      }
      
      private string _password = "������";

      /// <summary>
      /// ������
      /// </summary>
      [DisplayName("������")]
      [Description("������ ��� ������� �� ������ ��������")]
      [Category("3. �������������")]
      [PropertyOrder(80)]
      [PasswordPropertyText(true)]
      public string Password
      {
         get { return _password; }
         set { _password = value; }
      }
   }
}
