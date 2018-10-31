using System.IO;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public class SqLiteCustomerRepository : SqLiteBaseRepository, ICustomerRepository
    {
        public Customer GetCustomer(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Customer result = cnn.Query<Customer>(
                    @"SELECT Id, FirstName, LastName, DateOfBirth
                    FROM Customer
                    WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }

        public List<Customer> GetAllCustomer()
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<Customer> result = cnn.Query<Customer>(
                    @"SELECT Id, FirstName, LastName, DateOfBirth
                    FROM Customer").ToList();
                return result;
            }
        }

        public void InsertCustomer(Customer customer)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                customer.ID = cnn.Query<long>(
                    @"INSERT INTO Customer 
                    ( FirstName, LastName, DateOfBirth ) VALUES 
                    ( @FirstName, @LastName, @DateOfBirth );
                    select last_insert_rowid()", customer).First();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                string sql = string.Format(@"UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, DateOfBirth =@DateOfBirth WHERE ID = @ID");

                //string sql1 = string.Format(@"UPDATE Customer SET FirstName=@FirstName, LastName=@LastName, DateOfBirth =@DateOfBirth WHERE ID = {0}", customer.ID);
                cnn.Query<long>(sql, customer);
            }
        }

        private static void CreateDatabase()
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                cnn.Execute(
                    @"create table Customer
                      (
                         ID                                  integer primary key AUTOINCREMENT,
                         FirstName                           varchar(100) not null,
                         LastName                            varchar(100) not null,
                         DateOfBirth                         datetime not null
                      )");
            }
        }
    }
}
