using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using System.Collections.Generic;
using AssistPurchase.Repositories.FieldValidators;
using System.Data.SQLite;
using System.Net;
using System;

namespace AssistPurchase.Repositories.Implementations
{
    public class CustomerMonitoringRepository : IMonitoringRepository
    {
        private readonly List<CustomerAlert> _alerts = new List<CustomerAlert>();
        private readonly CustomerAlertFieldValidator _validator = new CustomerAlertFieldValidator();
       

        public IEnumerable<CustomerAlert> GetAllAlerts()
        {

            var con = GetConnection();
            con.Open();
            var list = new List<CustomerAlert>();
            var stm = @"SELECT CustomerId,CustomerName,CustomerEmailId,ProductId,PhoneNumber FROM Customer";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new CustomerAlert()
                {
                    CustomerId = rdr.GetString(0),
                    CustomerName = rdr.GetString(1),
                    CustomerEmailId = rdr.GetString(2),
                    ProductId =rdr.GetString(3),
                    PhoneNumber = rdr.GetString(4)
                    
                });
            }
            con.Close();
            return list;
        }
        public HttpStatusCode Add(CustomerAlert customer)
        {
            var con = GetConnection();
            try
            {

                con.Open();
                if (string.IsNullOrEmpty(customer.CustomerName))
                {
                    return HttpStatusCode.BadRequest;
                }
             
                var cmd = new SQLiteCommand(con)
                {

                    CommandText =
                        @"INSERT INTO Customer(CustomerId,CustomerName,CustomerEmailId,ProductId,PhoneNumber)VALUES(@customerId,@customerName,@customerEmailId,@productId,@phoneNumber)"
                };

                cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@customerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@customerEmailId", customer.CustomerEmailId);
                cmd.Parameters.AddWithValue("@productId", customer.ProductId);
                cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
 
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
                    CommandText = $@"DELETE FROM Customer WHERE CustomerId='{id}'"
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



        private static SQLiteConnection GetConnection()
        {

            //    var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //   var cs = $@"URI=file:{Path.GetFullPath(Path.Combine(path!, @"..\..\..\"))}ProductInfo.db";
            var con = new SQLiteConnection("data source = ProductInfo.db");
            return con;
        }
    }
}