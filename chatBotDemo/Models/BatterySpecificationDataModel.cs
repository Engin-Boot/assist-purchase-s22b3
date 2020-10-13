
namespace AssistPurchase.Models
{
    public class BatterySpecificationDataModel
    {
        public double BatteryCapacity { get; set; }

        public BatterySpecificationDataModel(double batteryCapacity)
        {
            BatteryCapacity = batteryCapacity;
        }

        public BatterySpecificationDataModel()
        {

        }
    }
}
