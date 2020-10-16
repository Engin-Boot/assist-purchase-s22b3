namespace AssistPurchase.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool ProductSpecificTraining { get; set; }
        public string Price { get; set; }
        public bool SoftwareUpdateSupport { get; set; }
        public bool Portability { get; set; }
        public bool Compact { get; set; }
        public bool BatterySupport { get; set; }
        public bool ThirdPartyDeviceSupport { get; set; }
        public bool SafeToFlyCertification { get; set; }
        public bool TouchScreenSupport { get; set; }
        public bool MultiPatientSupport { get; set; }
        public bool CyberSecurity { get; set; }

    }
}