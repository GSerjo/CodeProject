using System;

namespace Samples.Contracts
{
    public sealed class Person
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
    }
}
