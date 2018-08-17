using System.Collections.Specialized;

namespace Infrastructure.CrossCuting.HttpClient
{
    public interface IHttpUtility
    {
        HttpResponse SendHttpWebRequest(string dataToSend, HttpVerbEnum httpVerbEnum, string contentType, string accept, string serviceEndpoint, NameValueCollection headerData);
        HttpResponse<TResponse, TRequest> SubmitRequest<TRequest, TResponse>(TRequest request, string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header);
        HttpResponse<TResponse> SubmitRequest<TResponse>(string serviceUri, HttpVerbEnum httpVerb, HttpContentTypeEnum contentType, NameValueCollection header);
    }
}