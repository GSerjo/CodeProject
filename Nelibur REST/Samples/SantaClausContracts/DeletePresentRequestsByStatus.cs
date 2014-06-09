using System.Runtime.Serialization;

namespace SantaClausContracts
{
    [DataContract]
    public sealed class DeletePresentRequestsByStatus
    {
        [DataMember]
        public string Status { get; set; }
    }
}
