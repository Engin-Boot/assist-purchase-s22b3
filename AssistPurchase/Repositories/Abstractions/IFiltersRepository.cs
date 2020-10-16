using AssistPurchase.Models;
using System.Collections.Generic;

namespace AssistPurchase.Repositories.Abstractions
{
    public interface IFiltersRepository
    {
        public IEnumerable<Product> GetByCompactFilter(bool filterValue);
        public IEnumerable<Product> GetAll();
        public Product GetProduct(string productId);
        public IEnumerable<Product> GetByProductSpecificTrainingFilter(bool filterValue);
        public List<Product> GetByPriceFilter(string amount, string belowOrAbove);
        public IEnumerable<Product> GetBySoftwareUpdateSupportFilter(bool filterValue);
        public IEnumerable<Product> GetByPortabilityFilter(bool filterValue);
        public IEnumerable<Product> GetByBatterySupportFilter(bool filterValue);
        public IEnumerable<Product> GetByThirdPartyDeviceSupportFilter(bool filterValue);
        public IEnumerable<Product> GetBySafeToFlyCertificationFilter(bool filterValue);
        public IEnumerable<Product> GetByTouchScreenSupportFilter(bool filterValue);
        public IEnumerable<Product> GetByMultiPatientSupportFilter(bool filterValue);
        public IEnumerable<Product> GetByCyberSecurityFilter(bool filterValue);

    }
}