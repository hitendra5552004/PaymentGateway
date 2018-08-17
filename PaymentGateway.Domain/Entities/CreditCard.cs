using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CreditCardNumber { get; set; }
        //public int IdCreditCardBrand { get; set; }
        public CreditCardBrand CreditCardBrand { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public int SecurityCode { get; set; }
        public string HolderName { get; set; }
    }
}
