using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

using System.Net;


namespace AssistPurchase.Repositories.Implementations
{
    public class ProductManagementSqlLite:IProductRepository
    {
        public HttpStatusCode AddProduct(Product product)
        {
            var con = GetConnection();
            try
            {

                con.Open();
                if (string.IsNullOrEmpty(product.ProductName))
                {
                    return HttpStatusCode.BadRequest;
                }

                var cmd = new SQLiteCommand(con)
                {
                    CommandText =
                        @"INSERT INTO MonitoringProducts(ProductId, ProductName,Description, ProductSpecificTraining, Price,SoftwareUpdateSupport, Portability , Compact,BatterySupport,ThirdPartyDeviceSupport,SafeToFlyCertification,TouchScreenSupport,MultiPatientSupport,CyberSecurity) 
                                    VALUES
                                    (@productId, @productName,@description,@productSpecificTraining,@price,@softwareUpdateSupport,
                @portability ,@compact,@batterySupport,@thirdPartyDeviceSupport,@safeToFlyCertification,@touchScreenSupport,@multiPatientSupport,@cyberSecurity)"
                };

                cmd.Parameters.AddWithValue("@productId", product.ProductId);
                cmd.Parameters.AddWithValue("@productName", product.ProductName);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@productSpecificTraining", product.ProductSpecificTraining);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@softwareUpdateSupport", product.SoftwareUpdateSupport);
                cmd.Parameters.AddWithValue("@portability", product.Portability);
                cmd.Parameters.AddWithValue("@compact", product.Compact);
                cmd.Parameters.AddWithValue("@batterySupport", product.BatterySupport);
                cmd.Parameters.AddWithValue("@thirdPartyDeviceSupport", product.ThirdPartyDeviceSupport);
                cmd.Parameters.AddWithValue("@safeToFlyCertification", product.SafeToFlyCertification);
                cmd.Parameters.AddWithValue("@touchScreenSupportt", product.TouchScreenSupport);
                cmd.Parameters.AddWithValue("@multiPatientSupport", product.MultiPatientSupport);
                cmd.Parameters.AddWithValue("@cyberSecurity", product.CyberSecurity);

                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                con.Close();
            }
           
            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteProduct(String id)
        {
            var con = GetConnection();
            try
            {

                con.Open();
                var cmd = new SQLiteCommand(con)
                {
                    CommandText = $@"DELETE FROM MonitoringProducts WHERE Product.id='{id}'"
                };
                var rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                {
                    return HttpStatusCode.BadRequest;
                }

            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                con.Close();
            }

            return HttpStatusCode.OK;
        }


        public IEnumerable<Product> GetAllProducts()
        {

            var con = GetConnection();
            con.Open();
            var list = new List<Product>();
            var stm = @"SELECT p.ProductId, p.ProductName,p.Description, p.ProductSpecificTraining, p.Price,p.SoftwareUpdateSupport,p.Portability , p.Compact,p.BatterySupport,p.ThirdPartyDeviceSupport,p.SafeToFlyCertification,p.TouchScreenSupport,p.MultiPatientSupport,p.CyberSecurity FROM MonitoringProducts p";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Product()
                {
                    ProductId = rdr.GetString(0),
                    ProductName = rdr.GetString(1),
                    Description=rdr.GetString(2),
                    ProductSpecificTraining=rdr.GetBoolean(3),
                    Price= rdr.GetString(4),
                    SoftwareUpdateSupport= rdr.GetBoolean(5),
                    Portability = rdr.GetBoolean(6),
                    Compact = rdr.GetBoolean(7),
                    BatterySupport = rdr.GetBoolean(8),
                    ThirdPartyDeviceSupport = rdr.GetBoolean(9),
                    SafeToFlyCertification = rdr.GetBoolean(10),
                    TouchScreenSupport = rdr.GetBoolean(11),
                    MultiPatientSupport = rdr.GetBoolean(12),
                    CyberSecurity = rdr.GetBoolean(13) 
                });
            }
            con.Close();
            return list;
        }

        public IEnumerable<Product> GetProductById(String productId)
        {

            var con = GetConnection();
            con.Open();
            var list = new List<Product>();


            var stm = $@"SELECT ProductName,Description, ProductSpecificTraining, Price,SoftwareUpdateSupport, Portability , Compact,BatterySupport,ThirdPartyDeviceSupport,SafeToFlyCertification,TouchScreenSupport,MultiPatientSupport,CyberSecurity FROM MonitoringProducts WHERE ProductId= '{productId}'";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();

            while (rdr.Read())
            {
                var prodName = rdr.GetString(1);
               
                list.Add(new Product()
                {
                    ProductName = rdr.GetString(0),
                    Description = rdr.GetString(1),
                    ProductSpecificTraining = rdr.GetBoolean(2),
                    Price = rdr.GetString(3),
                    SoftwareUpdateSupport = rdr.GetBoolean(4),
                    Portability = rdr.GetBoolean(5),
                    Compact = rdr.GetBoolean(6),
                    BatterySupport = rdr.GetBoolean(7),
                    ThirdPartyDeviceSupport = rdr.GetBoolean(8),
                    SafeToFlyCertification = rdr.GetBoolean(9),
                    TouchScreenSupport = rdr.GetBoolean(10),
                    MultiPatientSupport = rdr.GetBoolean(11),
                    CyberSecurity = rdr.GetBoolean(12)
                });
            }
            con.Close();
            return list;
        }
        public HttpStatusCode UpdateProduct(String id,Product product)
        {

            var removeStatusCode = DeleteProduct(id);
            var addStatusCode = AddProduct(product);
            if (removeStatusCode == HttpStatusCode.OK && addStatusCode == HttpStatusCode.OK)
                return HttpStatusCode.OK;

            return HttpStatusCode.InternalServerError;
        }

        private static SQLiteConnection GetConnection()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var cs = $@"URI=file:{Path.GetFullPath(Path.Combine(path!, @"..\..\..\"))}ProductInfo.db";
            var con = new SQLiteConnection(cs);
            return con;
        }
    }
}

