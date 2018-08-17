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

// TODO: Move to test project

namespace PaymentGateway.AcquirerClient.Stone
{
    public class SaleServiceMockError : AcquirerClientService, IAcquirerClientSaleService
    {

        /// <summary>
        /// Retorna um mock de criação de venda com Erro.
        /// </summary>
        /// <param name="acquirerSale"></param>
        /// <returns></returns>
        public void Create(ref AcquirerSale acquirerSale)
        {
            ISerializer Serializer = new JsonSerializer();
            string MockResponse = "{  \"ErrorReport\": {    \"Category\": \"RequestError\",    \"ErrorItemCollection\": [      {        \"Description\": \"A bandeira Invalida atualmente não é suportada.\",        \"ErrorCode\": 400,        \"ErrorField\": \"CreditCardBrand\",        \"SeverityCode\": \"Error\"      }    ]  },  \"InternalTime\": 0,  \"MerchantKey\": \"F2A1F485-CFD4-49F5-8862-0EBC438AE923\",  \"RequestKey\": \"fb0f6d14-3564-4ac2-bc88-9d319816b966\",  \"BuyerKey\": \"00000000-0000-0000-0000-000000000000\",}";
            CreateSaleResponse Response = Serializer.DeserializeObject<CreateSaleResponse>(MockResponse);
            HttpResponse<CreateSaleResponse> HttpResponse = new HttpResponse<CreateSaleResponse>(Response, MockResponse, HttpStatusCode.BadRequest);
            acquirerSale.AcquirerRawResponse = HttpResponse.RawResponse;
            acquirerSale.StatusCode = HttpResponse.HttpStatusCode.ToString();
        }

    }
}