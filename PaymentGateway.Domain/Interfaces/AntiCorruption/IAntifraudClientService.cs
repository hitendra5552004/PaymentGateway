using System;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Domain.Interfaces.AntiCorruption
{
    public interface IAntifraudClientService
    {

        void Execute(ref AcquirerSale acquirerSale);

    }
}
