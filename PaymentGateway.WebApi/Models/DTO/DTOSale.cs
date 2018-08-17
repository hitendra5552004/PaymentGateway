using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.WebApi.Models.DTO
{
    public class DTOSale
    {
        public int StoreId { get; set; }
        public int AmmountInCents { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
