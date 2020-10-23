using AssistPurchase.Models;
using AssistPurchase.Repositories.Abstractions;
using System.Collections.Generic;
using AssistPurchase.Repositories.FieldValidators;
using System.Data.SQLite;

namespace AssistPurchase.Repositories.Implementations
{
    public class CustomerMonitoringRepository : IMonitoringRepository
    {
        private readonly CustomerAlertFieldValidator _validator = new CustomerAlertFieldValidator();
       

        public IEnumerable<CustomerAlert> GetAllAlerts()
        {

            var con = GetConnection();
            con.Open();
            var list = new List<CustomerAlert>();
            var stm = @"SELECT CustomerName,CustomerEmailId,ProductId,PhoneNumber FROM Customer";
            using var cmd1 = new SQLiteCommand(stm, con);
            using var rdr = cmd1.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new CustomerAlert()
                {
                  
                    CustomerName = rdr.GetString(0),
                    CustomerEmailId = rdr.GetString(1),
                    ProductId =rdr.GetString(2),
                    PhoneNumber = rdr.GetString(3)
                    
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
                    @"INSERT INTO Customer(CustomerName,CustomerEmailId,ProductId,PhoneNumber)VALUES(@customerName,@customerEmailId,@productId,@phoneNumber)"
            };

            cmd.Parameters.AddWithValue("@customerName", alert.CustomerName);
            cmd.Parameters.AddWithValue("@customerEmailId", alert.CustomerEmailId);
            cmd.Parameters.AddWithValue("@productId", alert.ProductId);
            cmd.Parameters.AddWithValue("@phoneNumber", alert.PhoneNumber);

            cmd.Prepare();
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