using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int AmmountInCents { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
