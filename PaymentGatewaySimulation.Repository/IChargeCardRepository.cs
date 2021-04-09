using Newtonsoft.Json.Linq;
using PaymentGatewaySimulation.Shared;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.Repository
{
    public interface IChargeCardRepository
    {
        Task<JObject> ChargeCard(string identifier, ChargeCardRequest request);
    }
}