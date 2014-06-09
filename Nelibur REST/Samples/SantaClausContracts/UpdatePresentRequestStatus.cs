using System.Runtime.Serialization;

namespace SantaClausContracts
{
    [DataContract]
    public sealed class UpdatePresentRequestStatus
    {
        [DataMember]
        public string Status { get; set; }
    }
}