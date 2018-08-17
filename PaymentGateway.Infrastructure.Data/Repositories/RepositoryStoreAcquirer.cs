using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces.Repositories;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Data;

namespace PaymentGateway.Infrastructure.Data.Repositories
{
    public class RepositoryStoreAcquirer : Repository<StoreAcquirer>, IRepositoryStoreAcquirer
    {
        private readonly PaymentGatewayContext _dbContext;
        
        public RepositoryStoreAcquirer(PaymentGatewayContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
