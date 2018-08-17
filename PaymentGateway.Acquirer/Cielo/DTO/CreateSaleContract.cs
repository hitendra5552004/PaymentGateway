using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AcquirerClient.Cielo.DTO
{
    public class CreateSaleContract
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}
