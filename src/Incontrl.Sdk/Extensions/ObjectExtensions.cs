using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace Incontrl.Sdk
{
    internal static class ObjectExtensions
    {
        public static ExpandoObject ToExpandoObject(this object value) {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType())) {
                expando.Add(property.Name, property.GetValue(value));
            }
            return expando as ExpandoObject;
        }
    }
}
