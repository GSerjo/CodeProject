using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using Nelibur.ServiceModel.Services.Operations;
using ShipTrackingContracts;

namespace ShipTrackingService
{
    public sealed class ShipProcessor : IPost<AddShipCommand>,
        IGet<ShipLocationQuery>
    {
        private static readonly Dictionary<Guid, Ship> _ships = new Dictionary<Guid, Ship>();

        public object Get(ShipLocationQuery request)
        {
            if (_ships.ContainsKey(request.ShipId))
            {
                Console.WriteLine("Get Ship location: {0}", request);
                return new ShipLocation
                {
                    Location = "Sheldonopolis",
                    ShipId = request.ShipId
                };
            }
            throw new WebFaultException(HttpStatusCode.BadRequest);
        }

        public object Post(AddShipCommand request)
        {
            var ship = new Ship(request.ShipName, Guid.NewGuid());
            _ships[ship.Id] = ship;
            Console.WriteLine("A Ship has added: {0}", ship);

            return new ShipInfo
            {
                Id = ship.Id,
                Name = ship.Name
            };
        }
    }
}
