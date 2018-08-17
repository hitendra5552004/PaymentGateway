using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.CrossCuting.HttpClient;

namespace PaymentGateway.Domain.AntiCorruption
{

    public abstract class AcquirerClientService
    {

        public IHttpUtility HttpUtility { get; set; }

        public AcquirerClientService(): this(new HttpUtility()) {}

        public AcquirerClientService(IHttpUtility httpUtility)
        {
            HttpUtility = httpUtility;
        }

    }

}
