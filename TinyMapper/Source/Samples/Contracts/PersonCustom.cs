using System;
using System.ComponentModel;

namespace Samples.Contracts
{
    [TypeConverter(typeof(PersonTypeConverter))]
    public sealed class PersonCustom
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
