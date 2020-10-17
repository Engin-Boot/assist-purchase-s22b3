using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using AssistPurchase.Repositories.Implementations;
using AssistPurchaseTest.Util;
using Microsoft.VisualBasic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using Xunit;
namespace AssistPurchase.Test.DatabaseTest
{
    public class ProductDatabaseSqlLiteTest
    {

        private readonly IProductRepository _productRepo;

            public ProductDatabaseSqlLiteTest()
            {
                _productRepo = new ProductDbRepository();

            }
            [Fact]
            public void TestValidProductDataAddition()
            {
             //   Thread.Sleep(100);

            string id = "X670";
              var testProd = Helper.GetProductDataModelObject(id, "Intellivue");
                Assert.True(_productRepo.AddProduct(testProd) == HttpStatusCode.OK);
            _productRepo.AddProduct(testProd);

            }
            [Fact]
            public void TestInvalidProductDataAddition()
            {
             //   Thread.Sleep(100);
                var testProd = new Product();
                Assert.True(_productRepo.AddProduct(testProd) == HttpStatusCode.BadRequest);
            }

            [Fact]
            public void TestValidProductDataRemove()
            {
               // Thread.Sleep(200);
              
            string id = "ID" ;
            var testProd = Helper.GetProductDataModelObject(id, "Intellivue");
            _productRepo.AddProduct(testProd);
                Assert.True( _productRepo.DeleteProduct(testProd.ProductId) == HttpStatusCode.OK);
            }

            [Fact]
            public void TestInvalidProductDataRemove()
            {
              //  Thread.Sleep(300);
                var testProd = Helper.GetProductDataModelObject("-999", "Test42");
                Assert.True(_productRepo.DeleteProduct(testProd.ProductId) == HttpStatusCode.BadRequest);
            }

            [Fact]
            public void TestProductDataUpdate()
            {
               // Thread.Sleep(400);
            string id = "X3";
                var testProd = Helper.GetProductDataModelObject(id, "Intellivue");
            _productRepo.AddProduct(testProd);
                testProd.SafeToFlyCertification = false;
                Assert.True(_productRepo.UpdateProduct(testProd.ProductId,testProd) == HttpStatusCode.OK);

            //Clean Up
            _productRepo.DeleteProduct(testProd.ProductId);
            }

            [Fact]
            public void TestShowAllProducts()
            {
               // Thread.Sleep(500);
                var productList = _productRepo.GetAllProducts();
                Assert.True(productList.Any());
            }

        }
    }


