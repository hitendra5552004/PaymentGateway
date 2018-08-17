using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;

namespace PaymentGateway.Domain.Services
{
    public class CreditCardService : Service<CreditCard>, ICreditCardService
    {

        private IRepositoryCreditCard Repository;

        public CreditCardService(IRepositoryCreditCard repository) : base(repository)
        {
            Repository = repository;
        }

    }
}
