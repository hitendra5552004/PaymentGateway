using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.Entities
{
    public class Acquirer
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Assembly { get; set; }
        public virtual List<StoreAcquirer> StoreAcquirer { get; set; }

    }
}
