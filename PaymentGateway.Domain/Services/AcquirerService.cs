using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Services
{

    public abstract class AcquirerService
    {

        public string MerchantKey { get; set; }
        public string Endpoint { get; set; }

        public AcquirerService(string merchantKey, string endpoint)
        {
            MerchantKey = merchantKey;
            Endpoint = endpoint;
        }

    }

}
