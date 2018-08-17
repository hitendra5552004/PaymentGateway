using System;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Interfaces.AntiCorruption
{
    public interface IAcquirerClientSaleService
    {

        void Create(ref AcquirerSale sale);

    }
}
