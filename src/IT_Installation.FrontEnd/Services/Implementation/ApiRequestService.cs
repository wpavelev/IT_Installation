using Services.Interface;
using System.Text;
using System.Text.Json;

namespace Services.Implementation
{
    public class ApiRequestService : IApiRequestService
    {
        private static readonly string baseUrl = "https://localhost:44361/api";

        private readonly JsonSerializerOptions jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly IHttpClientFactory httpClientFactory;

        public ApiRequestService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<T> Request<T>(HttpMethod method, string endpoint, string? body = null)
        {
            var httpClient = this.httpClientFactory.CreateClient();

            HttpRequestMessage request = new HttpRequestMessage(method, baseUrl + endpoint);
            if (method == HttpMethod.Post && body is not null)
            {
                var bodyJson = JsonSerializer.Serialize(body);
                var content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                request.Content = content;
            }

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var resContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonSerializer.Deserialize<T>(resContent, this.jsonOptions) ?? default!;
                    return result;
                }
                catch (JsonException)
                {
                }
            }

            return default!;
        }
    }
}
