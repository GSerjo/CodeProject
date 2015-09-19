using System;
using System.Collections.Generic;

namespace Samples.Contracts.Targets
{
    public sealed class PersonDtoComplex
    {
        public Address Address { get; set; }
        public DateTime CreateTime { get; set; }
        public IList<string> Emails { get; set; }
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Surname { get; set; }
    }
}
