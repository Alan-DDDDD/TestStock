using Newtonsoft.Json;
using System.Net.Http;

namespace Stock_Model.Models
{
    interface IDatas<T>
    {
        T? data { get; set; }
    }
    public class Datas<T> : IDatas<T>
    {
        public T? data { get { return getResponse(); } set { } }
        HttpClient _client { get; set; }
        HttpRequestMessage _request { get; set; }
        HttpMethod _method(string method)
        {
            switch (method)
            {
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "DELETE":
                    return HttpMethod.Delete;
                default:
                    return null;
            }
        }

        public Datas(string source, string method, string ApiName, string? param1 = null, string? param2 = null, string? param3 = null, string? param4 = null)
        {
            _client = new();
            _request = new(_method(method.ToUpper()), new URL(source, ApiName, param1, param2, param3, param4).Url);
            if(source == "FuGle") _client.DefaultRequestHeaders.Add("X-API-KEY", "ZjFjOTgwMWItMDc2OS00MjdmLWJkYjctZDBlYzUzMzM1ZDExIDVjYmQ1NzQ0LWY1NDQtNDU2Yi05ZTcwLTg5NmU0NjIzY2I1ZQ==");
        }
        private T? getResponse() => JsonConvert.DeserializeObject<T>(_client.SendAsync(_request).Result.Content.ReadAsStringAsync().Result);
    }
}
