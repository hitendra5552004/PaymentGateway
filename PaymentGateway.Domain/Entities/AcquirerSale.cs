using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class AcquirerSale
    {
        public int Id { get; set; }
        public Acquirer Acquirer { get; set; }
        public int? AcquirerId { get; set; }
        public DateTime DateTime { get; set; }
        public Store Store { get; set; }
        public bool AcquirerSuccess { get; set; }
        public bool Authorized { get; set; }
        public string AcquirerRawResponse { get; set; }
        public string AuthorizationRawResponse { get; set; }
        public string AuthStatusCode { get; set; }
        public virtual List<CreditCardPayment> CreditCardPayments { get; set; }
        public string StatusCode { get; set; }
    }
}
