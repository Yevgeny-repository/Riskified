namespace PaymentGatewaySimulation.Shared
{
    public class VisaChargeModel
    {
        public string FullName { get; set; }
        public string Number { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
        public decimal TotalAmount { get; set; }
    }
}