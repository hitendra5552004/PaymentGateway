using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AntifraudClient.Clear.DTO
{
    public class ClearRequest
    {
        public string ApiKey { get; set; }
        public List<Order> Orders { get; set; }
    }
}
