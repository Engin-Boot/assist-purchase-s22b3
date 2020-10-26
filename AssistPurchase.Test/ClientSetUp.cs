using AssistPurchase.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace AssistPurchase.Test
{
    class ClientSetUp
    {
        public readonly HttpClient Client;
        public ClientSetUp()
        {
            this.Client = new TestClientProvider().Client;
        }

        public  async void SendInvalidPostRequest(CustomerAlert alert)
        {
            var content = new StringContent(JsonConvert.SerializeObject(alert), Encoding.UTF8, "application/json");
            var response = await this.Client.PostAsync("api/alert/alerts", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
