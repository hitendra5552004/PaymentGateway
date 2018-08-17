using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaymentGateway.AcquirerClient;
using PaymentGateway.Domain.Entities;
using PaymentGateway.AcquirerClient.Cielo;
using PaymentGateway.Application;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.AntiCorruption;

namespace PaymentGateway.Application.Tests
{
    public class SaleServiceAppTests
    {

        [Fact]
        public void CreateAcquirerSale()
        {
            //// Arrange
            //Sale Sale = new Sale();
            //SaleServiceApp SaleServiceApp = new SaleServiceApp(GetICreditCardService(), GetIStoreService(), GetIStoreAcquirerService(), GetIAcquirerSaleService(), GetIAntifraudClientService(), GetIAcquirerClientSaleService());
            //SaleServiceApp.CreateSale(Sale);
        }

        private IAcquirerClientSaleService GetIAcquirerClientSaleService()
        {
            AcquirerSale test = new AcquirerSale();
            test.Authorized = true;
            var AcquirerClientSaleService = new Mock<IAcquirerClientSaleService>();
            AcquirerClientSaleService
                .Setup(c => c.Create(ref test));
            return AcquirerClientSaleService.Object;
        }

        private IAntifraudClientService GetIAntifraudClientService()
        {
            var AntifraudClientService = new Mock<IAntifraudClientService>();
            return AntifraudClientService.Object;
        }

        private IStoreAcquirerService GetIStoreAcquirerService()
        {
            var StoreAcquirerService = new Mock<IStoreAcquirerService>();
            StoreAcquirerService
                .Setup(c => c.Search(null, nameof(StoreAcquirer.Acquirer)))
                .Returns(new List<StoreAcquirer>(){ new StoreAcquirer()
                    {
                     Acquirer = new Acquirer()
                     {
                          
                     }
                    }
                });
            return StoreAcquirerService.Object;
        }

        private IStoreService GetIStoreService()
        {
            var StoreService = new Mock<IStoreService>();
            StoreService
                .Setup(c => c.Search(null, nameof(CreditCard.CreditCardBrand)))
                .Returns(new List<Store>(){ new Store()
                    {
                    AntifraudEnabled = false
                    }
                });
            return StoreService.Object;
        }

        private IAcquirerSaleService GetIAcquirerSaleService()
        {
            var AcquirerSaleService = new Mock<IAcquirerSaleService>();
            AcquirerSaleService
                .Setup(c => c.Add(null))
                .Verifiable();
            return AcquirerSaleService.Object;
        }

        private ICreditCardService GetICreditCardService()
        {
            var CreditCardService = new Mock<ICreditCardService>();
            CreditCardService
                .Setup(c => c.Search(null, nameof(CreditCard.CreditCardBrand)))
                .Returns(new List<CreditCard>(){ new CreditCard()
                    {
                        CreditCardNumber = ""
                    }
                });
            return CreditCardService.Object;
        }

    }
}
