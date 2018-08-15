using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Entities
{
    public class AcquirerSale : Sale
    {

        public bool AcquirerSuccess { get; set; }
        public string AcquirerRawResponse { get; set; }
        public List<CreditCardPayment> Payments { get; set; }

        
    }
}
