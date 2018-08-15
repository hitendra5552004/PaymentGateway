using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Entities
{
    public class Sale
    {
        public bool AcquirerSuccess { get; set; }
        public string AcquirerRawResponse { get; set; }
    }
}
