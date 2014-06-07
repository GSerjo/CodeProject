﻿using System;

namespace ShipTrackingContracts
{
    public sealed class ShipInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }
    }
}
