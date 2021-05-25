using System;
using System.Collections;
using System.ComponentModel;

namespace PropertyGridTest.Converters.Sorters
{
    public class PropertySorter : ExpandableObjectConverter
   {
      #region ������
      public override bool GetPropertiesSupported(ITypeDescriptorContext context)
      {
         return true;
      }

      /// <summary>
      /// ���������� ������������� ������ �������
      /// </summary>
      public override PropertyDescriptorCollection GetProperties(
         ITypeDescriptorContext context, object value, Attribute[] attributes)
      {
         PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(value, attributes);
         ArrayList orderedProperties = new ArrayList();
         foreach (PropertyDescriptor pd in pdc)
         {
            Attribute attribute = pd.Attributes[typeof(PropertyOrderAttribute)];
            if (attribute != null)
            {
               // ������� ���� - ���������� ����� �/� �� ����
               PropertyOrderAttribute poa = (PropertyOrderAttribute)attribute;
               orderedProperties.Add(new PropertyOrderPair(pd.Name, poa.Order));
            }
            else
            {
               // �������� ��� - ������� ��� 0
               orderedProperties.Add(new PropertyOrderPair(pd.Name, 0));
            }
         }

         // ��������� �� Order-�
         orderedProperties.Sort();

         // ��������� ������ ���� �������
         ArrayList propertyNames = new ArrayList();
         foreach (PropertyOrderPair pop in orderedProperties)
         {
            propertyNames.Add(pop.Name);
         }

         // ����������
         return pdc.Sort((string[])propertyNames.ToArray(typeof(string)));
      }
      #endregion
   }

}
