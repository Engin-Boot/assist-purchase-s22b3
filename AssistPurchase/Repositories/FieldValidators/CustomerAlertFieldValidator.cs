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

       
    }
}
