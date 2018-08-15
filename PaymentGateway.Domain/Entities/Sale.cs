using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Entities
{
    public class Sale
    {

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Store Store { get; set; }

    }
}