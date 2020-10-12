
namespace chatBotDemo.Models
{
    public class BatterySpecificationDataModel
    {
        public double BatteryCapacity { get; set; }

        public BatterySpecificationDataModel(double batteryCapacity)
        {
            this.BatteryCapacity = batteryCapacity;
        }

        public BatterySpecificationDataModel()
        {

        }
    }
}
