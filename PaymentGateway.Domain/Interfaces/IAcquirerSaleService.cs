using System;
using PaymentGatewayDomain.Entities;

namespace PaymentGateway.Domain.Interfaces
{
    public interface IAcquirerSaleService
    {

        Sale Create(AcquirerSale sale);

    }
}
