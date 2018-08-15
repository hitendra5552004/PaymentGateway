using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.Services;
using PaymentGatewayDomain.Entities;

namespace PaymentGateway.Acquirer.Cielo
{
    public class SaleService : AcquirerService, IAcquirerSaleService
    {

        public SaleService(string merchantKey, string endpoint) : base(merchantKey, endpoint)
        {

        }

        public Sale Create(AcquirerSale sale)
        {
            // Map the model to the acquirer appropriate object.
            // Cielo API call:
            // Map acquirer response to model.
            sale.AcquirerSuccess = true;
            return sale;
        }

    }
}
