using Newtonsoft.Json.Linq;
using PaymentGatewaySimulation.Shared;
using System.Threading.Tasks;

namespace PaymentGatewaySimulation.Repository
{
    /// <summary>
    /// Charge card abstract class
    /// </summary>
    public abstract class ChargeCardAbstractFactory
    {

        #region Members

        #endregion Members

        #region Public Methods

        /// <summary>
        /// Abstract method to charge credit card by request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public abstract Task<JObject> ChargeCard(ChargeCardRequest request);
              
        #endregion Public Methods
    }
}