using LinFu.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAdapter
{
    public class AdapterConverter<TInterface> : TypeConverter
        where TInterface : class
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var dyn = new DynamicObject(value);
            if (dyn.LooksLike<TInterface>())
            {
                return dyn.CreateDuck<TInterface>();
            }
            else
            {
                throw new ArgumentException($"Cannot DuckType {value.GetType()} to {typeof(TInterface)}");
            }
        }

        public static TInterface Cast(object value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TInterface));
            return (TInterface)converter.ConvertFrom(value);
        }
    }
}
