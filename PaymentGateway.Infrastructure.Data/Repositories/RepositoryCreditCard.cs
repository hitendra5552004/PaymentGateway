using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces.Repositories;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Infrastructure.Data;

namespace PaymentGateway.Infrastructure.Data.Repositories
{
    public class RepositoryCreditCard: Repository<CreditCard>, IRepositoryCreditCard
    {
        private readonly PaymentGatewayContext _dbContext;
        
        public RepositoryCreditCard(PaymentGatewayContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
