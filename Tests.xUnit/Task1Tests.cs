using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using SharedLib.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Tests.xUnit
{
    [TestCaseOrderer("Tests.xUnit.PriorityOrderer", "Tests.xUnit")]
    public class Task1Tests
    {
        private readonly TestServer _testServer;
        private readonly HttpClient _client;

        private static Guid? _testProductGuid;

        public Task1Tests()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Task1.Startup>());
            _client = _testServer.CreateClient();
        }

        [Fact, TestPriority(-5)]
        public void PostTest()
        {
            var item = new ProductCreateInputModel()
            {
                Name = "Test" + new Random(DateTime.Now.Millisecond).Next(1, 200),
                Price = Convert.ToDecimal(new Random(DateTime.Now.Millisecond).NextDouble().ToString("n2"))
            };

            var content = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/Product", stringContent).Result;

            response.EnsureSuccessStatusCode();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var productId = JsonConvert.DeserializeObject<Guid>(responseString);
            _testProductGuid = productId;
        }

        [Fact, TestPriority(-2)]
        public void GetTests()
        {
            var response = _client.GetAsync("/api/Product").Result;

            response.EnsureSuccessStatusCode();

            var responseString = response.Content.ReadAsStringAsync().Result;
            var listProducts = JsonConvert.DeserializeObject<List<ProductModel>>(responseString);
        }

        [Fact, TestPriority(2)]
        public void GetTestId()
        {
            var response = _client.GetAsync("/api/Product" + "/" + (_testProductGuid.HasValue ? _testProductGuid.Value.ToString() : new Guid().ToString())).Result;

            response.EnsureSuccessStatusCode();

            var responseString = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<ProductModel>(responseString);

        }
       
        [Fact, TestPriority(5)]
        public void PutTest()
        {
            var item = new ProductUpdateInputModel()
            {
                Id = _testProductGuid.HasValue ? _testProductGuid.Value : new Guid(),
                Name = "Test" + " Edited Name",
                Price = Convert.ToDecimal(new Random(DateTime.Now.Millisecond).NextDouble().ToString("n2"))
            };

            var content = JsonConvert.SerializeObject(item);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = _client.PutAsync("/api/Product", stringContent).Result;

            response.EnsureSuccessStatusCode();

            var responseString = response.Content.ReadAsStringAsync().Result;

            _testProductGuid = null;
        }
        
    }
}
