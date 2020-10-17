using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistPurchase.Models;
using AssistPurchase.Repositories.Implementations;

namespace AssistPurchase.Repositories.FieldValidators
{
    public class CustomerAlertFieldValidator
    {
        private readonly CommonFieldValidator _validator = new CommonFieldValidator();
        private readonly ProductDbRepository _repo = new ProductDbRepository();
        private readonly CustomerMonitoringRepository _customerRepo = new CustomerMonitoringRepository();
        public void ValidateCustomerAlertFields(CustomerAlert alert)
        {
            _validator.IsWhitespaceOrEmptyOrNull(alert.ProductId);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerName);
            _validator.IsWhitespaceOrEmptyOrNull(alert.PhoneNumber);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerEmailId);
            ValidateOldProductId(alert.ProductId);
        }

        public void ValidateOldProductId(string productId)
        {
            var products = _repo.GetAllProducts();
            foreach (var product in products)
            {
                if (product.ProductId == productId)
                {
                    return;
                }
            }

            throw new Exception("Invalid data filed");
        }

        public void ValidateOldCustomerId(string customerId)
        {
            var customers = _customerRepo.GetAllAlerts();
            foreach (var customer in customers)
            {
                if (customer.CustomerId == customerId)
                {
                    return;
                }
            }

            throw new Exception("Invalid data filed");
        }
    }
}
