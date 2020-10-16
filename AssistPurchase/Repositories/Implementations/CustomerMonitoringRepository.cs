using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using System.Collections.Generic;
using AssistPurchase.Repositories.FieldValidators;


namespace AssistPurchase.Repositories.Implementations
{
    public class CustomerMonitoringRepository : IMonitoringRepository
    {
        private readonly List<CustomerAlert> _alerts = new List<CustomerAlert>();
        private readonly CustomerAlertFieldValidator _validator = new CustomerAlertFieldValidator();
        public void Add(CustomerAlert alert)
        {
            _validator.ValidateCustomerAlertFields(alert);
            _alerts.Add(alert);
        }

        public IEnumerable<CustomerAlert> GetAllAlerts()
        {
            return _alerts;
        }
    }
}