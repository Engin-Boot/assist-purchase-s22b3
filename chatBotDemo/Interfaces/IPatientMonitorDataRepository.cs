using System.Collections.Generic;


namespace chatBotDemo.Models
{
   public interface IPatientMonitorDataRepository
    {
        IEnumerable<PatientMonitor> GetAllPatientMonitors();
        bool AddPatientMonitor(PatientMonitor monitor);
        bool RemovePatientMonitor(string id);
    }
}
