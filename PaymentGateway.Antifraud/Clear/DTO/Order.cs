using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AntifraudClient.Clear.DTO
{
    public class Order
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
