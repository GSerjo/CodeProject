using System;
using System.Collections.Generic;

namespace Samples.Contracts.Sources
{
    public sealed class PersonComplex
    {
        public Address Address { get; set; }
        public DateTime CreateTime { get; set; }
        public IReadOnlyList<string> Emails { get; set; }
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
    }
}
