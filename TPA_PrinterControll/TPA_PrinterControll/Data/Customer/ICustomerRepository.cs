using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(long id);

        List<Customer> GetAllCustomer();
        void InsertCustomer(Customer customer);

        void UpdateCustomer(Customer customer);
    }
}