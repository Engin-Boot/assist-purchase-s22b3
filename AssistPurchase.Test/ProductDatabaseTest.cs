using AssistPurchase.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace AssistPurchase.Test
{
    public class ClientSetUp
    {
        public readonly HttpClient Client;
        public ClientSetUp()
        {
            this.Client = new TestClientProvider().Client;
        }

        public async void SendInvalidPostRequest(CustomerAlert alert)
        {
            var content = new StringContent(JsonConvert.SerializeObject(alert), Encoding.UTF8, "application/json");
            var response = await this.Client.PostAsync("api/alert/alerts", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
    public class ProductDatabaseTest
    {
        [Fact]
        public async Task CheckStatusCodeEqualOkGetAllProducts()
        {
            var setter = new ClientSetUp();
            var response = await setter.Client.GetAsync("api/productsdatabase/products");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CheckStatusCodeEqualOkGetProductById()
        {
            ClientSetUp setter = new ClientSetUp();
            var response = await setter.Client.GetAsync("api/productsdatabase/products/X3");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsBadRequestForGettingProductWithNonExistingId()
        {
            var setter = new ClientSetUp();
            var response = await setter.Client.GetAsync("api/productsdatabase/products/XYZ");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task ReturnsOkWhenProductIsAdded()
        {
            var setter = new ClientSetUp();
            var product = new Product()
            {
               ProductId = "AB",
               ProductName = "Mock Product",
               Description = "This product is being added for testing purposes",
               Price = "100",
               Compact = true,
               Portability = true,
               SafeToFlyCertification = true,
               CyberSecurity = false,
               MultiPatientSupport = false,
               SoftwareUpdateSupport = true,
               ProductSpecificTraining = true,
               ThirdPartyDeviceSupport = false,
               BatterySupport = true,
               TouchScreenSupport = false
            };

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await setter.Client.PostAsync("api/productsdatabase/products", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task ReturnsOkAfterDeletingAValidProductRecord()
        {
            var setter = new ClientSetUp();
            var response = await setter.Client.DeleteAsync("api/productsdatabase/products/AB");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsBadRequestWhenDeletingInvalidProductId()
        {
            var setter = new ClientSetUp();
            var response = await setter.Client.DeleteAsync("api/productsdatabase/products/ZZZ");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsOkWhenProductIsUpdated()
        {
            var setter = new ClientSetUp();
            var product = new Product()
            {
                ProductId = "X3",
                ProductName = "Mock Product",
                Description = "This product is being added for testing purposes",
                Price = "100",
                Compact = true,
                Portability = false,
                SafeToFlyCertification = true,
                CyberSecurity = true,
                MultiPatientSupport = false,
                SoftwareUpdateSupport = false,
                ProductSpecificTraining = true,
                ThirdPartyDeviceSupport = false,
                BatterySupport = false,
                TouchScreenSupport = false
            };

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await setter.Client.PutAsync("api/productsdatabase/products/X3", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsBadRequestWhenAddingProductIdWhichIsAlreadyExisting()
        {
            var setter = new ClientSetUp();
            var product = new Product()
            {
                ProductId = "CM",
                ProductName = "Mock Product 2",
                Description = "This product is being added for testing purposes",
                Price = "10000",
                Compact = true,
                Portability = true,
                SafeToFlyCertification = true,
                CyberSecurity = true,
                MultiPatientSupport = true,
                SoftwareUpdateSupport = true,
                ProductSpecificTraining = false,
                ThirdPartyDeviceSupport = false,
                BatterySupport = true,
                TouchScreenSupport = true
            };

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await setter.Client.PostAsync("api/productsdatabase/products", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsBadRequestWhenUpdatingANonExistantProductId()
        {
            var setter = new ClientSetUp();
            var product = new Product()
            {
                ProductId = "ZZZ",
                ProductName = "Mock Product 3",
                Description = "This product is being added for testing purposes",
                Price = "15000",
                Compact = true,
                Portability = false,
                SafeToFlyCertification = false,
                CyberSecurity = true,
                MultiPatientSupport = true,
                SoftwareUpdateSupport = false,
                ProductSpecificTraining = true,
                ThirdPartyDeviceSupport = false,
                BatterySupport = true,
                TouchScreenSupport = false
            };

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var response = await setter.Client.PutAsync("api/productsdatabase/products/ZZZ", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }

}
