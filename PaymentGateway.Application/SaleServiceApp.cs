using System;
using PaymentGateway.Application.Interfaces;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using PaymentGateway.Application.Factories;
using PaymentGateway.Domain.Interfaces.AntiCorruption;

namespace PaymentGateway.Application
{
    public class SaleServiceApp : ISaleServiceApp
    {
        
        IAcquirerSaleService AcquirerSaleService;
        ICreditCardService CreditCardService;
        IStoreService StoreService;
        IStoreAcquirerService StoreAcquirerService;
        IAntifraudClientService AntifraudClientService;
        IAcquirerClientSaleService AcquirerClientSaleService;

        public SaleServiceApp(ICreditCardService creditCardService, IStoreService storeService, IStoreAcquirerService storeAcquirerService, IAcquirerSaleService acquirerSaleService, IAntifraudClientService antifraudClientService, IAcquirerClientSaleService acquirerClientSaleService)
        {
            CreditCardService = creditCardService;
            StoreService = storeService;
            StoreAcquirerService = storeAcquirerService;
            AcquirerSaleService = acquirerSaleService;
            AntifraudClientService = antifraudClientService;
            AcquirerClientSaleService = acquirerClientSaleService;
        }

        public void CreateSale(Sale sale)
        {

            CreditCard CreditCard = CreditCardService.Search(c => c.CreditCardNumber == sale.CreditCardNumber, nameof(CreditCard.CreditCardBrand)).First();
            Store Store = StoreService.Search(c => c.Id == sale.StoreId, nameof(Store.Antifraud)).First();
            StoreAcquirer StoreAcquirer = StoreAcquirerService.Search(c => c.IdCreditCardBrand == CreditCard.Id && c.IdStore == Store.Id, nameof(StoreAcquirer.Acquirer)).First();
            
            // Instancia o client configurado
            if(AcquirerClientSaleService.GetType() == typeof(AcquirerClient.Null.AcquirerClientSaleService))
            {
                AcquirerClientSaleService = AcquirerClientSaleServiceFactory.CreateInstance(StoreAcquirer.Acquirer.Assembly);
            }
            
            AcquirerSale AcquirerSale = new AcquirerSale()
            {
                Store = StoreAcquirer.Store,
                Acquirer = StoreAcquirer.Acquirer,
                CreditCardPayments = new List<CreditCardPayment>()
                {
                    new CreditCardPayment()
                    {
                        AmountInCents = sale.AmmountInCents,
                        CreditCard = CreditCard
                    }
                }
            };

            // Verificar se acquirer usa autorizacao
            if (StoreAcquirer.Store.AntifraudEnabled)
            {
                // Antifraud
                AntifraudClientService.Execute(ref AcquirerSale);

                if (!AcquirerSale.Authorized) return;
            }

            AcquirerClientSaleService.Create(ref AcquirerSale);

            // Registra resultado da operação
            AcquirerSaleService.Add(AcquirerSale);
            
        }

    }
}
