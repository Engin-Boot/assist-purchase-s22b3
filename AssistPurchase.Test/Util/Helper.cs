using AssistPurchase.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace AssistPurchaseTest.Util
{
    [ExcludeFromCodeCoverage]
    public static class Helper
    {
        public static Product GetProductDataModelObject(string id, string productName)
        {
            var testProduct = new Product()
            {
        ProductId= id,
        ProductName= productName,
        Description= "The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.",
        ProductSpecificTraining= false,
        Price= "14500",
        SoftwareUpdateSupport= true,
        Portability= true,
        Compact= true,
        BatterySupport= false,
        ThirdPartyDeviceSupport= true,
        SafeToFlyCertification= false,
        TouchScreenSupport= false,
        MultiPatientSupport= false,
        CyberSecurity= false
            };
    
            return testProduct;
        }
    }
}
