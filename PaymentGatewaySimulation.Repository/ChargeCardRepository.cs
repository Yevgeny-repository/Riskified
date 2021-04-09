using EnsureThat;
using Newtonsoft.Json.Linq;
using PaymentGatewaySimulation.Shared;
using System;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.Repository
{
    public class ChargeCardRepository : IChargeCardRepository
    {
        private readonly Func<string, IChargeRepository> _companyRep;

        public ChargeCardRepository(Func<string, IChargeRepository> companyRep)
        {
            Ensure.That(companyRep, nameof(companyRep)).IsNotNull();
            _companyRep = companyRep;
        }

        public async Task<JObject> ChargeCard(string identifier, ChargeCardRequest request)
        {
            string creditCompany = request.CreditCardCompany;
            return await _companyRep(creditCompany).ChargeCard(identifier, request);
        }
    }
}