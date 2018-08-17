using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AcquirerClient.Cielo.DTO
{
    public class Payment
    {
        public CreditCard CreditCard { get; set; }
        public string ServiceTaxAmount { get; set; }
        public string Installments { get; set; }
        public string Interest { get; set; }
        public string Capture { get; set; }
        public string Authenticate { get; set; }
        public string ProofOfSale { get; set; }
        public string Tid { get; set; }
        public string AuthorizationCode { get; set; }
        public string PaymentId { get; set; }
        public string Type { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string ExtraDataCollection { get; set; }
        public string Status { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

    }
}
