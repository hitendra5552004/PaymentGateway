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
        
        IAcquirerService AcquirerService;
        IAcquirerSaleService AcquirerSaleService;
        ICreditCardService CreditCardService;
        IStoreService StoreService;
        IStoreAcquirerService StoreAcquirerService;

        public SaleServiceApp(IAcquirerService acquirerService, ICreditCardService creditCardService, IStoreService storeService, IStoreAcquirerService storeAcquirerService, IAcquirerSaleService acquirerSaleService)
        {
            AcquirerService = acquirerService;
            CreditCardService = creditCardService;
            StoreService = storeService;
            StoreAcquirerService = storeAcquirerService;
            AcquirerSaleService = acquirerSaleService;
        }

        public void CreateSale(Sale sale)
        {

            CreditCard CreditCard = CreditCardService.Search(c => c.CreditCardNumber == sale.CreditCardNumber, nameof(CreditCard.CreditCardBrand)).First();
            StoreAcquirer StoreAcquirer = StoreAcquirerService.Search(c => c.IdCreditCardBrand == CreditCard.Id && c.IdStore == sale.StoreId, nameof(StoreAcquirer.Acquirer), nameof(StoreAcquirer.Store)).First();
            
            // Verificar se aquirer usa autorizacao
            if (StoreAcquirer.Store.AntifraudEnabled)
            {
                // Antifraud
            }

            // Instancia o client configurado
            IAcquirerClientSaleService AcquirerClientSaleService = AcquirerClientSaleServiceFactory.CreateInstance(StoreAcquirer.Acquirer.Assembly);
            
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

            // Call Acquirer
            AcquirerClientSaleService.Create(ref AcquirerSale);

            // persite
            AcquirerSaleService.Add(AcquirerSale);
            
        }

    }
}
