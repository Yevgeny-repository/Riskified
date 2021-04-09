namespace PaymentGatewaySimulation.Shared
{
    public class MasterCardChargeModel
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Card_Number { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
        public decimal Charge_Amount { get; set; }
    }
}