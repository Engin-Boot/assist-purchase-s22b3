using System;
using System.Collections.Generic;
using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using AssistPurchase.Repositories.FieldValidators;

namespace AssistPurchase.Repositories.Implementations
{
    public class ProductDbRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly ProductFieldsValidator _validator = new ProductFieldsValidator();

        public void AddProduct(Product newState)
        {
            _validator.ValidateNewProductId(newState.ProductId, newState, _products);
            _products.Add(newState);
        }
        public void DeleteProduct(string productId)
        {
           
            for (var i = 0; i < _products.Count; i++)
            {
                if (_products[i].ProductId == productId)
                {
                    _products.Remove(_products[i]);
                    return;
                }
            }
            throw new Exception("Invalid data field");
        }
        public void UpdateProduct(string productId, Product state)
        {
            _validator.ValidateProductFields(state);
            for (var i = 0; i < _products.Count; i++)
            {
                if (_products[i].ProductId == productId)
                {
                    _products.Insert(i, state);
                    return;
                }
            }
            throw new Exception("Invalid data field");
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(string productId)
        {
            foreach (var product in _products)
            {
                if (product.ProductId == productId)
                {
                    return product;
                }
            }
            throw new Exception("Invalid data field");
        }
    }
}