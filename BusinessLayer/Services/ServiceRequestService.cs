using CommonLayer.Models;
using Dapper;
using System.Data;


namespace BusinessLayer.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IDapper _dapper;
        public ServiceRequestService(IDapper dapper)
        {
            this._dapper = dapper;
        }
        public async Task<int> Delete(int id)
        {
            var result = await Task.FromResult(_dapper.Execute($"Delete [ServiceRequestDB].[dbo].[ServiceRequests] Where Id = {id}", null, commandType: CommandType.Text));
            return result;
        }

        public async Task<DatatableResponse<ServiceRequestModel>> GetAll(DataTableAjaxPostModel request)
        {
            var spName = "sp_ServiceRequestsDatatable2";
            var dbparams = new DynamicParameters();

            var orderCol = request.Order.FirstOrDefault();

            dbparams.Add("Start", request.Start, DbType.Int32);
            dbparams.Add("Length", request.Length, DbType.Int32);
            dbparams.Add("OrderColumn", request.Columns[orderCol.column].name, DbType.String);
            dbparams.Add("OrderDir", orderCol.dir, DbType.String);
            dbparams.Add("SearchVal", request.Search.value, DbType.String);
          //  dbparams.Add("TotalRecords", request.Search.value, DbType.Int32,ParameterDirection.Output);

            var data = await Task.FromResult(_dapper.GetAll<ServiceRequestModel>(spName
              , dbparams,
              commandType: CommandType.StoredProcedure));                    

            return new DatatableResponse<ServiceRequestModel>
            {
                Data = data,
                Draw = request.Draw,
                RecordsFiltered = data.Count(),
                RecordsTotal = data.Count()   //dbparams.Get<int>("TotalRecords")
            };
        }

        public async Task<ServiceRequestModel> GetById(int id)
        {
            var result = await Task.FromResult(_dapper.Get<ServiceRequestModel>
                (
                $"Select * from [ServiceRequestDB].[dbo].[ServiceRequests] where Id = {id}",
                null,
                commandType: CommandType.Text
                ));
            return result;
        }

        public async Task<int> Upsert(ServiceRequestModel parameters)
        {
            var dbparams = GetPerameters(parameters);

            var spName = "[dbo].[SP_Add_ServiceRequest]";
            if (parameters?.Id > 0)
            {
                spName = "[dbo].[SP_Update_ServiceRequest]";
            }
            var result = await Task.FromResult(_dapper.Insert<int>(spName
                , dbparams,
                commandType: CommandType.StoredProcedure));

            return result;
        }

        #region
        private DynamicParameters GetPerameters(ServiceRequestModel parameters)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", parameters.Id, DbType.Int32);
            dbparams.Add("FirstName", parameters.FirstName, DbType.String);
            dbparams.Add("LastName", parameters.LastName, DbType.String);
            dbparams.Add("MobileNumber", parameters.MobileNumber, DbType.String);
            dbparams.Add("Email", parameters.Email, DbType.String);
            dbparams.Add("EnquiryType", parameters.EnquiryType, DbType.Int32);
            dbparams.Add("Comments", parameters.Comments, DbType.String);
            dbparams.Add("BirthDate", parameters.BirthDate, DbType.DateTime);
            return dbparams;
        }
        #endregion
    }
}
