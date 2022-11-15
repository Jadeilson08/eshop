using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Frontend.WebApp.Extensios
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType = MediaTypeHeaderValue.Parse("application/json");

        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response) where T: class
        {
            if (!response.IsSuccessStatusCode) throw new ApplicationException($"Something is wrong: {response.ReasonPhrase}");

            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data) where T: class
        {            
            var content = new StringContent(JsonSerializer.Serialize(data));

            content.Headers.ContentType = contentType;

            return await client.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient client, string url, T data) where T : class
        {
            var content = new StringContent(JsonSerializer.Serialize(data));

            content.Headers.ContentType = contentType;

            return await client.PutAsync(url, content);
        }
    }
}
