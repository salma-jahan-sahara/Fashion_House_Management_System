using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class CustomerService
    {
        CustomerDataAccess customerDataAccess;
        public CustomerService()
        {
            this.customerDataAccess = new CustomerDataAccess();
        }

        public List<Customer> GetAllCustomers()
        {

            return this.customerDataAccess.GetCustomers();
        }
        public Customer GetCustomer(int id)
        {
            return this.customerDataAccess.GetCustomer(id);
        }

        public int AddNewCustomer(string name, int phone, string location, string joinedDate)
        {
            Customer customer = new Customer()
            {
                Name = name,
                Phone = phone,
                Location = location,
                JoinedDate = joinedDate
            };
            this.customerDataAccess = new CustomerDataAccess();
            return this.customerDataAccess.AddCustomer(customer);
        }
        public int SearchCustomer(int phone)
        {
            Customer customer = new Customer()
            {
                Phone = phone
            };
            this.customerDataAccess = new CustomerDataAccess();
            return this.customerDataAccess.SearchCustomer(customer);
        }
        public int UpdateExistingCustomer(int cId, string name, int phone, string location, string joinedDate)
        {
            Customer customer = new Customer()
            {
                CId = cId,
                Name = name,
                Phone = phone,
                Location = location,
                JoinedDate = joinedDate
            };
            this.customerDataAccess = new CustomerDataAccess();
            return this.customerDataAccess.UpdateCustomer(customer);
        }
        public int DeleteCustomer(int id)
        {
            return this.customerDataAccess.DeleteCustomer(id);
        }
    }
}
