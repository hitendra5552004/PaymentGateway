using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Acquirer;
using PaymentGatewayDomain.Entities;
using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using GatewayApiClient.Utility;

namespace PaymentGateway.Acquirer.Stone
{
    public class SaleServiceMapper
    {
        public CreateSaleRequest FromAcquirerSaleToCreateSaleRequest(AcquirerSale sale)
        {
            // TODO: Map objects
            return null;
        }

        public AcquirerSale FromCreateSaleResponseToAcquirerSale(CreateSaleResponse createSaleRequest)
        {
            // TODO: Map objects
            return null;
        }
    }
}
