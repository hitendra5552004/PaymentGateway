using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public abstract class Payment
    {
        public int Id { get; set; }
        public int AmountInCents { get; set; }
    }
}
