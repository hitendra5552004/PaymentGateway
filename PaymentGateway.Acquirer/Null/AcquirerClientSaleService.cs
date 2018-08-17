using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PaymentGateway.AcquirerClient;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.AntiCorruption;
using PaymentGateway.Domain.AntiCorruption;
using Infrastructure.CrossCuting.Serialization;
using GatewayApiClient.DataContracts;
using GatewayApiClient;
using Infrastructure.CrossCuting.HttpClient;
using System.Net;

namespace PaymentGateway.AcquirerClient.Null
{
    public class AcquirerClientSaleService : AcquirerClientService, IAcquirerClientSaleService
    {

        public void Create(ref AcquirerSale acquirerSale)
        {
            throw new NotImplementedException();
        }

    }
}
