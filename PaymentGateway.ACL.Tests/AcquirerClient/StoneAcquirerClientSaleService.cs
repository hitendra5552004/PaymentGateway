using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaymentGateway.AcquirerClient;
using PaymentGateway.Domain.Entities;
using PaymentGateway.AcquirerClient.Stone;
using PaymentGateway.ACL.Tests;

namespace PaymentGateway.ACL.Tests.AcquirerClient
{
    public class StoneAcquirerClientSaleService
    {

        [Fact]
        public void DoSuccessCreditCardSale()
        {
            // Arrange
            AcquirerClientSaleService Service = new AcquirerClientSaleService();
            AcquirerSale AcquirerSale = this.GetNewAcquirerSale();
            string SuccessRawResponse;
            HttpUtilityMock HttpUtilityMock = new HttpUtilityMock();
            // Act
            SuccessRawResponse = "{\"ErrorReport\": null,  \"InternalTime\": 137,  \"MerchantKey\": \"F2A1F485-CFD4-49F5-8862-0EBC438AE923\",  \"RequestKey\": \"857a5a07-ff3c-46e3-946e-452e25f149eb\",  \"BoletoTransactionResultCollection\": [],  \"BuyerKey\": \"00000000-0000-0000-0000-000000000000\",  \"CreditCardTransactionResultCollection\": [    {      \"AcquirerMessage\": \"Simulator|Transação de simulação autorizada com sucesso\",      \"AcquirerName\": \"Simulator\",      \"AcquirerReturnCode\": \"0\",      \"AffiliationCode\": \"000000000\",      \"AmountInCents\": 10000,      \"AuthorizationCode\": \"168147\",      \"AuthorizedAmountInCents\": 10000,      \"CapturedAmountInCents\": 10000,      \"CapturedDate\": \"2015-12-04T19:51:11\",      \"CreditCard\": {        \"CreditCardBrand\": \"Visa\",        \"InstantBuyKey\": \"3b3b5b62-6660-428d-905e-96f49d46ae28\",        \"IsExpiredCreditCard\": false,        \"MaskedCreditCardNumber\": \"411111****1111\"      },      \"CreditCardOperation\": \"AuthAndCapture\",      \"CreditCardTransactionStatus\": \"Captured\",      \"DueDate\": null,      \"ExternalTime\": 0,      \"PaymentMethodName\": \"Simulator\",      \"RefundedAmountInCents\": null,      \"Success\": true,      \"TransactionIdentifier\": \"246844\",      \"TransactionKey\": \"20ba0520-7d09-44f8-8fbc-e4329e2b18d5\",      \"TransactionKeyToAcquirer\": \"20ba05207d0944f8\",      \"TransactionReference\": \"1c65eaf7-df3c-4c7f-af63-f90fb6200996\",      \"UniqueSequentialNumber\": \"636606\",      \"VoidedAmountInCents\": null    }  ],  \"OrderResult\": {    \"CreateDate\": \"2015-12-04T19:51:11\",    \"OrderKey\": \"219d7581-78e2-4aa9-b708-b7c585780bfc\",    \"OrderReference\": \"NúmeroDoPedido\"  }}";
            HttpUtilityMock.MockRawResponse = SuccessRawResponse;
            HttpUtilityMock.MockStatusCode = System.Net.HttpStatusCode.Created;
            Service.HttpUtility = HttpUtilityMock;
            Service.Create(ref AcquirerSale);
            // Assert
            Assert.True(AcquirerSale.AcquirerSuccess == true);
        }

        [Fact]
        public void DoErrorCreditCardSale()
        {
            // Arrange
            AcquirerClientSaleService Service = new AcquirerClientSaleService();
            AcquirerSale AcquirerSale = this.GetNewAcquirerSale();
            string ErrorRawResponse;
            HttpUtilityMock HttpUtilityMock = new HttpUtilityMock();
            // Act
            ErrorRawResponse = "{  \"ErrorReport\": {    \"Category\": \"RequestError\",    \"ErrorItemCollection\": [      {        \"Description\": \"A bandeira Invalida atualmente não é suportada.\",        \"ErrorCode\": 400,        \"ErrorField\": \"CreditCardBrand\",        \"SeverityCode\": \"Error\"      }    ]  },  \"InternalTime\": 0,  \"MerchantKey\": \"F2A1F485-CFD4-49F5-8862-0EBC438AE923\",  \"RequestKey\": \"fb0f6d14-3564-4ac2-bc88-9d319816b966\",  \"BuyerKey\": \"00000000-0000-0000-0000-000000000000\",}";
            HttpUtilityMock.MockRawResponse = ErrorRawResponse;
            HttpUtilityMock.MockStatusCode = System.Net.HttpStatusCode.BadRequest;
            Service.HttpUtility = HttpUtilityMock;
            Service.Create(ref AcquirerSale);
            // Assert
            Assert.True(AcquirerSale.AcquirerSuccess == false);
        }

        private AcquirerSale GetNewAcquirerSale()
        {
            return new AcquirerSale()
            {
                Store = new Store()
                {
                    MerchantKey = ""
                },
                Acquirer = new Acquirer()
                {
                    ServiceUri = ""
                }
            };
        }
        
    }
}
