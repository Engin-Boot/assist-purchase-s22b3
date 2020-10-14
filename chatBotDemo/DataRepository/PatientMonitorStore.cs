﻿using AssistPurchase.Interfaces;
using AssistPurchase.Models;
using AssistPurchase.Utility;
using System.Collections.Generic;
using System.IO;

namespace AssistPurchase.DataRepository
{
    public class PatientMonitorStore : IPatientMonitorDataRepository
    {
        readonly private string _csvFilePath = Path.Combine(Directory.GetCurrentDirectory() + "\\patientMonitor.csv");
        readonly IFileHandler _csvHandler = new CsvFileHandler();

        public bool AddPatientMonitor(PatientMonitor monitor)
        {

            bool isAdded;
            isAdded = _csvHandler.WriteToFile(monitor, _csvFilePath);
            return isAdded;
        }

        public IEnumerable<PatientMonitor> GetAllPatientMonitors()
        {
            var patientMonitors = _csvHandler.ReadFile(_csvFilePath);
            return patientMonitors;
        }

        public bool RemovePatientMonitor(string id)
        {
            var isDeleted = _csvHandler.DeleteFromFile(id, _csvFilePath);
            return isDeleted;
        }
    }
}
