using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using System.Collections.Generic;
using AssistPurchase.Repositories.FieldValidators;
using System.Data.SQLite;

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
        public void Add(CustomerAlert alert)
        {
            _validator.ValidateCustomerAlertFields(alert);
            var con = GetConnection();
            con.Open();
            var cmd = new SQLiteCommand(con)
            {

                CommandText =
                    @"INSERT INTO Customer(CustomerId,CustomerName,CustomerEmailId,ProductId,PhoneNumber)VALUES(@customerId,@customerName,@customerEmailId,@productId,@phoneNumber)"
            };

            cmd.Parameters.AddWithValue("@customerId", alert.CustomerId);
            cmd.Parameters.AddWithValue("@customerName", alert.CustomerName);
            cmd.Parameters.AddWithValue("@customerEmailId", alert.CustomerEmailId);
            cmd.Parameters.AddWithValue("@productId", alert.ProductId);
            cmd.Parameters.AddWithValue("@phoneNumber", alert.PhoneNumber);

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            con.Close();
        
        }

        public void DeleteAlert(string id)
        {
            var customers = GetAllAlerts();
            _validator.ValidateOldCustomerId(id, customers);
            var con = GetConnection();
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText = $@"DELETE FROM Customer WHERE CustomerId='{id}'"
            };
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private static SQLiteConnection GetConnection()
        {
            var con = new SQLiteConnection(@"data source=D:\a\assist-purchase-s22b3\assist-purchase-s22b3\AssistPurchase\ProductInfo.db");
            return con;
        }
    }
}