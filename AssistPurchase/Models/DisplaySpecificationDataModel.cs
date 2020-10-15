

namespace AssistPurchase.Models
{
    public class DisplaySpecificationDataModel
    {
        
        public double DisplaySize { get;  set; }

        public string DisplayResolution { get;  set; }

        public DisplaySpecificationDataModel(double size,string resolution)
        {
         
            DisplaySize = size;
            DisplayResolution = resolution;
        }
        public DisplaySpecificationDataModel()
        {

        }
    }
}
