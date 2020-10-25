using System;
using System.Collections.Generic;
using AssistPurchase.Models;
using AssistPurchase.Repositories.Implementations;

namespace AssistPurchase.Repositories.FieldValidators
{
    public class CustomerAlertFieldValidator
    {
        private readonly CommonFieldValidator _validator = new CommonFieldValidator();
        private readonly ProductDbRepository _repo = new ProductDbRepository();
        public void ValidateCustomerAlertFields(CustomerAlert alert)
        {
            _validator.IsWhitespaceOrEmptyOrNull(alert.ProductId);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerName);
            _validator.IsWhitespaceOrEmptyOrNull(alert.PhoneNumber);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerEmailId);
           
        }

       public void ValidateFilterValue(string filter)
        {
            if (filter.ToLower() == "true" || filter.ToLower() == "false")
            {
                return;
            }
            else
            {
                throw new Exception("Invalid data ");
            }
        }
        public void ValidAmount(string amount)
        {
            float i;
            bool result = float.TryParse(amount, out i);
            if (result == true)
            {
                return;
            }
            else
            {
                throw new Exception("Invalid amount type");
            }
        }
    }
}
