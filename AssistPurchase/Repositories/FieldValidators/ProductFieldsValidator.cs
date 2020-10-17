using System;
using System.Collections.Generic;
using AssistPurchase.Models;

namespace AssistPurchase.Repositories.FieldValidators
{
    public class ProductFieldsValidator
    {
        private readonly CommonFieldValidator _validator = new CommonFieldValidator();
        public void ValidateProductFields(Product product)
        {
            _validator.IsWhitespaceOrEmptyOrNull(product.Price);
            _validator.IsWhitespaceOrEmptyOrNull(product.Description);
            _validator.IsWhitespaceOrEmptyOrNull(product.ProductId);
            _validator.IsWhitespaceOrEmptyOrNull(product.ProductName);
            _validator.IsWhitespaceOrEmptyOrNull(product.CyberSecurity.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.MultiPatientSupport.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.SafeToFlyCertification.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.ThirdPartyDeviceSupport.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.TouchScreenSupport.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.BatterySupport.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.ProductSpecificTraining.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.Portability.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.Compact.ToString());
            _validator.IsWhitespaceOrEmptyOrNull(product.SoftwareUpdateSupport.ToString());
        }

        public void ValidateNewProductId(string productId, Product productRecord, IEnumerable<Product> products)
        {
            
            foreach (var product in products)
            {
                if (product.ProductId == productId)
                {
                    throw new Exception("Invalid Patient Id");
                }
            }

            ValidateProductFields(productRecord);
        }
    }
}
