using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class JsonModel
    {
        public JsonModel()
        {

        }
        public JsonModel(object responseData, string message, int statusCode, string appError = "")
        {
            data = responseData;
            Message = message;
            StatusCode = statusCode;
            AppError = appError;
        }
        public string access_token;
        public int expires_in;
        public object UserPermission { get; set; }
        public object AppConfigurations { get; set; }
        public object UserLocations { get; set; }
        public object data { get; set; }
        public object SpareObject { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string AppError { get; set; }
        //  public Meta meta { get; set; }
        public string UserRole { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string PhotoBase64 { get; set; }
        public string EncryptedId { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool CheckFlag { get; set; }
        public string SpareData { get; set; }
        public string Base64printdata { get; set; }
        public bool IsSwitched { get; set; }
        public bool isPaymentForMonthDone { get; set; }
        public string TermsAndConditionsSign { get; set; }
        public bool isNewIp { get; set; }
        public Meta meta { get; set; }
    }
    public class Meta
    {
        public Meta()
        {

        }
        public Meta(dynamic T, dynamic searchFilterModel)
        {
            try
            {
                TotalRecords = T != null && T.Count > 0 ? T[0].TotalRecords : 0;
                CurrentPage = searchFilterModel.pageNumber;
                PageSize = searchFilterModel.pageSize;
                DefaultPageSize = searchFilterModel.pageSize;
                TotalPages = Math.Ceiling(Convert.ToDecimal((T != null && T.Count > 0 ? T[0].TotalRecords : 0) / searchFilterModel.pageSize));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public decimal TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int DefaultPageSize { get; set; }
        public decimal TotalRecords { get; set; }
    }
}
