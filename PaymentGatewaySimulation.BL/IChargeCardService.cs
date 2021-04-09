using Newtonsoft.Json.Linq;
using PaymentGatewaySimulation.Shared;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.BL
{
    public interface IChargeCardService
    {
        Task<JObject> ChargeCard(string identifier, ChargeCardRequest request);
    }
}