using BusinessLayer.Services;
using CommonLayer.Models;
using Dapper;

using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : Controller
    {

        //added comment
        private readonly IDapper _dapper;
        private readonly IServiceRequestService _serviceRequestService;
        public ServiceRequestController(IDapper dapper, IServiceRequestService serviceRequestService)
        {
            _dapper = dapper;
            _serviceRequestService = serviceRequestService;
        }
        [HttpPost(nameof(Create))]
        public async Task<int> Create(ServiceRequestModel data)
        {
            return await _serviceRequestService.Upsert(data);

        }
        [HttpPut(nameof(Update))]
        public async Task<int> Update(int id, ServiceRequestModel data)
        {
            return await _serviceRequestService.Upsert(data);
        }

        [HttpGet(nameof(GetById))]
        public async Task<ServiceRequestModel> GetById(int id)
        {
            return await _serviceRequestService.GetById(id);
        }
        [HttpDelete(nameof(Delete))]
        public async Task<int> Delete(int id)
        {
            return await _serviceRequestService.Delete(id);
        }

        [HttpPost]
        [Route("PostdatatableData")]
        public async Task<DatatableResponse<ServiceRequestModel>> PostdatatableData(DataTableAjaxPostModel request)
        {
            return await _serviceRequestService.GetAll(request);
        }


    }
}
