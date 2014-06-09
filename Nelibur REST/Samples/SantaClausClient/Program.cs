using System;
using System.Collections.Generic;
using Nelibur.ServiceModel.Clients;
using SantaClausContracts;

namespace SantaClausClient
{
    internal class Program
    {
        private static void Main()
        {
            var client = new JsonServiceClient("http://localhost:9090/requests");

            var presentRequest = new PresentRequest
                {
                    Id = Guid.NewGuid(),
                    Address = new Address
                        {
                            Country = "sheldonopolis",
                        },
                    Wish = "Could you please help developers to understand, " +
                        "WCF is awesome only with Nelibur"
                };
            client.Post(presentRequest);

            var requestQuery = new PresentRequestQuery
                {
                    Country = "sheldonopolis",
                    Status = PresentRequestStatus.Pending.ToString()
                };
            List<PresentRequest> pendingRequests = client.Get<List<PresentRequest>>(requestQuery);
            Console.WriteLine("Pending present requests count: {0}", pendingRequests.Count);

            var updatePresentRequestStatus = new UpdatePresentRequestStatus
                {
                    Status = PresentRequestStatus.Accepted.ToString()
                };
            client.Post(updatePresentRequestStatus);

            var deleteByStatus = new DeletePresentRequestsByStatus
                {
                    Status = PresentRequestStatus.Accepted.ToString()
                };
            client.Delete(deleteByStatus);

            Console.WriteLine("Press any key for Exit");
            Console.ReadKey();
        }
    }
}
