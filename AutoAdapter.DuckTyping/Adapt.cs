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
    public class Adapt<TInterface> : TypeConverter
        where TInterface : class
    {
        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
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

        public static TInterface From(object value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TInterface));
            return (TInterface)converter.ConvertFrom(value);
        }
    }

    public class Adapt
    {
        private readonly Object _value;

        public Adapt(Object value)
        {
            _value = value;
        }

        public static Adapt For(Object value)
        {
            return new Adapt(value);
        }

        public TInterface To<TInterface>()
            where TInterface : class
        {
            return Adapt<TInterface>.From(_value);
        }
    }
}
