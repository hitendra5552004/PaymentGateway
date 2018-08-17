using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;

namespace PaymentGateway.Domain.Services
{
    public class AcquirerSaleService : Service<AcquirerSale>, IAcquirerSaleService
    {

        private IRepositoryAcquirerSale Repository;

        public AcquirerSaleService(IRepositoryAcquirerSale repository) : base(repository)
        {
            Repository = repository;
        }

    }
}
