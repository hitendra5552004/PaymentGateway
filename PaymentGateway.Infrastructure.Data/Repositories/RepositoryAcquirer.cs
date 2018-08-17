using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces.Repositories;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Data;

namespace PaymentGateway.Infrastructure.Data.Repositories
{
    public class RepositoryAcquirer : Repository<Acquirer>, IRepositoryAcquirer
    {
        private readonly PaymentGatewayContext _dbContext;
        
        public RepositoryAcquirer(PaymentGatewayContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
