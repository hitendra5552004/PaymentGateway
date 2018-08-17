using PaymentGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class CreditCardPayment
    {
        public int Id { get; set; }
        public int AmountInCents { get; set; }
        public CreditCard CreditCard { get; set; }
        public Acquirer Acquirer { get; set; }

    }
}
