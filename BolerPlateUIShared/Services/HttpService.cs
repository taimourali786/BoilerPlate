using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BolerPlateUIShared.Services
{
    public interface IHttpService
    {
        public Task<HttpResponseMessage> Get(string url);
        public Task<HttpResponseMessage> Post(string url, object values);
        public Task<HttpResponseMessage> Put(string url, object values);
        public Task<HttpResponseMessage> Delete(string url, object values);
    }

    public class HttpService : IHttpService 
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return sendRequest(request);
        }
        public Task<HttpResponseMessage> Post(string url, object values)
        {
            var request = createRequest(HttpMethod.Post, url, values);
            return sendRequest(request);
        }
        public Task<HttpResponseMessage> Put(string url, object values)
        {
            var request = createRequest(HttpMethod.Put, url, values);
            return sendRequest(request);
        }
        public Task<HttpResponseMessage> Delete(string url, object value)
        {
            var request  = createRequest(HttpMethod.Delete, url, value);
            return sendRequest(request);
        }

        private async Task<HttpResponseMessage> sendRequest(HttpRequestMessage requestMessage)
        {
            var response = await _httpClient.SendAsync(requestMessage);
            return response;
        }

        private HttpRequestMessage createRequest(HttpMethod method,string url, object values = null) 
        {
            var request = new HttpRequestMessage(method, url);
            if(values != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(values),Encoding.UTF8, "application/json");
            }
            return request;
        }
    }
}
