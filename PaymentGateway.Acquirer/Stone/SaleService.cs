using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PaymentGateway.Acquirer;
using PaymentGatewayDomain.Entities;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.Services;
using Infrastructure.CrossCuting.Serialization;
using GatewayApiClient.DataContracts;
using GatewayApiClient;

namespace PaymentGateway.Acquirer.Stone
{
    public class SaleService : AcquirerService, IAcquirerSaleService
    {

        private SaleServiceMapper Mapper;
        private GatewayApiClientMock Mock;
        private IGatewayServiceClient ServiceClient;
        private ISerializer Serializer;

        public SaleService(string merchantKey, string endpoint) : base(merchantKey, endpoint)
        {
            Mapper = new SaleServiceMapper();
            Mock = new GatewayApiClientMock();
            Serializer = new JsonSerializer();
        }

        public Sale Create(Sale sale)
        {
            // Map the model to the acquirer appropriate object.
            CreateSaleRequest Request = Mapper.FromSaleToCreateSaleRequest(sale);

            // Stone API call (mock):
            CreateSaleResponse Response = Mock.CreateSaleMocked();
            sale.AcquirerRawResponse = Serializer.SerializeObject<CreateSaleResponse>(Response);
            return sale;
        }

        //public Sale Create(Sale sale)
        //{
        //    // Map the model to the acquirer appropriate object.
        //    CreateSaleRequest Request = Mapper.FromSaleToCreateSaleRequest(sale);

        //    // Stone API call:
        //    ServiceClient = new GatewayServiceClient(Guid.Parse(MerchantKey), new Uri(Endpoint));
        //    HttpResponse<CreateSaleResponse> httpResponse = ServiceClient.Sale.Create(Request);
        //    CreateSaleResponse Response = httpResponse.Response;

        //    // Map acquirer response to model.
        //    Sale Sale = Mapper.FromCreateSaleResponseToSale(Response);
        //    return Sale;
        //}

    }
}