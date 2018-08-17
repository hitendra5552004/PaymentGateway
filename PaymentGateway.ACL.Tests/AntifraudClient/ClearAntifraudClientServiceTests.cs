using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaymentGateway.AntifraudClient;
using PaymentGateway.Domain.Entities;
using PaymentGateway.AntifraudClient.Clear;
using PaymentGateway.ACL.Tests;

namespace PaymentGateway.ACL.Tests.AntifraudClient
{
    public class ClearAntifraudClientServiceTests
    {

        [Fact]
        public void DoSuccessAuthorization()
        {
            // Arrange
            AntifraudClientService Service = new AntifraudClientService();
            AcquirerSale AcquirerSale = this.GetNewAcquirerSale();
            string SuccessRawResponse;
            HttpUtilityMock HttpUtilityMock = new HttpUtilityMock();
            // Act
            SuccessRawResponse = "{\"Orders\": [{                \"ID\": \"1\",\"Status\":\"APA\",\"Score\": \"1\"}],\"TransactionID\":\"BRA\"}";
            HttpUtilityMock.MockRawResponse = SuccessRawResponse;
            HttpUtilityMock.MockStatusCode = System.Net.HttpStatusCode.OK;
            Service.HttpUtility = HttpUtilityMock;
            Service.Execute(ref AcquirerSale);
            // Assert
            Assert.True(AcquirerSale.Authorized == true);
        }

        [Fact]
        public void DoDeniedAuthorization()
        {
            // Arrange
            AntifraudClientService Service = new AntifraudClientService();
            AcquirerSale AcquirerSale = this.GetNewAcquirerSale();
            string SuccessRawResponse;
            HttpUtilityMock HttpUtilityMock = new HttpUtilityMock();
            // Act
            SuccessRawResponse = "{\"Orders\": [{                \"ID\": \"1\",\"Status\":\"RPM\",\"Score\": \"1\"}],\"TransactionID\":\"BRA\"}";
            HttpUtilityMock.MockRawResponse = SuccessRawResponse;
            HttpUtilityMock.MockStatusCode = System.Net.HttpStatusCode.OK;
            Service.HttpUtility = HttpUtilityMock;
            Service.Execute(ref AcquirerSale);
            // Assert
            Assert.True(AcquirerSale.Authorized == false);
        }

        private AcquirerSale GetNewAcquirerSale()
        {
            return new AcquirerSale()
            {
                Store = new Store()
                {
                    MerchantKey = "",
                    Antifraud = new Antifraud()
                    {
                        ServiceUri = ""
                    }
                },
                Acquirer = new Acquirer()
                {
                    ServiceUri = ""
                },
                CreditCardPayments = new List<CreditCardPayment>()
                {
                     new CreditCardPayment()
                     {
                          AmountInCents = 10,
                          CreditCard =  new CreditCard()
                          {
                               CreditCardNumber = "0000000000000001"
                          }
                     }
                }
            };
        }

    }
}
