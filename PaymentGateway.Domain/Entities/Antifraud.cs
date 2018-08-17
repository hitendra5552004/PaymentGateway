using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class Antifraud
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceUri { get; set; }

    }
}
