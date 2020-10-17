using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;

using System.Net;
using AssistPurchase.Repositories.FieldValidators;


namespace AssistPurchase.Repositories.Implementations
{
    public class ProductDbRepository : IProductRepository
    {
        private readonly ProductFieldsValidator _validator = new ProductFieldsValidator();
        public void AddProduct(Product product)
        {
            var products = GetAllProducts();
            _validator.ValidateNewProductId(product.ProductId, product, products);
            var con = GetConnection();
            try
            {
                con.Open();

                var cmd = new SQLiteCommand(con)
                {
                    CommandText =
                        @"INSERT INTO MonitoringProducts(ProductId,ProductName,Description,ProductSpecificTraining,Price,SoftwareUpdateSupport,Portability,Compact,BatterySupport,ThirdPartyDeviceSupport,SafeToFlyCertification,TouchScreenSupport,MultiPatientSupport,CyberSecurity) 
                      VALUES (@productId, @productName,@description,@productSpecificTraining,@price,@softwareUpdateSupport,
                              @portability ,@compact,@batterySupport,@thirdPartyDeviceSupport,@safeToFlyCertification,@touchScreenSupport,@multiPatientSupport,@cyberSecurity)"
                };

                cmd.Parameters.AddWithValue("@productId", product.ProductId);
                cmd.Parameters.AddWithValue("@productName", product.ProductName);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@productSpecificTraining", product.ProductSpecificTraining.ToString());
                cmd.Parameters.AddWithValue("@price", Convert.ToDouble(product.Price));
                cmd.Parameters.AddWithValue("@softwareUpdateSupport", product.SoftwareUpdateSupport.ToString());
                cmd.Parameters.AddWithValue("@portability", product.Portability.ToString());
                cmd.Parameters.AddWithValue("@compact", product.Compact.ToString());
                cmd.Parameters.AddWithValue("@batterySupport", product.BatterySupport.ToString());
                cmd.Parameters.AddWithValue("@thirdPartyDeviceSupport", product.ThirdPartyDeviceSupport.ToString());
                cmd.Parameters.AddWithValue("@safeToFlyCertification", product.SafeToFlyCertification.ToString());
                cmd.Parameters.AddWithValue("@touchScreenSupport", product.TouchScreenSupport.ToString());
                cmd.Parameters.AddWithValue("@multiPatientSupport", product.MultiPatientSupport.ToString());
                cmd.Parameters.AddWithValue("@cyberSecurity", product.CyberSecurity.ToString());

                cmd.Prepare();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw new Exception("Invalid data field");
            }
            finally
            {
                con.Close();
            }
        }

        public void DeleteProduct(string id)
        {
            var products = GetAllProducts();
            _validator.ValidateOldProductId(id, products);
            var con = GetConnection();
            con.Open();
            try
            {
                var cmd = new SQLiteCommand(con)
                {
                    CommandText = $@"DELETE FROM MonitoringProducts WHERE ProductId='{id}'"
                };
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Invalid data field");
            }
            finally
            {
                con.Close();
            }
        }



        public IEnumerable<Product> GetAllProducts()
        {

            var con = GetConnection();
            con.Open();
            var list = new List<Product>();
            var stm = @"SELECT p.ProductId,p.ProductName,Description,ProductSpecificTraining,Price,SoftwareUpdateSupport,Portability,Compact,BatterySupport,ThirdPartyDeviceSupport,SafeToFlyCertification,TouchScreenSupport,MultiPatientSupport,CyberSecurity FROM MonitoringProducts p";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Product()
                {
                    ProductId = rdr.GetString(0),
                    ProductName = rdr.GetString(1),
                    Description = rdr.GetString(2),
                    ProductSpecificTraining = Convert.ToBoolean(rdr.GetString(3)),
                    Price = rdr.GetDouble(4).ToString(CultureInfo.CurrentCulture),
                    SoftwareUpdateSupport = Convert.ToBoolean(rdr.GetString(5)),
                    Portability = Convert.ToBoolean(rdr.GetString(6)),
                    Compact = Convert.ToBoolean(rdr.GetString(7)),
                    BatterySupport = Convert.ToBoolean(rdr.GetString(8)),
                    ThirdPartyDeviceSupport = Convert.ToBoolean(rdr.GetString(9)),
                    SafeToFlyCertification = Convert.ToBoolean(rdr.GetString(10)),
                    TouchScreenSupport = Convert.ToBoolean(rdr.GetString(10)),
                    MultiPatientSupport = Convert.ToBoolean(rdr.GetString(11)),
                    CyberSecurity = Convert.ToBoolean(rdr.GetString(12))
                });
            }
            con.Close();
            return list;
        }

        public Product GetProductById(string productId)
        {

            var con = GetConnection();
            con.Open();


            var stm = $@"SELECT ProductId, ProductName, Description, ProductSpecificTraining, Price, SoftwareUpdateSupport, Portability , Compact, BatterySupport, ThirdPartyDeviceSupport, SafeToFlyCertification, TouchScreenSupport, MultiPatientSupport, CyberSecurity FROM MonitoringProducts WHERE ProductId= '{productId}'";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var reader = cmd1.ExecuteReader();
            var product = new Product();

            while (reader.Read())
            {
                product.ProductId = reader.GetString(0);
                product.ProductName = reader.GetString(1);
                product.Description = reader.GetString(2);
                product.ProductSpecificTraining = Convert.ToBoolean(reader.GetString(3));
                product.Price = reader.GetDouble(4).ToString(CultureInfo.CurrentCulture);
                product.SoftwareUpdateSupport = Convert.ToBoolean(reader.GetString(5));
                product.Portability = Convert.ToBoolean(reader.GetString(6));
                product.Compact = Convert.ToBoolean(reader.GetString(7));
                product.BatterySupport = Convert.ToBoolean(reader.GetString(8));
                product.ThirdPartyDeviceSupport = Convert.ToBoolean(reader.GetString(9));
                product.SafeToFlyCertification = Convert.ToBoolean(reader.GetString(10));
                product.TouchScreenSupport = Convert.ToBoolean(reader.GetString(10));
                product.MultiPatientSupport = Convert.ToBoolean(reader.GetString(11));
                product.CyberSecurity = Convert.ToBoolean(reader.GetString(12));

            }
            con.Close();
            return product;
        }
        public void UpdateProduct(string id, Product product)
        {
            var products = GetAllProducts();
            _validator.ValidateOldProductId(id, products);
            _validator.ValidateProductFields(product);
            DeleteProduct(id);
            AddProduct(product);
        }

        private static SQLiteConnection GetConnection()
        {
            var con = new SQLiteConnection(@"data source=D:\a\assist-purchase-s22b3\assist-purchase-s22b3\AssistPurchase\ProductInfo.db");
            return con;
        }

    }
}