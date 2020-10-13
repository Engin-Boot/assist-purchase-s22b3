using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;
using AssistPurchase.Models;
using Xunit;
using System.Collections.Generic;
using RestSharp.Serialization;
using Newtonsoft.Json.Linq;


namespace AssistPurchaseAutomatedTest
{
    public class PatientMonitorManagementApiTest
    {
       
        readonly RestClient _client = new RestClient("http://localhost:51964/api/PatientMonitorManagement/");

        [Fact]
        public void StatusCodeTestForAllPatientMonitorsGetApi()
        {

            RestRequest request = new RestRequest("allPatientMonitors", Method.GET);
            IRestResponse response = _client.Execute(request);
            Assert.True(response.StatusCode == (HttpStatusCode.OK));
        }

        [Fact]
        public void ContentTypeTestForAllPatientMonitorGetApi()
        {

            RestRequest request = new RestRequest("allPatientMonitors", Method.GET);
            IRestResponse response = _client.Execute(request);
            
            Assert.True(response.ContentType.Equals(ContentType.Json + "; charset=utf-8"));
        }

        [Fact]
        public void ContentTestForAllPatientMonitorGetApi()
        {

            RestRequest request = new RestRequest("allPatientMonitors", Method.GET);
            IRestResponse response = _client.Execute(request);
            var deserializer = new JsonDeserializer();
            var data = deserializer.Deserialize<List<PatientMonitor>>(response);
            //Assert.True(data.Count == 4);
            Assert.True(data[0].MonitorName == "IntelliVue");
        }

        [Fact]
        public void StatusCodeTestForNewPatientMonitorPostApi()
        {
            RestRequest request = new RestRequest("newPatientMonitor", Method.POST);
            string jsonData = @"{'monitorID':'P8','monitorName':'IntelliPhilips1000','monitorDescription':'Abcccc','monitorPhysicalSpecification':{'productWeight':2,'productSize':{'productLength':50,'productWidth':30,'productHeight':25}},'monitorDisplaySpecification':{'displaySize':40,'displayResolution':'1024X320'},'monitorMeasurementsSpecification':{'basicVitalsMeasured':['ECG','SPO2','Respiration']},'monitorBatterySpecification':{'batteryCapacity':10}}";
            request.AddParameter("application/json", JObject.Parse(jsonData), ParameterType.RequestBody);
            IRestResponse response = _client.Execute(request);
            
            Assert.True(response.StatusCode == (HttpStatusCode.OK));
        }

        [Fact]
        public void JsonFormatTestForRequestBodyFornewPatientMonitorPostApi()
        {

            RestRequest request = new RestRequest("newPatientMonitor", Method.POST);
            string jsonData = @"{'monitorID':'P8','monitorName':'IntelliPhilips1000','monitorDescription':'Abcccc','monitorPhysicalSpecification':{'productWeight':2,'productSize':{'productLength':50,'productWidth':30,'productHeight':25}},'monitorDisplaySpecification':{'displaySize':40,'displayResolution':'1024X320'},'monitorMeasurementsSpecification':{'basicVitalsMeasured':['ECG','SPO2','Respiration']},'monitorBatterySpecification':{'batteryCapacity':10}}";
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            IRestResponse response = _client.Execute(request);
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Fact]
        public void TestForDeletePatientMonitorApiWhenGivenIDisPresent()
        {
            string id = "P8";
            RestRequest request = new RestRequest("deletePatientMonitor/"+id, Method.DELETE);
            IRestResponse response = _client.Execute(request);
            
            Assert.True(response.StatusCode == HttpStatusCode.OK);

            Assert.True(response.Content.Trim('"').Equals("Patient monitor deleted successfully"));
        }

        [Fact]
        public void TestForDeletePatientMonitorApiWhenGivenIDisNotPresent()
        {
            string id = "P11";
            RestRequest request = new RestRequest("deletePatientMonitor/" + id, Method.DELETE);
            IRestResponse response = _client.Execute(request);
            
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.True(response.Content.Trim('"').Equals("Patient monitor deletion failed"));
        }

        [Fact]
        public void TestForDeletePatientMonitorApiWhenIDisEmpty()
        {
          
            RestRequest request = new RestRequest("deletePatientMonitor/" , Method.DELETE);
            IRestResponse response = _client.Execute(request);
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
