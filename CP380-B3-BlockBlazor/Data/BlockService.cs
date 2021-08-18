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
    public class BlockService
    {
        // TODO: Add variables for the dependency-injected resources
        //       - httpClient
        //       - configuration
        //
        static HttpClient httpClient;
        private readonly IConfiguration config;
        private JsonSerializerOptions options;

        public BlockService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            httpClient = httpClientFactory.CreateClient();
            config = configuration.GetSection("BlockService");
        }
        public async Task<IList<Block>> GetBlocks()
        {
            var response = await httpClient.GetAsync(config["url"]);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions op = new(JsonSerializerDefaults.Web);
                return await JsonSerializer.DeserializeAsync<IList<Block>>(
                    await response.Content.ReadAsStreamAsync(), options
                    );

            }
            return Array.Empty<Block>();
        }
        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //

        //
        // TODO: Add an async method that returns an IEnumerable<Block> (list of Blocks)
        //       from the web service
        //

    }

}
