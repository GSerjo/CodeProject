using System;
using System.ServiceModel.Web;

using Nelibur.ServiceModel.Services;
using Nelibur.ServiceModel.Services.Processors;

using SantaClausContracts;

namespace SantaClausService
{
    internal class Program
    {
        private static void Main()
        {
            RestServiceProcessor.Configure(x =>
            {
                x.Bind<PresentRequest, PresentRequestProcessor>();
                x.Bind<PresentRequestQuery, PresentRequestProcessor>();
                x.Bind<UpdatePresentRequestStatus, PresentRequestProcessor>();
                x.Bind<DeletePresentRequestsByStatus, PresentRequestProcessor>();
            });

            using (var serviceHost = new WebServiceHost(typeof(JsonServicePerCall)))
            {
                serviceHost.Open();

                Console.WriteLine("Santa Clause Service has started");
                Console.ReadKey();

                serviceHost.Close();
            }
        }
    }
}
