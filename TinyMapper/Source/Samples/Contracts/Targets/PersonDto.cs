using System;

namespace Samples.Contracts.Targets
{
    public sealed class PersonDto
    {
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
    }
}
