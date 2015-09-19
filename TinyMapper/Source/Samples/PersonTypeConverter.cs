using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Samples.Contracts;
using Samples.Contracts.Sources;
using Samples.Contracts.Targets;

namespace Samples
{
    public sealed class PersonTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(PersonTargetCustom);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (PersonSourceCustom)value;
            var result = new PersonTargetCustom
            {
                FullName = string.Format("{0} {1}", concreteValue.FirstName, concreteValue.LastName),
                Emails = new List<string>(concreteValue.Emails)
            };
            return result;
        }
    }
}
