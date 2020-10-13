
using System.Collections.Generic;


namespace AssistPurchase.Models
{
    public class MeasurementSpecificationDataModel
    {
       
        public  IEnumerable<string> BasicVitalsMeasured { get; set; }
        public MeasurementSpecificationDataModel(IEnumerable<string> vitals)
        {
            BasicVitalsMeasured = vitals;
        }

        public MeasurementSpecificationDataModel()
        {

        }
    }
}
