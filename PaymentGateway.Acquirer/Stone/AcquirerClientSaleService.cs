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
using System.Collections.Specialized;

namespace PaymentGateway.AcquirerClient.Stone
{
    public class AcquirerClientSaleService : AcquirerClientService, IAcquirerClientSaleService
    {

        public void Create(ref AcquirerSale acquirerSale)
        {
            CreateSaleRequest RequestObject = new CreateSaleRequest();
            
            // Call external endpoint
            NameValueCollection headers = new NameValueCollection();
            headers.Add("MerchantKey", acquirerSale.Store.MerchantKey);
            HttpResponse<CreateSaleResponse> Response = this.HttpUtility.SubmitRequest<CreateSaleRequest, CreateSaleResponse>(RequestObject,
            acquirerSale.Acquirer.ServiceUri, HttpVerbEnum.Post, HttpContentTypeEnum.Json, headers);

            // Set AcquirerSale with the external api returned data
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