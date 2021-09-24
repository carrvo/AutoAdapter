using AutoAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAdapter
{
    /// <summary>
    /// Provides a mechanism for automatically applying
    /// the ADAPTER PATTERN without custom code.
    /// </summary>
    /// <typeparam name="TInterface">
    /// The interface that will be implemented (ducktyped) by a given object.
    /// </typeparam>
    public class Adapt<TInterface> : TypeConverter
        where TInterface : class
    {
        /// <summary>
        /// Catch the <see cref="ArgumentException"/>
        /// from <see cref="ConvertFrom(ITypeDescriptorContext, CultureInfo, Object)"/>
        /// instead of using this method to determine whether it can convert.
        /// </summary>
        /// <returns>
        /// <see cref="true"/>, always.
        /// </returns>
        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }

        /// <summary>
        /// Applying the ADAPTER PATTERN against <typeparamref name="TInterface"/>.
        /// </summary>
        public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
        {
            return AutoAdapter.AdapterExtensionMethods.CreateAdapter<TInterface>(value);
            //return value.CreateAdapter<TInterface>();
        }

        /// <summary>
        /// Applying the ADAPTER PATTERN against <typeparamref name="TInterface"/>.
        /// </summary>
        public static TInterface From(Object value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TInterface));
            return (TInterface)converter.ConvertFrom(value);
        }
    }

    /// <summary>
    /// Provides a mechanism for automatically applying
    /// the ADAPTER PATTERN without custom code.
    /// </summary>
    public class Adapt
    {
        private readonly Object _value;

        /// <summary>
        /// Creates a FLUENT object that holds the mechanism for automatically
        /// applying the ADAPTER PATTERN without custom code.
        /// </summary>
        /// <param name="value">
        /// The object to apply the ADAPTER PATTERN for.
        /// </param>
        public Adapt(Object value)
        {
            _value = value;
        }

        /// <summary>
        /// Creates a FLUENT object that holds the mechanism for automatically
        /// applying the ADAPTER PATTERN without custom code.
        /// </summary>
        /// <param name="value">
        /// The object to apply the ADAPTER PATTERN for.
        /// </param>
        public static Adapt For(Object value)
        {
            return new Adapt(value);
        }

        /// <summary>
        /// Applying the ADAPTER PATTERN against <typeparamref name="TInterface"/>.
        /// </summary>
        /// <typeparam name="TInterface">
        /// The interface that will be implemented (ducktyped) by a given object.
        /// </typeparam>
        /// <returns>
        /// The object adapted for <typeparamref name="TInterface"/>.
        /// </returns>
        public TInterface To<TInterface>()
            where TInterface : class
        {
            return Adapt<TInterface>.From(_value);
        }
    }
}
