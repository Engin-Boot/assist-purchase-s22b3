using System;
using System.Collections.Generic;
using chatBotDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace chatBotDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientMonitorManagementController : ControllerBase
    {
        IPatientMonitorDataRepository _patientStore;
        public PatientMonitorManagementController(IPatientMonitorDataRepository patientStore)
        {
            this._patientStore = patientStore;
        }
        
        [HttpGet("allPatientMonitors")]
        public IEnumerable<PatientMonitor> Get()
        {
            return this._patientStore.GetAllPatientMonitors();
        }

        
        [HttpPost("newPatientMonitor")]
        public string Post([FromBody] PatientMonitor patientMonitor)
        {
            string message = default(string);
            bool isAdded = _patientStore.AddPatientMonitor(patientMonitor);
            if(isAdded)
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

        
        [HttpGet("deletePatientMonitor/{id}")]
        public string Delete(string id)
        {
            string message = default(string);
            bool isDeleted = this._patientStore.RemovePatientMonitor(id);
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
