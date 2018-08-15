using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGatewayDomain.Entities
{
    public class CreditCardPayment : Payment
    {

        public CreditCard CreditCard { get; set; }
        public Acquirer Acquirer { get; set; }

    }
}
