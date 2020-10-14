using AssistPurchase.Models;
using AssistPurchase.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace AssistPurchaseXUnitTest
{
    public class FileDBUnitTests
    {
        private string _csvFilePath =  Directory.GetCurrentDirectory()+@"\TestingSource\patientMonitorTest.csv";
        IFileHandler csvHandler = new CsvFileHandler();

        [Fact]
        public void WhenReadFileMethodIsCalledReturnsMoniterProductData()
        {
            var patientMonitors = this.csvHandler.ReadFile(_csvFilePath);
            Assert.NotEmpty(patientMonitors);
        }

        [Fact]
        public void WhenReadFileMethodIsCalledReturnEmptyListForNotSpecifyingCorrectFilePath()
        {
            _csvFilePath = Directory.GetCurrentDirectory() + @"\patientMonitorTest1.csv";
            var patientMonitors = this.csvHandler.ReadFile(_csvFilePath);
            Assert.Empty(patientMonitors);
        }

        [Fact]
        public void WhenReadFileMethodIsCalledReturnEmptyListIfDataFormatIsIncorrect()
        {
            _csvFilePath = Directory.GetCurrentDirectory() + @"\TestingSource\patientMonitorIncorrectDataTest.csv";
            var patientMonitors = this.csvHandler.ReadFile(_csvFilePath);
            Assert.Empty(patientMonitors);
        }

        [Fact]
        public void WhenWriteToFileMethodIsCalledMonitorProductDataIsAppendedToFile()
        {
            PatientMonitor patientMonitor = new PatientMonitor();
            patientMonitor.MonitorId = "P5";
            patientMonitor.MonitorName = "XYZ";
            patientMonitor.MonitorDescription = "bfjvbdc bnv";
            patientMonitor.MonitorPhysicalSpecification = new PhysicalSpecificationDataModel(15.3, new ProductSizeDataModel(15, 17, 11));
            patientMonitor.MonitorMeasurementsSpecification = new MeasurementSpecificationDataModel(new List<string> { "ECG", " SPO2", "Respiration" });
            patientMonitor.MonitorDisplaySpecification = new DisplaySpecificationDataModel(40, "1024X348");
            patientMonitor.MonitorBatterySpecification = new BatterySpecificationDataModel(10);
            patientMonitor.ProductImage = new ProductImageDataModel(Directory.GetCurrentDirectory()+@"\TestingSource\TestImage.jpg");


            bool isAdded = this.csvHandler.WriteToFile(patientMonitor, _csvFilePath);
            Assert.True(isAdded);
        }

        [Fact]
        public void WhenNullDataIsWrittenInFileThenRetuensFalseValue()
        {
            PatientMonitor patientMonitor = new PatientMonitor();
         
            bool isAdded = this.csvHandler.WriteToFile(patientMonitor, _csvFilePath);
            Assert.False(isAdded);
        }

        [Fact]
        public void WhenDeleteFromFileMethodCalledProductIsDeletedBasedOnIdSuccess()
        {
            string id = "P5";

            var isDeleted = this.csvHandler.DeleteFromFile(id, _csvFilePath);
            Assert.True(isDeleted);
        }

        [Fact]
        public void WhenDeleteFromFileMethodCalledProductIsDeletedBasedOnIdFail()
        {
            string id = "P11";

            var isDeleted = this.csvHandler.DeleteFromFile(id, _csvFilePath);
            Assert.False(isDeleted);
        }
    }
}

