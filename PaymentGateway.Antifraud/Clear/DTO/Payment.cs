using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.AntifraudClient.Clear.DTO
{
    public class Payment
    {
        public string CardNumber { get; set; }
        public int Amount { get; set; }
        public string CardBin { get; set; }
    }
}
