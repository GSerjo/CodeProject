using System;
using System.Collections.Generic;
using System.Linq;
using Nelibur.ServiceModel.Services.Operations;
using SantaClausContracts;

namespace SantaClausService
{
    public sealed class PresentRequestProcessor : IPost<PresentRequest>,
        IPost<UpdatePresentRequestStatus>,
        IGetWithResponse<PresentRequestQuery>,
        IDelete<DeletePresentRequestsByStatus>
    {
        private static List<PresentRequest> _requests = new List<PresentRequest>();

        public void Delete(DeletePresentRequestsByStatus request)
        {
            var status = (PresentRequestStatus)Enum.Parse(typeof(PresentRequestStatus), request.Status);
            _requests = _requests.Where(x => x.Status != status).ToList();
            Console.WriteLine("Request list was updated, current count: {0}", _requests.Count);
        }

        public object GetWithResponse(PresentRequestQuery request)
        {
            Console.WriteLine("Get Present Requests by: {0}", request);
            var status = (PresentRequestStatus)Enum.Parse(typeof(PresentRequestStatus), request.Status);
            return _requests.Where(x => x.Status == status)
                            .Where(x => x.Address.Country == request.Country)
                            .ToList();
        }

        public void Post(PresentRequest request)
        {
            request.Status = PresentRequestStatus.Pending;
            _requests.Add(request);
            Console.WriteLine("Request was added, Id: {0}", request.Id);
        }

        public void Post(UpdatePresentRequestStatus request)
        {
            Console.WriteLine("Update requests on status: {0}", request.Status);
            var status = (PresentRequestStatus)Enum.Parse(typeof(PresentRequestStatus), request.Status);
            _requests.ForEach(x => x.Status = status);
        }
    }
}
