using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.CrossCuting.HttpClient;

namespace PaymentGateway.Domain.AntiCorruption
{
    public abstract class ACLHttpClientService
    {
        public IHttpUtility HttpUtility { get; set; }

        public ACLHttpClientService() : this(new HttpUtility()) { }

        public ACLHttpClientService(IHttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }
    }
}
