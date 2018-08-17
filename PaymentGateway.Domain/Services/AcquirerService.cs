using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;

namespace PaymentGateway.Domain.Services
{
    public class AcquirerService : Service<Acquirer>, IAcquirerService
    {

        private IRepositoryAcquirer Repository;

        public AcquirerService(IRepositoryAcquirer repository) : base(repository)
        {
            Repository = repository;
        }

    }
}
