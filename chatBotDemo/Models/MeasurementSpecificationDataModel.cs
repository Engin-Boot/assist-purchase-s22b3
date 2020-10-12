
using System.Collections.Generic;


namespace chatBotDemo.Models
{
    public class MeasurementSpecificationDataModel
    {
       
        public  IEnumerable<string> BasicVitalsMeasured { get; set; }
        public MeasurementSpecificationDataModel(IEnumerable<string> vitals)
        {
            this.BasicVitalsMeasured = vitals;
        }

        public MeasurementSpecificationDataModel()
        {

        }
    }
}
