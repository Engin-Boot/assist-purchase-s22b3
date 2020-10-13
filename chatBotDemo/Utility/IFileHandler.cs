﻿using AssistPurchase.Models;
using System.Collections.Generic;

namespace AssistPurchase.Utility
{
    public interface IFileHandler
    {
        public IEnumerable<PatientMonitor> ReadFile(string filepath);
        public bool WriteToFile(PatientMonitor data,string filepath);
        public bool DeleteFromFile(string id,string filepath);

    }
}
