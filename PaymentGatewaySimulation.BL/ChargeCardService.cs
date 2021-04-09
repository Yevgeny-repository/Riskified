using EnsureThat;
using Newtonsoft.Json.Linq;
using PaymentGatewaySimulation.Repository;
using PaymentGatewaySimulation.Shared;
using Polly;
using Polly.Retry;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.BL
{
    public class ChargeCardService : IChargeCardService
    {
        private IChargeCardRepository _chargeCardRepository;
        private AsyncRetryPolicy _retryPolicy;

        public ChargeCardService(IChargeCardRepository chargeCardRepository)
        {
            Ensure.That(chargeCardRepository, nameof(chargeCardRepository)).IsNotNull();
            _chargeCardRepository = chargeCardRepository;

            _retryPolicy = Policy
             .Handle<Exception>()
             .WaitAndRetryAsync(3, retryAttempt =>
             {
                 var timeToWait = TimeSpan.FromSeconds(Math.Pow(retryAttempt, 2));
                 Console.WriteLine($"Waiting {timeToWait.TotalSeconds} seconds");
                 return timeToWait;
             }
             );
        }

        public async Task<JObject> ChargeCard(string identifier, ChargeCardRequest request)
        {
            return await _retryPolicy.ExecuteAsync(async () => await _chargeCardRepository.ChargeCard(identifier, request));
        }
    }
}