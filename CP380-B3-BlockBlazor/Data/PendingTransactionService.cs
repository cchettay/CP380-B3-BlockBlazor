using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CP380_B1_BlockList.Models;


namespace CP380_B3_BlockBlazor.Data
{
    public class PendingTransactionService
    {

        // TODO: Add variables for the dependency-injected resources
        //       - httpClient
        //       - configuration
        //

        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //

        //
        // TODO: Add an async method that returns an IEnumerable<Payload> (list of Payloads)
        //       from the web service
        //

        //
        // TODO: Add an async method that returns an HttpResponseMessage
        //       and accepts a Payload object.
        //       This method should POST the Payload to the web API server
        //


        static HttpClient httpClient;
        private readonly IConfiguration config;
        private JsonSerializerOptions options;

        public PendingTransactionService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            httpClient = httpClientFactory.CreateClient();
            config = configuration.GetSection("PendingTransactionService");
        }
        public async Task<IList<Payload>> GetPending()
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:5000/PendingPayloads");
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions op = new(JsonSerializerDefaults.Web);
                return await JsonSerializer.DeserializeAsync<IList<Payload>>(
                    await response.Content.ReadAsStreamAsync(), options
                    );
            }
            return Array.Empty<Payload>();
        }
    }
}
