using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistPurchase.Models;

namespace AssistPurchase.Repositories.FieldValidators
{
    public class CustomerAlertFieldValidator
    {
        private readonly CommonFieldValidator _validator = new CommonFieldValidator();
        public void ValidateCustomerAlertFields(CustomerAlert alert)
        {
            _validator.IsWhitespaceOrEmptyOrNull(alert.ProductId);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerName);
            _validator.IsWhitespaceOrEmptyOrNull(alert.PhoneNumber);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerEmailId);
            ValidateOldPatientId(alert.ProductId);
        }

        public void ValidateOldPatientId(string productId)
        {
            var products = new List<Product>();
            foreach (var product in products)
            {
                if (product.ProductId == productId)
                {
                    return;
                }
            }

            throw new Exception("Invalid data filed");
        }
    }
}
