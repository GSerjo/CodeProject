using System.Runtime.Serialization;

namespace SantaClausContracts
{
    [DataContract]
    public sealed class PresentRequestQuery
    {
        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Status { get; set; }

        public override string ToString()
        {
            return string.Format("Country: {0}, Status: {1}", Country, Status);
        }
    }
}
