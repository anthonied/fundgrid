using log4net;
using Moolah;
using Moolah.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundGrid.Repository
{
    public class PaymentRepository
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PayPalConfiguration configuration
        {
            get
            {
                var configuration = new PayPalConfiguration
                                    (
                                        PaymentEnvironment.Test,
                                        "phillipk-facilitator_api1.solutionserver.co.za",
                                        "1381410599",
                                        "AFcWxV21C7fd0v3bYYYRCpSSRl31AL5rnfg2diW42wsppieMMGfCdXFg"
                                    );
                return configuration;
            }
        }
        private PayPalExpressCheckout Gateway
        {
            get
            {
                return new PayPalExpressCheckout(configuration);
            }
        }
        public string CancelUrl { get; set; }
        public string ConfirmationUrl { get; set; }
        public string PayUsingPaypal(decimal amount)
        {
            var response = Gateway.SetExpressCheckout(amount, CurrencyCodeType.USD, CancelUrl, ConfirmationUrl);
            if(response.Status == PaymentStatus.Failed)
                _log.Error(String.Format("Payment of amount '{0}' failed", amount));
            return response.RedirectUrl;
        }
    }
}
