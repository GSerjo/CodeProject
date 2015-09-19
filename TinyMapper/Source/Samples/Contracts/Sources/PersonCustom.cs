using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Samples.Contracts.Sources
{
    [TypeConverter(typeof(PersonTypeConverter))]
    public sealed class PersonCustom
    {
        public IList<string> Emails { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
