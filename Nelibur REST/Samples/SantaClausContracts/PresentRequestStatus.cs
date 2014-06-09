using System.Runtime.Serialization;

namespace SantaClausContracts
{
    [DataContract]
    public enum PresentRequestStatus
    {
        [EnumMember]
        Pending,

        [EnumMember]
        Accepted,

        [EnumMember]
        Rejected,

        [EnumMember]
        Completed
    }
}
