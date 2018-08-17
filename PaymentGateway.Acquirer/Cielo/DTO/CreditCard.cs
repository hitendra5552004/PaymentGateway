using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AcquirerClient.Cielo.DTO
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SaveCard { get; set; }
        public string Brand { get; set; }
    }
}
