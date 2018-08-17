using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Infrastructure.CrossCuting.HttpClient;
using Infrastructure.CrossCuting.Serialization;

namespace PaymentGateway.ACL.Tests
{
    public class HttpUtilityMock : IHttpUtility
    {

        public string MockRawResponse { get; set; }
        public System.Net.HttpStatusCode MockStatusCode { get; set; }

        public HttpResponse SendHttpWebRequest(string dataToSend, HttpVerbEnum httpVerbEnum, string contentType, string accept, string serviceEndpoint, NameValueCollection headerData)
        {
            throw new NotImplementedException();
        }

        public HttpResponse<TResponse, TRequest> SubmitRequest<TRequest, TResponse>(TRequest request, string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header)
        {
            string rawRequest = this.SerializeObject<TRequest>(request, contentType);
            TResponse responseObject = this.DeserializeObject<TResponse>(MockRawResponse, contentType);
            HttpResponse<TResponse> response_ = new HttpResponse<TResponse>(responseObject, MockRawResponse, System.Net.HttpStatusCode.Created);
            HttpResponse<TResponse, TRequest> response = new HttpResponse<TResponse, TRequest>(request, rawRequest, responseObject, MockRawResponse, MockStatusCode);
            return response;
        }

        public HttpResponse<TResponse> SubmitRequest<TResponse>(string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header)
        {
            TResponse responseObject = this.DeserializeObject<TResponse>(MockRawResponse, contentType);
            HttpResponse<TResponse> response = new HttpResponse<TResponse>(responseObject, MockRawResponse, MockStatusCode);
            return response;
        }

        /// <summary>
        /// Realiza a deserialização de uma string Json ou Xml para um objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObject"></param>
        /// <param name="httpContentType"></param>
        /// <returns></returns>
        private T DeserializeObject<T>(string serializedObject, HttpContentTypeEnum httpContentType)
        {

            // Obtém um serializador para o content type definido.
            ISerializer serializer = SerializerFactory.Create(httpContentType.ToString());

            // Realiza a deserialização da string para o objeto informado
            T obj = serializer.DeserializeObject<T>(serializedObject);

            return obj;
        }

        /// <summary>
        /// Serializa um objeto para uma string Json ou Xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="httpContentType"></param>
        /// <returns></returns>
        private string SerializeObject<T>(T obj, HttpContentTypeEnum httpContentType)
        {

            // Obtém um serializador para o content type definido.
            ISerializer serializer = SerializerFactory.Create(httpContentType.ToString());

            // Recupera a string correspondente ao objeto serializado
            string serializedString = serializer.SerializeObject<T>(obj);

            return serializedString;
        }

    }
}
