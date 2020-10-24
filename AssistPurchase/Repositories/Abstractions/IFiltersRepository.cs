using AssistPurchase.Models;
using System.Collections.Generic;

namespace AssistPurchase.Repositories.Abstractions
{
    public interface IFiltersRepository
    {
        public IEnumerable<Product> GetByCompactFilter(string filterValue);
        public IEnumerable<Product> GetAll();
        public Product GetProduct(string productId);
        public IEnumerable<Product> GetByProductSpecificTrainingFilter(string filterValue);
        public List<Product> GetByPriceFilter(string amount, string belowOrAbove);
        public IEnumerable<Product> GetBySoftwareUpdateSupportFilter(string filterValue);
        public IEnumerable<Product> GetByPortabilityFilter(string filterValue);
        public IEnumerable<Product> GetByBatterySupportFilter(string filterValue);
        public IEnumerable<Product> GetByThirdPartyDeviceSupportFilter(string filterValue);
        public IEnumerable<Product> GetBySafeToFlyCertificationFilter(string filterValue);
        public IEnumerable<Product> GetByTouchScreenSupportFilter(string filterValue);
        public IEnumerable<Product> GetByMultiPatientSupportFilter(string filterValue);
        public IEnumerable<Product> GetByCyberSecurityFilter(string filterValue);

    }
}