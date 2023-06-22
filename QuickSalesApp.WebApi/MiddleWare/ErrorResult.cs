using Newtonsoft.Json;

namespace QuickSalesApp.WebApi.MiddleWare
{
    public class ErrorResult :ErrorStatusCode
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



}
