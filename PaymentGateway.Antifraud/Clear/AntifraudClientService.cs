using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PaymentGateway.AntifraudClient;
using PaymentGateway.AntifraudClient.Clear.DTO;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Domain.Interfaces.AntiCorruption;
using PaymentGateway.Domain.AntiCorruption;

using Infrastructure.CrossCuting.Serialization;
using Infrastructure.CrossCuting.HttpClient;
using System.Net;
using System.Collections.Specialized;

namespace PaymentGateway.AntifraudClient.Clear
{
    public class AntifraudClientService : ACLHttpClientService, IAntifraudClientService
    {

        public void Execute(ref AcquirerSale acquirerSale)
        {
            // Arrange post
            ClearRequest ClearRequest = new ClearRequest()
            {
                ApiKey = "",
                Orders = new List<Order>()
                     {
                        new Order()
                        {
                           Payments = new List<Payment>()
                           {
                               new Payment()
                               {
                                    Amount = acquirerSale.CreditCardPayments[0].AmountInCents,
                                    CardBin = acquirerSale.CreditCardPayments[0].CreditCard.CreditCardNumber,
                                    CardNumber = acquirerSale.CreditCardPayments[0].CreditCard.CreditCardNumber
                               }
                           }
                        }
                }
            };

            // Call endpoint
            NameValueCollection headers = new NameValueCollection();
            headers.Add("MerchantKey", acquirerSale.Store.MerchantKey);
            headers.Add("Content-Type", "application/json");

            HttpResponse<ClearResponse> Response = this.HttpUtility.SubmitRequest<ClearRequest, ClearResponse>(ClearRequest,
            acquirerSale.Store.Antifraud.ServiceUri, HttpVerbEnum.Get, HttpContentTypeEnum.Json, headers);

            // Arrange return
            acquirerSale.Authorized = false;
            if (Response.HttpStatusCode == HttpStatusCode.OK)
            {
                if (Response.Response.Orders[0].Status == Clear.DTO.Status.APA.ToString())
                {
                    acquirerSale.Authorized = true;
                    acquirerSale.AuthorizationRawResponse = Response.RawResponse;
                    acquirerSale.AuthStatusCode = Response.HttpStatusCode.ToString();
                }
            }
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
