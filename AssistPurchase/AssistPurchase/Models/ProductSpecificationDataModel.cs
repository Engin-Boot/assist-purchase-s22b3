using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistPurchase.Models
{
    public class ProductSpecificationDataModel
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public PhysicalSpecificationDataModel PhysicalSpecification { get; set; }

        public DisplaySpecificationDataModel DisplaySpecification { get; set; }

        public MeasurementsSpecificationDataModel MeasurementsSpecification { get; set; }

        public BatterySpecificationDataModel BatterySpecification { get; set; }

    }
}
