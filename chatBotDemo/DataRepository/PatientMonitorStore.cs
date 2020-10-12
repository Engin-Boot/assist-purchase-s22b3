using chatBotDemo.Models;
using chatBotDemo.Utility;
using System;
using System.Collections.Generic;


namespace chatBotDemo.DataRepository
{
    public class PatientMonitorStore : IPatientMonitorDataRepository
    {
        
        private string _csvFilePath = @"C:\Users\HP\source\repos\chatBotDemo\chatBotDemo\patientMonitor.csv";
        IFileHandler csvHandler = new CSVFileHandler();

        public bool AddPatientMonitor(PatientMonitor monitor)
        {

            bool isAdded = default(bool);
            isAdded = this.csvHandler.WriteToFile(monitor, _csvFilePath);
            return isAdded;
        }

        public IEnumerable<PatientMonitor> GetAllPatientMonitors()
        {
            var patientMonitors = this.csvHandler.ReadFile(_csvFilePath);
            return patientMonitors;
        }

        public bool RemovePatientMonitor(string id)
        {
            var isDeleted = this.csvHandler.DeleteFromFile(id, _csvFilePath);
            return isDeleted;
        }
    }
}
