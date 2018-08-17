using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaymentGateway.AcquirerClient;
using PaymentGateway.Domain.Entities;
using PaymentGateway.AcquirerClient.Cielo;
using PaymentGateway.ACL.Tests;

namespace PaymentGateway.ACL.Tests.AcquirerClient
{
    public class CieloAcquirerClientSaleServiceTests
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
            SuccessRawResponse = "{    \"MerchantOrderId\": \"2014111706\",    \"Customer\": {        \"Name\": \"Comprador crédito simples\"    },    \"Payment\": {        \"ServiceTaxAmount\": 0,        \"Installments\": 1,        \"Interest\": \"ByMerchant\",        \"Capture\": false,        \"Authenticate\": false,        \"CreditCard\": {            \"CardNumber\": \"455187******0183\",            \"Holder\": \"Teste Holder\",            \"ExpirationDate\": \"12/2030\",            \"SaveCard\": false,            \"Brand\": \"Visa\"        },        \"ProofOfSale\": \"674532\",        \"Tid\": \"0305023644309\",        \"AuthorizationCode\": \"123456\",        \"PaymentId\": \"24bc8366-fc31-4d6c-8555-17049a836a07\",        \"Type\": \"CreditCard\",        \"Amount\": 15700,        \"Currency\": \"BRL\",        \"Country\": \"BRA\",        \"ExtraDataCollection\": [],        \"Status\": 1,        \"ReturnCode\": \"4\",        \"ReturnMessage\": \"Operation Successful\",        \"Links\": [            {                \"Method\": \"GET\",                \"Rel\": \"self\",                \"Href\": \"https://apiquerysandbox.cieloecommerce.cielo.com.br/1/sales/{PaymentId}\"        },            {                \"Method\": \"PUT\",                \"Rel\": \"capture\",                \"Href\": \"https://apisandbox.cieloecommerce.cielo.com.br/1/sales/{PaymentId}/capture\"            },            {                \"Method\": \"PUT\",                \"Rel\": \"void\",                \"Href\": \"https://apisandbox.cieloecommerce.cielo.com.br/1/sales/{PaymentId}/void\"            }        ]    }}";
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
            ErrorRawResponse = "{    \"MerchantOrderId\": \"2014111706\",    \"Customer\": {        \"Name\": \"Comprador crédito simples\"    },    \"Payment\": {        \"ServiceTaxAmount\": 0,        \"Installments\": 1,        \"Interest\": \"ByMerchant\",        \"Capture\": false,        \"Authenticate\": false,        \"CreditCard\": {            \"CardNumber\": \"455187******0183\",            \"Holder\": \"Teste Holder\",            \"ExpirationDate\": \"12/2030\",            \"SaveCard\": false,            \"Brand\": \"Visa\"        },        \"ProofOfSale\": \"674532\",        \"Tid\": \"0305023644309\",        \"AuthorizationCode\": \"123456\",        \"PaymentId\": \"24bc8366-fc31-4d6c-8555-17049a836a07\",        \"Type\": \"CreditCard\",        \"Amount\": 15700,        \"Currency\": \"BRL\",        \"Country\": \"BRA\",        \"ExtraDataCollection\": [],        \"Status\": 1,        \"ReturnCode\": \"4\",        \"ReturnMessage\": \"Operation Successful\",        \"Links\": [            {                \"Method\": \"GET\",                \"Rel\": \"self\",                \"Href\": \"https://apiquerysandbox.cieloecommerce.cielo.com.br/1/sales/{PaymentId}\"        },            {                \"Method\": \"PUT\",                \"Rel\": \"capture\",                \"Href\": \"https://apisandbox.cieloecommerce.cielo.com.br/1/sales/{PaymentId}/capture\"            },            {                \"Method\": \"PUT\",                \"Rel\": \"void\",                \"Href\": \"https://apisandbox.cieloecommerce.cielo.com.br/1/sales/{PaymentId}/void\"            }        ]    }}";
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
