using System.Net.Http;

namespace IntegrationAPI.Config.http_client_factory
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new HttpClient();
        }
    }
}
