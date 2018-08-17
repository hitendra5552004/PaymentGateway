using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Entities;

namespace PaymentGateway.Infrastructure.Data
{
    public class DbInitializer
    {

        public static void Initialize(PaymentGatewayContext context)
        {

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var antifraud = new Antifraud()
            {
                Name = "Clear",
                ServiceUri = "https://integration.clearsale.com.br/api/order/get"
            };

            var stores = new List<Store>() {

                new Store { Name = "000", AntifraudEnabled = true, MerchantKey = "123456789", Antifraud = antifraud},
                new Store { Name = "001", AntifraudEnabled = false, MerchantKey = "123456789"}
            };

            var creditCardBrands = new List<CreditCardBrand>() {

                new CreditCardBrand { Name = "Master"},
                new CreditCardBrand { Name = "Visa"}
            };

            var acquirers = new List<Acquirer>() {

                new Acquirer { Name = "Stone", Assembly = "PaymentGateway.AcquirerClient.Stone.AcquirerClientSaleService", ServiceUri = "https://transaction.stone.com.br/Sale" }  ,
                new Acquirer { Name = "Cielo", Assembly = "PaymentGateway.AcquirerClient.Cielo.AcquirerClientSaleService", ServiceUri = "https://apisandbox.cieloecommerce.cielo.com.br/1/sales/" }
            };

            var storeAcquirers = new List<StoreAcquirer>() {

                new StoreAcquirer { Store = stores[0], Acquirer = acquirers[0], CreditCardBrand = creditCardBrands[0] },
                new StoreAcquirer { Store = stores[0], Acquirer = acquirers[0], CreditCardBrand = creditCardBrands[1] },
                new StoreAcquirer { Store = stores[1], Acquirer = acquirers[0], CreditCardBrand = creditCardBrands[0] },
                new StoreAcquirer { Store = stores[1], Acquirer = acquirers[1], CreditCardBrand = creditCardBrands[1] }
            };

            var creditCards = new List<CreditCard>() {

                new CreditCard { CreditCardBrand = creditCardBrands[0], CreditCardNumber = "0000000000000000" },
                new CreditCard { CreditCardBrand = creditCardBrands[1], CreditCardNumber = "0000000000000001" }
            };

            context.Stores.AddRange(stores);
            context.CreditCardBrands.AddRange(creditCardBrands);
            context.Acquirers.AddRange(acquirers);
            context.StoreAcquirers.AddRange(storeAcquirers);
            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();

        }

    }
}
