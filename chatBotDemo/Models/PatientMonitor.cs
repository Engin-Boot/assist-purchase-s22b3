﻿
namespace chatBotDemo.Models
{
    public class PatientMonitor
    {
        public string MonitorID { get; set; }
        public string MonitorName { get; set; }
        public string MonitorDescription { get; set; }
        public PhysicalSpecificationDataModel MonitorPhysicalSpecification { get; set; }

        public DisplaySpecificationDataModel MonitorDisplaySpecification { get; set; }

        public MeasurementSpecificationDataModel MonitorMeasurementsSpecification { get; set; }

        public BatterySpecificationDataModel MonitorBatterySpecification { get; set; }
        
        public PatientMonitor()
        {

        }
    }
}
