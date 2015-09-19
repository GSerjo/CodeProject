using System;
using System.Collections.Generic;

namespace Samples.Contracts.Targets
{
    public sealed class PersonTargetCustom
    {
        public IList<string> Emails { get; set; }
        public string FullName { get; set; }
    }
}
