using Newtonsoft.Json.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.Core
{
    public interface IHttpPostClient
    {
        Task<JObject> PostAsync(Hashtable headers, string url, string content);
    }
}