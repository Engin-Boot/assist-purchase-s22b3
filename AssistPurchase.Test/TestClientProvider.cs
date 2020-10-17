using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace AssistPurchase.Test
{
    internal class TestClientProvider
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestClientProvider()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
       

    }
}