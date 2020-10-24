
using AssistPurchase.Models;
using System.Collections.Generic;
using AssistPurchase.Repositories.Abstractions;
using AssistPurchase.Repositories.FieldValidators;

namespace AssistPurchase.Repositories.Implementations
{
    public class ProductFiltersRepository : IFiltersRepository
    {
        private readonly ProductDbRepository _repo = new ProductDbRepository();
        private readonly CustomerAlertFieldValidator _validator = new CustomerAlertFieldValidator();
        public IEnumerable<Product> GetByCompactFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.Compact.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetAll()
        {
            return _repo.GetAllProducts();
        }

        public Product GetProduct(string productId)
        {
            return _repo.GetProductById(productId);
        }

        public IEnumerable<Product> GetByProductSpecificTrainingFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.ProductSpecificTraining.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public List<Product> GetByPriceFilter(string amount, string belowOrAbove)
        {
            var prodList = belowOrAbove.ToLower() == "below" ? GetBelowRateProducts(amount) : GetAboveRateProducts(amount);
            return prodList;
        }

        public IEnumerable<Product> GetBySoftwareUpdateSupportFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.SoftwareUpdateSupport.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByPortabilityFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.Portability.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByBatterySupportFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.BatterySupport.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByThirdPartyDeviceSupportFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.ThirdPartyDeviceSupport.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetBySafeToFlyCertificationFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.SafeToFlyCertification.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByTouchScreenSupportFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.TouchScreenSupport.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByMultiPatientSupportFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.MultiPatientSupport.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByCyberSecurityFilter(string filterValue)
        {
            _validator.ValidateFilterValue(filterValue);
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.CyberSecurity.ToLower() == filterValue.ToLower())
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        private List<Product> GetBelowRateProducts(string amount)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (double.Parse(amount) >= double.Parse(product.Price))
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        private List<Product> GetAboveRateProducts(string amount)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (double.Parse(amount) <= double.Parse(product.Price))
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

    }
}