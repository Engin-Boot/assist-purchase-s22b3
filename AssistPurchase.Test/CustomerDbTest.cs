using AssistPurchase.Repositories.Abstractions;
using AssistPurchase.Repositories.Implementations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AssistPurchase.Models;
using Newtonsoft.Json;
using Xunit;

namespace AssistPurchase.Test
{
    public class CustomerDbTest
    {

        [Fact]
        public async Task CheckStatusCodeEqualOkGetAllProducts()
        {
            var setter = new ClientSetUp();
            var response = await setter.Client.GetAsync("api/alert/alerts");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsOkStatusCodeWhenAlertIsAdded()
        {
            var setter = new ClientSetUp();
            var alert = new CustomerAlert()
            {
                CustomerId = "CID03",
                CustomerName = "Venkat",
                CustomerEmailId = "venkat123@gmail.com",
                ProductId = "X3",
                PhoneNumber = "7874393847"
            };

            var content = new StringContent(JsonConvert.SerializeObject(alert), Encoding.UTF8, "application/json");
            var response = await setter.Client.PostAsync("api/alert/alerts", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task ReturnsOkAfterValidDeleteOperation()
        {
            ClientSetUp setter = new ClientSetUp();
            var response = await setter.Client.DeleteAsync("api/alert/alerts/CID03");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsBadRequestStatusCodeWhenProductIdDoesNotExist()
        {
            var setter = new ClientSetUp();
            var alert = new CustomerAlert()
            {
                CustomerId = "CID03",
                CustomerName = "Venkat",
                CustomerEmailId = "venkat123@gmail.com",
                ProductId = "AB",
                PhoneNumber = "7874393847"
            };

            var content = new StringContent(JsonConvert.SerializeObject(alert), Encoding.UTF8, "application/json");
            var response = await setter.Client.PostAsync("api/alert/alerts", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task ReturnsBadRequestWhenGivenAnInvalidCustomerId()
        {
            ClientSetUp setter = new ClientSetUp();
            var response = await setter.Client.DeleteAsync("api/alert/alerts/CID09");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
