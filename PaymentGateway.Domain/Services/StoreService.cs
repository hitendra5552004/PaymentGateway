using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;

namespace PaymentGateway.Domain.Services
{
    public class StoreService : Service<Store>, IStoreService
    {

        private IRepositoryStore Repository;

        public StoreService(IRepositoryStore repository) : base(repository)
        {
            Repository = repository;
        }

    }
}
