using AutoMapper;
using EnsureThat;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymentGatewaySimulation.Core;
using PaymentGatewaySimulation.Shared;
using System.Collections;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.Repository
{
    public class ChargeVisaCardRepository : IChargeRepository
    {
        private IHttpPostClient _httpClient;
        private IMapper _mapper;
        private string apiUrl = "https://interview.riskxint.com/visa/api/chargeCard";

        public ChargeVisaCardRepository(IMapper mapper, IHttpPostClient httpClient)
        {
            Ensure.That(mapper, nameof(mapper)).IsNotNull();
            _mapper = mapper;

            Ensure.That(httpClient, nameof(httpClient)).IsNotNull();
            _httpClient = httpClient;
        }

        public async Task<JObject> ChargeCard(string identifier, ChargeCardRequest request)
        {
            var model = _mapper.Map<VisaChargeModel>(request);
            var serModel = JsonConvert.SerializeObject(model);
            var headers = new Hashtable();

            headers.Add("identifier", identifier);
            return await _httpClient.PostAsync(headers, apiUrl, serModel);
        }
    }
}