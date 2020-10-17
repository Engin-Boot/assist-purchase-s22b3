using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AssistPurchase.Test
{
    public class ClientSetUp
    {
        public HttpClient Client;
        public ClientSetUp()
        {
            this.Client = new TestClientProvider().Client;
        }
    }
    public class ProductDatabaseController
    {
        public class ClientSetUp
        {
            public HttpClient Client;
            public ClientSetUp()
            {
                this.Client = new TestClientProvider().Client;
            }
        }
            [Fact]
        public async Task CheckStatusCodeEqualOKGetAllProducts()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("api/ProductsDatabase/products");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
