using System;

namespace ShipTrackingService
{
    public sealed class Ship
    {
        public Ship(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }
    }
}
