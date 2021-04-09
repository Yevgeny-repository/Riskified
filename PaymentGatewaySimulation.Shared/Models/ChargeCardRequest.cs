using System.ComponentModel.DataAnnotations;

namespace PaymentGatewaySimulation.Shared
{
    public class ChargeCardRequest
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CreditCardCompany { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string Cvv { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}