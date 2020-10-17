using AssistPurchase.Models;
using System.Collections.Generic;
using System.Net;

namespace AssistPurchase.Repositories.Abstractions
{
    public interface IProductRepository
    {
        public HttpStatusCode AddProduct(Product newState);
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(string productId);
        public HttpStatusCode DeleteProduct(string productId);
      
        public HttpStatusCode UpdateProduct(string productId,Product state);
    }
}