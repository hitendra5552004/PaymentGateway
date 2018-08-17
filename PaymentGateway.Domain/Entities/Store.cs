using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MerchantKey { get; set; }
        public bool AntifraudEnabled { get; set; }
        public virtual List<StoreAcquirer> StoreAcquirer { get; set; }
    }
}
