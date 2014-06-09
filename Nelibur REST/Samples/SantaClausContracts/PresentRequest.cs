using System;
using System.Runtime.Serialization;

namespace SantaClausContracts
{
    [DataContract]
    public sealed class PresentRequest
    {
        [DataMember]
        public Address Address { get; set; }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public PresentRequestStatus Status { get; set; }

        [DataMember]
        public string Wish { get; set; }
    }
}