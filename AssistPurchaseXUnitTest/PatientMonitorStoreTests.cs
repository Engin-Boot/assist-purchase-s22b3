using AssistPurchase.DataRepository;
using AssistPurchase.Models;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AssistPurchaseXUnitTest
{
    public class PatientMonitorStoreTests
    {
        readonly private PatientMonitorStore _patientMonitorStore = new PatientMonitorStore();
        readonly private PatientMonitor _patientMonitor = new PatientMonitor();

        [Fact]
        public void TestAddPatientMonitorWhenDataPassedHasallFields()
        {
            string imgSrc = Directory.GetCurrentDirectory() + @"\TestingSource\demo.png";
            _patientMonitor.MonitorId = "P15";
            _patientMonitor.MonitorName = "IntelliVue1000";
            _patientMonitor.MonitorDescription = "Portable flexible";
            _patientMonitor.MonitorBatterySpecification = new BatterySpecificationDataModel(20);
            _patientMonitor.MonitorDisplaySpecification=new DisplaySpecificationDataModel(15,"1024X322");
            _patientMonitor.MonitorMeasurementsSpecification = new MeasurementSpecificationDataModel(new List<string>() { "ECG","SPO2","Respiration"});
            _patientMonitor.MonitorPhysicalSpecification = new PhysicalSpecificationDataModel(4, new ProductSizeDataModel(30, 50, 20));          
            _patientMonitor.ProductImage = new ProductImageDataModel(imgSrc);
            var isAdded = _patientMonitorStore.AddPatientMonitor(_patientMonitor);
            Assert.True(isAdded);
        }

        [Fact]
        public void TestAddPatientMonitorWhenDataPassedHasEmptyFields()
        {
            var isAdded = _patientMonitorStore.AddPatientMonitor(_patientMonitor);
            Assert.True(isAdded == false);
        }

        [Fact]
        public void TestRemovePatientMonitorWhenIdisPresent()
        {
            string id = "P15";
            var isDeleted= _patientMonitorStore.RemovePatientMonitor(id);
            Assert.True(isDeleted);
        }

        [Fact]
        public void TestRemovePatientMonitorWhenIdisNotPresent()
        {
            string id = "P105";
            var isDeleted = _patientMonitorStore.RemovePatientMonitor(id);
            Assert.True(isDeleted == false);
        }

        [Fact]
        public void TestGetAllPatientMonitors()
        {
            var patientMonitors = _patientMonitorStore.GetAllPatientMonitors();
            Assert.NotEmpty(patientMonitors);
        }

    }
}
