using System;
using System.Collections.Generic;
using AssistPurchase.Interfaces;
using AssistPurchase.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMonitorManagementController : ControllerBase
    {
       readonly IPatientMonitorDataRepository _patientStore;
        public PatientMonitorManagementController(IPatientMonitorDataRepository patientStore)
        {
            _patientStore = patientStore;
        }
        
        [HttpGet("allPatientMonitors")]
        public IEnumerable<PatientMonitor> Get()
        {
            return _patientStore.GetAllPatientMonitors();
        }

        [HttpGet("patientMonitor/{id}")]
        public PatientMonitor Get(string id)
        {

            var patientMonitors = _patientStore.GetAllPatientMonitors();
            foreach(var patientMonitor in patientMonitors)
            {
                if(patientMonitor.MonitorId==id)
                {
                    return patientMonitor;    
                }
               
            }
            return null;
        }

        
        [HttpPost("newPatientMonitor")]
        public string Post([FromBody] PatientMonitor patientMonitor)
        {
            bool isAdded = _patientStore.AddPatientMonitor(patientMonitor);
            string message;
            if (isAdded)
            {
                message = "Patient monitor added successfully";
            }
            else
            {
                message = "Patient monitor addition failed";
            }

            Console.WriteLine(message);
           return message;
        }

        
        [HttpDelete("deletePatientMonitor/{id}")]
        public string Delete(string id)
        {
            string message;
            bool isDeleted = _patientStore.RemovePatientMonitor(id);
            if(isDeleted)
            {
                message = "Patient monitor deleted successfully";
            }
            else
            {
                message = "Patient monitor deletion failed";
            }
            return message;
        }
    }
}
