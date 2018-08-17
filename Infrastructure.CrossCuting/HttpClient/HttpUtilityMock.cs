//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Text;
//using Infrastructure.CrossCuting.HttpClient;
//using Infrastructure.CrossCuting.Serialization;

//namespace Infrastructure.CrossCuting.HttpClient
//{
//    public class HttpUtilityMock : IHttpUtility
//    {
//        public HttpResponse SendHttpWebRequest(string dataToSend, HttpVerbEnum httpVerbEnum, string contentType, string accept, string serviceEndpoint, NameValueCollection headerData)
//        {
//            throw new NotImplementedException();
//        }

//        public HttpResponse<TResponse, TRequest> SubmitRequest<TRequest, TResponse>(TRequest request, string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header)
//        {
//            string MockResponse = "{\"ErrorReport\": null,  \"InternalTime\": 137,  \"MerchantKey\": \"F2A1F485-CFD4-49F5-8862-0EBC438AE923\",  \"RequestKey\": \"857a5a07-ff3c-46e3-946e-452e25f149eb\",  \"BoletoTransactionResultCollection\": [],  \"BuyerKey\": \"00000000-0000-0000-0000-000000000000\",  \"CreditCardTransactionResultCollection\": [    {      \"AcquirerMessage\": \"Simulator|Transação de simulação autorizada com sucesso\",      \"AcquirerName\": \"Simulator\",      \"AcquirerReturnCode\": \"0\",      \"AffiliationCode\": \"000000000\",      \"AmountInCents\": 10000,      \"AuthorizationCode\": \"168147\",      \"AuthorizedAmountInCents\": 10000,      \"CapturedAmountInCents\": 10000,      \"CapturedDate\": \"2015-12-04T19:51:11\",      \"CreditCard\": {        \"CreditCardBrand\": \"Visa\",        \"InstantBuyKey\": \"3b3b5b62-6660-428d-905e-96f49d46ae28\",        \"IsExpiredCreditCard\": false,        \"MaskedCreditCardNumber\": \"411111****1111\"      },      \"CreditCardOperation\": \"AuthAndCapture\",      \"CreditCardTransactionStatus\": \"Captured\",      \"DueDate\": null,      \"ExternalTime\": 0,      \"PaymentMethodName\": \"Simulator\",      \"RefundedAmountInCents\": null,      \"Success\": true,      \"TransactionIdentifier\": \"246844\",      \"TransactionKey\": \"20ba0520-7d09-44f8-8fbc-e4329e2b18d5\",      \"TransactionKeyToAcquirer\": \"20ba05207d0944f8\",      \"TransactionReference\": \"1c65eaf7-df3c-4c7f-af63-f90fb6200996\",      \"UniqueSequentialNumber\": \"636606\",      \"VoidedAmountInCents\": null    }  ],  \"OrderResult\": {    \"CreateDate\": \"2015-12-04T19:51:11\",    \"OrderKey\": \"219d7581-78e2-4aa9-b708-b7c585780bfc\",    \"OrderReference\": \"NúmeroDoPedido\"  }}";
//            string rawRequest = this.SerializeObject<TRequest>(request, contentType);
//            TResponse responseObject = this.DeserializeObject<TResponse>(MockResponse, contentType);
//            HttpResponse<TResponse> response_ = new HttpResponse<TResponse>(responseObject, MockResponse, System.Net.HttpStatusCode.Created);
//            HttpResponse<TResponse, TRequest> response = new HttpResponse<TResponse, TRequest>(request, rawRequest, responseObject, MockResponse, System.Net.HttpStatusCode.Created);
//            return response;
//        }

//        public HttpResponse<TResponse> SubmitRequest<TResponse>(string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header)
//        {
//            string MockResponse = "{\"ErrorReport\": null,  \"InternalTime\": 137,  \"MerchantKey\": \"F2A1F485-CFD4-49F5-8862-0EBC438AE923\",  \"RequestKey\": \"857a5a07-ff3c-46e3-946e-452e25f149eb\",  \"BoletoTransactionResultCollection\": [],  \"BuyerKey\": \"00000000-0000-0000-0000-000000000000\",  \"CreditCardTransactionResultCollection\": [    {      \"AcquirerMessage\": \"Simulator|Transação de simulação autorizada com sucesso\",      \"AcquirerName\": \"Simulator\",      \"AcquirerReturnCode\": \"0\",      \"AffiliationCode\": \"000000000\",      \"AmountInCents\": 10000,      \"AuthorizationCode\": \"168147\",      \"AuthorizedAmountInCents\": 10000,      \"CapturedAmountInCents\": 10000,      \"CapturedDate\": \"2015-12-04T19:51:11\",      \"CreditCard\": {        \"CreditCardBrand\": \"Visa\",        \"InstantBuyKey\": \"3b3b5b62-6660-428d-905e-96f49d46ae28\",        \"IsExpiredCreditCard\": false,        \"MaskedCreditCardNumber\": \"411111****1111\"      },      \"CreditCardOperation\": \"AuthAndCapture\",      \"CreditCardTransactionStatus\": \"Captured\",      \"DueDate\": null,      \"ExternalTime\": 0,      \"PaymentMethodName\": \"Simulator\",      \"RefundedAmountInCents\": null,      \"Success\": true,      \"TransactionIdentifier\": \"246844\",      \"TransactionKey\": \"20ba0520-7d09-44f8-8fbc-e4329e2b18d5\",      \"TransactionKeyToAcquirer\": \"20ba05207d0944f8\",      \"TransactionReference\": \"1c65eaf7-df3c-4c7f-af63-f90fb6200996\",      \"UniqueSequentialNumber\": \"636606\",      \"VoidedAmountInCents\": null    }  ],  \"OrderResult\": {    \"CreateDate\": \"2015-12-04T19:51:11\",    \"OrderKey\": \"219d7581-78e2-4aa9-b708-b7c585780bfc\",    \"OrderReference\": \"NúmeroDoPedido\"  }}";
//            TResponse responseObject = this.DeserializeObject<TResponse>(MockResponse, contentType);
//            HttpResponse<TResponse> response = new HttpResponse<TResponse>(responseObject, MockResponse, System.Net.HttpStatusCode.Created);
//            return response;
//        }

//        /// <summary>
//        /// Realiza a deserialização de uma string Json ou Xml para um objeto
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="serializedObject"></param>
//        /// <param name="httpContentType"></param>
//        /// <returns></returns>
//        private T DeserializeObject<T>(string serializedObject, HttpContentTypeEnum httpContentType)
//        {

//            // Obtém um serializador para o content type definido.
//            ISerializer serializer = SerializerFactory.Create(httpContentType.ToString());

//            // Realiza a deserialização da string para o objeto informado
//            T obj = serializer.DeserializeObject<T>(serializedObject);

//            return obj;
//        }

//        /// <summary>
//        /// Serializa um objeto para uma string Json ou Xml
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="obj"></param>
//        /// <param name="httpContentType"></param>
//        /// <returns></returns>
//        private string SerializeObject<T>(T obj, HttpContentTypeEnum httpContentType)
//        {

//            // Obtém um serializador para o content type definido.
//            ISerializer serializer = SerializerFactory.Create(httpContentType.ToString());

//            // Recupera a string correspondente ao objeto serializado
//            string serializedString = serializer.SerializeObject<T>(obj);

//            return serializedString;
//        }

//    }
//}
