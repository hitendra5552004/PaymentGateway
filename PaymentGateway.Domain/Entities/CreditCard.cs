using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Entities
{
    public class CreditCard
    {
        public string CreditCardNumber { get; set; }
        public CreditCardBrand CreditCardBrand { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int SecurityCode { get; set; }
        public string HolderName { get; set; }
    }
}
