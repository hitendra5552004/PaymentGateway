using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;

namespace PaymentGateway.Domain.Services
{
    public class StoreAcquirerService : Service<StoreAcquirer>, IStoreAcquirerService
    {

        private IRepositoryStoreAcquirer Repository;

        public StoreAcquirerService(IRepositoryStoreAcquirer repository) : base(repository)
        {
            Repository = repository;
        }

    }
}
