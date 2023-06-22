using Newtonsoft.Json;

namespace QuickSalesApp.WebApi.MiddleWare;

public class ValidationErrorDetails :ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
