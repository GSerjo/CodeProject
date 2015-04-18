using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Samples.Contracts;

namespace Samples
{
    public sealed class PersonTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(PersonCustomTarget);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (PersonCustomSource)value;
            var result = new PersonCustomTarget
            {
                FullName = string.Format("{0} {1}", concreteValue.FirstName, concreteValue.LastName),
                Emails = new List<string>(concreteValue.Emails)
            };
            return result;
        }
    }
}
