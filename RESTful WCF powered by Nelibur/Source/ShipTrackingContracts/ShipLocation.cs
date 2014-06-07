using System;

namespace ShipTrackingContracts
{
    public sealed class ShipLocation
    {
        public string Location { get; set; }

        public Guid ShipId { get; set; }

        public override string ToString()
        {
            return string.Format("Location: {0}, ShipId: {1}", Location, ShipId);
        }
    }
}
