using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces.AntiCorruption;
using PaymentGateway.Domain.AntiCorruption;
using PaymentGateway.Domain.Entities;
using PaymentGateway.AcquirerClient.Cielo.DTO;
using System.Collections.Specialized;
using Infrastructure.CrossCuting.HttpClient;
using System.Net;

namespace PaymentGateway.AcquirerClient.Cielo
{
    public class AcquirerClientSaleService : AcquirerClientService, IAcquirerClientSaleService
    {
        
        public void Create(ref AcquirerSale acquirerSale)
        {
            // Arrange post
            CreateSaleContract CreateSaleContract = new CreateSaleContract();

            // Call endpoint
            NameValueCollection headers = new NameValueCollection();
            headers.Add("MerchantKey", acquirerSale.Store.MerchantKey);
            headers.Add("MerchantId", acquirerSale.Store.Id.ToString());
            headers.Add("Content-Type", "application/json");
            
            HttpResponse<CreateSaleContract> Response = this.HttpUtility.SubmitRequest<CreateSaleContract, CreateSaleContract>(CreateSaleContract,
            acquirerSale.Acquirer.ServiceUri, HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);
            
            // Arrange return
            if (Response.HttpStatusCode == HttpStatusCode.Created)
            {
                acquirerSale.AcquirerSuccess = true;
                acquirerSale.AcquirerRawResponse = Response.RawResponse;
                acquirerSale.StatusCode = Response.HttpStatusCode.ToString();
            }
            else
            {
                acquirerSale.AcquirerSuccess = false;
            }
        }

    }
}
