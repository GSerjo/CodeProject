using System;
using System.ServiceModel.Web;
using Nelibur.ServiceModel.Services;
using Nelibur.ServiceModel.Services.Default;
using ShipTrackingContracts;

namespace ShipTrackingService
{
    internal class Program
    {
        private static WebServiceHost _service;

        private static void ConfigureService()
        {
            NeliburRestService.Configure(x =>
            {
                x.Bind<AddShipCommand, ShipProcessor>();
                x.Bind<ShipLocationQuery, ShipProcessor>();
            });
        }

        private static void Main()
        {
            ConfigureService();

            _service = new WebServiceHost(typeof(JsonServicePerCall));
            _service.Open();

            Console.WriteLine("ShipTrackingService is running");
            Console.WriteLine("Press any key to exit\n");

            Console.ReadKey();
            _service.Close();
        }
    }
}
