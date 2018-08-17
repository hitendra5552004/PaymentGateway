using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AntifraudClient.Clear.DTO
{
    public class ClearResponse
    {
        public List<Order> Orders { get; set; }
        public string TransactionID { get; set; }
    }
}
