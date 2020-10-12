using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatBotDemo.Models
{
    public class DisplaySpecificationDataModel
    {
        
        public double DisplaySize { get; set; }

        public string DisplayResolution { get; set; }

        public DisplaySpecificationDataModel(double size,string resolution)
        {
         
            this.DisplaySize = size;
            this.DisplayResolution = resolution;
        }

        public DisplaySpecificationDataModel()
        {

        }
    }
}
