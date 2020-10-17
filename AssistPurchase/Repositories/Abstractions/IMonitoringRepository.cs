using System.Collections.Generic;
using System.Net;
using AssistPurchase.Models;
namespace AssistPurchase.Repositories.Abstractions
{
    public interface IMonitoringRepository
    {
        public void Add(CustomerAlert alert);
        public IEnumerable<CustomerAlert> GetAllAlerts();
        public void DeleteAlert(string id);
    }
}