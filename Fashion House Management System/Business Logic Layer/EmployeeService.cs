using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class EmployeeService
    {
        EmployeeDataAccess employeeDataAccess;
        public EmployeeService()
        {
            this.employeeDataAccess = new EmployeeDataAccess();
        }

        public List<Employee> GetAllEmployees()
        {

            return this.employeeDataAccess.GetEmployees();
        }
        public Employee GetEmployee(int id)
        {
            return this.employeeDataAccess.GetEmployee(id);
        }

        public int AddNewEmployee(string name, string username, int phone, string location, string position, int salary, string branch, string joinedDate)
        {
            //CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            //int categoryId = categoryDataAccess.GetCategoryId(categoryName);

            Employee employee = new Employee()
            {
                Name = name,
                Username = username,
                Phone = phone,
                Location = location,
                Position = position,
                Salary = salary,
                Branch = branch,
                JoinedDate = joinedDate
            };
            this.employeeDataAccess = new EmployeeDataAccess();
            return this.employeeDataAccess.AddEmployee(employee);
        }
        public int UpdateExistingEmployee(int eId, string name, string username, int phone, string location, string position, int salary, string branch, string joinedDate)
        {
            Employee employee = new Employee()
            {
                EId = eId,
                Name = name,
                Username = username,
                Phone = phone,
                Location = location,
                Position = position,
                Salary = salary,
                Branch = branch,
                JoinedDate = joinedDate
            };
            this.employeeDataAccess = new EmployeeDataAccess();
            return this.employeeDataAccess.UpdateEmployee(employee);
        }
        public int DeleteEmployee(int id)
        {
            return this.employeeDataAccess.DeleteEmployee(id);
        }
        public int SearchEmployee(int phone)
        {
            Employee employee = new Employee()
            {
                Phone = phone
            };
            this.employeeDataAccess = new EmployeeDataAccess();
            return this.employeeDataAccess.SearchEmployee(employee);
        }

        /*public List<string> GetCategoryNames()
        {
            return this.employeeDataAccess.GetCategoryNames();
        }*/
    }
}
