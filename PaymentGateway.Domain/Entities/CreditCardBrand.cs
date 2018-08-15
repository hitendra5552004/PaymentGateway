using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Entities
{
    public class CreditCardBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
