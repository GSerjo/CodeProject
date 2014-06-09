using System.Runtime.Serialization;

namespace SantaClausContracts
{
    [DataContract]
    public sealed class Address
    {
        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Recipient { get; set; }

        [DataMember]
        public string StreetAddress { get; set; }

        [DataMember]
        public int ZipCode { get; set; }
    }
}