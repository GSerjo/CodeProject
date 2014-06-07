using System;

namespace ShipTrackingContracts
{
    public sealed class ShipLocationQuery
    {
        public Guid ShipId { get; set; }

        public override string ToString()
        {
            return string.Format("ShipId: {0}", ShipId);
        }
    }
}
