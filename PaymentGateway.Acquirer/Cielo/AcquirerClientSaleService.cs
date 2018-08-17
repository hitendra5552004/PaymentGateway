using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces.AntiCorruption;
using PaymentGateway.Domain.AntiCorruption;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.AcquirerClient.Cielo
{
    public class AcquirerClientSaleService : AcquirerClientService, IAcquirerClientSaleService
    {
        
        public void Create(ref AcquirerSale acquirerSale)
        {

            // TODO: Map object to DTO
            // TODO: Pass to endpoint
            // TODO: Map DTO to object

            throw new NotImplementedException();
        }

    }
}
