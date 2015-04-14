using System;
using System.ComponentModel;
using System.Globalization;
using Samples.Contracts;

namespace Samples
{
    public sealed class PersonTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(PersonDtoCustom);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (PersonCustom)value;
            var result = new PersonDtoCustom
            {
                FullName = string.Format("{0} {1}", concreteValue.FirstName, concreteValue.LastName)
            };
            return result;
        }
    }
}
