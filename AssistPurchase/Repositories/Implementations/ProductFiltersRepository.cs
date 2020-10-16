
using AssistPurchase.Models;
using System.Collections.Generic;
using AssistPurchase.Repositories.Abstractions;

namespace AssistPurchase.Repositories.Implementations
{
    public class ProductFiltersRepository : IFiltersRepository
    {
        private readonly ProductDbRepository _repo = new ProductDbRepository();
       
        public IEnumerable<Product> GetByCompactFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.Compact == filterValue)
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

        public IEnumerable<Product> GetByProductSpecificTrainingFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.ProductSpecificTraining == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public List<Product> GetByPriceFilter(string amount, string belowOrAbove)
        {
            List<Product> prodList;
            if (belowOrAbove.ToLower() == "below")
            {
                prodList = GetBelowRateProducts(amount);
            }
            else
            {
                prodList = GetAboveRateProducts(amount);
            }

            return prodList;
        }

        public IEnumerable<Product> GetBySoftwareUpdateSupportFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.SoftwareUpdateSupport == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByPortabilityFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.Portability == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByBatterySupportFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.BatterySupport == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByThirdPartyDeviceSupportFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.ThirdPartyDeviceSupport == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetBySafeToFlyCertificationFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.SafeToFlyCertification == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByTouchScreenSupportFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.TouchScreenSupport == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByMultiPatientSupportFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.MultiPatientSupport == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public IEnumerable<Product> GetByCyberSecurityFilter(bool filterValue)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (product.CyberSecurity == filterValue)
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public List<Product> GetBelowRateProducts(string amount)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (int.Parse(amount) >= int.Parse(product.Price))
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

        public List<Product> GetAboveRateProducts(string amount)
        {
            var products = _repo.GetAllProducts();
            var prodList = new List<Product>();
            foreach (var product in products)
            {
                if (int.Parse(amount) <= int.Parse(product.Price))
                {
                    prodList.Add(product);
                }
            }

            return prodList;
        }

    }
}