using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Samples.Contracts
{
    [TypeConverter(typeof(PersonTypeConverter))]
    public sealed class PersonCustomSource
    {
        public IList<string> Emails { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
