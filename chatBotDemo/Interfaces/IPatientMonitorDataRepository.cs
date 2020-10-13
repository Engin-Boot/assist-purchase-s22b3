using AssistPurchase.Models;
using System.Collections.Generic;


namespace AssistPurchase.Interfaces
{
   public interface IPatientMonitorDataRepository
    {
        IEnumerable<PatientMonitor> GetAllPatientMonitors();
        bool AddPatientMonitor(PatientMonitor monitor);
        bool RemovePatientMonitor(string id);
    }
}
