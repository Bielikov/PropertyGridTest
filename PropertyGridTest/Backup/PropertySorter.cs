using System;
using System.Collections;
using System.ComponentModel;
using System.Text;

namespace PropertyGridTest
{
   public class PropertySorter : ExpandableObjectConverter
   {
      #region ??????
      public override bool GetPropertiesSupported(ITypeDescriptorContext context)
      {
         return true;
      }

      /// <summary>
      /// ?????????? ????????????? ?????? ???????
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
               // ??????? ???? - ?????????? ????? ?/? ?? ????
               PropertyOrderAttribute poa = (PropertyOrderAttribute)attribute;
               orderedProperties.Add(new PropertyOrderPair(pd.Name, poa.Order));
            }
            else
            {
               // ???????? ??? - ??????? ??? 0
               orderedProperties.Add(new PropertyOrderPair(pd.Name, 0));
            }
         }

         // ????????? ?? Order-?
         orderedProperties.Sort();

         // ????????? ?????? ???? ???????
         ArrayList propertyNames = new ArrayList();
         foreach (PropertyOrderPair pop in orderedProperties)
         {
            propertyNames.Add(pop.Name);
         }

         // ??????????
         return pdc.Sort((string[])propertyNames.ToArray(typeof(string)));
      }
      #endregion
   }

   #region PropertyOrder Attribute
   /// <summary>
   /// ??????? ??? ??????? ??????????
   /// </summary>
   [AttributeUsage(AttributeTargets.Property)]
   public class PropertyOrderAttribute : Attribute
   {
      private int _order;
      public PropertyOrderAttribute(int order)
      {
         _order = order;
      }

      public int Order
      {
         get { return _order; }
      }
   }
   #endregion

   #region PropertyOrderPair
   /// <summary>
   /// ???? ???/????? ?/? ? ??????????? ?? ??????
   /// </summary>
   public class PropertyOrderPair : IComparable
   {
      private int _order;
      private string _name;
      public string Name
      {
         get { return _name; }
      }

      public PropertyOrderPair(string name, int order)
      {
         _order = order;
         _name = name;
      }

      /// <summary>
      /// ?????????? ????? ?????????
      /// </summary>
      public int CompareTo(object obj)
      {
         int otherOrder = ((PropertyOrderPair)obj)._order;
         if (otherOrder == _order)
         {
            // ???? Order ?????????? - ????????? ?? ??????
            string otherName = ((PropertyOrderPair)obj)._name;
            return string.Compare(_name, otherName);
         }
         else if (otherOrder > _order)
         {
            return -1;
         }
         return 1;
      }
   }
   #endregion
}
