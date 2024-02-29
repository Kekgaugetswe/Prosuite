using Microsoft.Extensions.Logging;
using Prosuite.Domain.Contracts.Interfaces.Services.Infrastructure.Utils;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosuite.Infrastructure.Utils
{
    internal class RestClientManager : IRestClientManager
    {

        ILogger<RestClientManager> logger;

        IJsonSerializationManager serializer;

        //here we initialize  logger and serializer in the constructor
        public RestClientManager(ILogger<RestClientManager> logger, IJsonSerializationManager serializer)
        {
            this.logger = logger;
            this.serializer = serializer;
        }
        // Performs a Get request to a specific URL with optonl headers and returns the deserialized response content of Type T it i a generic object
        public T Get<T>(string url, Dictionary<string, string> headers)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            request.Method = Method.Get; 
            if (headers != null && headers.Count > 0)
            {
                foreach(var header in headers)
                    request.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
                
            }
            var response = client.ExecuteAsync(request, new CancellationToken()).Result;

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                logger.LogError($"Error occurred when calling the GET URL:{url}");
                return default;
            }

            T results = serializer.Deserialize<T>(response.Content);
            return results;
        }
        // Performs a GET request to the specified URL with optional headers
        public void Get(string url, Dictionary<string, string> headers)
        {
            var baseUrl = url;
            var client = new RestClient(baseUrl);

            var request = new RestRequest();

            request.Method = Method.Get;


            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                    request.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }
            var response = client.ExecuteAsync(request, new CancellationToken()).Result;

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                logger.LogError($"Error occured when calling the GET URl:{url}");
            }
        }

        // Performs a POST request to the specified URL with data and optional headers
        public void Post(string url, object data, Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }
        // Performs a POST request to the specified URL with data and optional headers, returns deserialized response content of type T
        public T Post<T>(object data, string url, Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }
    }
}
