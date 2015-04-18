using System;
using System.Collections.Generic;

namespace Samples.Contracts
{
    public sealed class PersonCustomTarget
    {
        public IList<string> Emails { get; set; }
        public string FullName { get; set; }
    }
}
