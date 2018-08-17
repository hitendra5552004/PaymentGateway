using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class StoreAcquirer
    {
        public int Id { get; set; }
        public Store Store { get; set; }
        public int? IdStore { get; set; }
        public Acquirer Acquirer { get; set; }
        public int? IdAcquirer { get; set; }
        public CreditCardBrand CreditCardBrand { get; set; }
        public int? IdCreditCardBrand { get; set; }
    }
}
