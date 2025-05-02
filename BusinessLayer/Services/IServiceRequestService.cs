using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IServiceRequestService
    {
        Task<DatatableResponse<ServiceRequestModel>> GetAll(DataTableAjaxPostModel request);
        Task<ServiceRequestModel> GetById(int id);
        Task<int> Delete(int id);
        Task<int> Upsert(ServiceRequestModel serviceRequestModel);
    }
}
