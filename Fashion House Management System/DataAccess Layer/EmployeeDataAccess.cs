using Fashion_House_Management_System.DataAccess_Layer.Entities;
using Fashion_House_Management_System.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fashion_House_Management_System.DataAccess_Layer
{
    class EmployeeDataAccess: DataAccessLayer
    {
        public int phone;
        public int salary;
        public List<Employee> GetEmployees() 
        {
            string sql = "SELECT * FROM Employees";
            SqlDataReader reader = this.GetData(sql);
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                Employee employee = new Employee();
                employee.EId = Convert.ToInt32(reader["EId"]);
                employee.Name = reader["Name"].ToString();
                employee.Username = reader["Username"].ToString();
                employee.Phone = Convert.ToInt32(reader["Phone"]);
                employee.Location = reader["Location"].ToString();
                employee.Position = reader["Position"].ToString();
                employee.Salary = Convert.ToInt32(reader["Salary"]);
                employee.JoinedDate = reader["JoinedDate"].ToString();
                employee.Branch = reader["Branch"].ToString();

                employees.Add(employee);
            }
            return employees;
        }
        public Employee GetEmployee(int id) // One cat ret
        {
            string sql = "SELECT * FROM Employees WHERE EId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Employee employee = new Employee();
                employee.EId = Convert.ToInt32(reader["EId"]);
                employee.Name = reader["Name"].ToString();
                employee.Username = reader["Username"].ToString();
                employee.Phone = Convert.ToInt32(reader["Phone"]);
                employee.Location = reader["Location"].ToString();
                employee.Position = reader["Position"].ToString();
                employee.Salary = Convert.ToInt32(reader["Salary"]);
                employee.JoinedDate = reader["JoinedDate"].ToString();
                employee.Branch = reader["Branch"].ToString();
                return employee;
            }
            return null;
        }

       
        public int AddEmployee(Employee employee)
        {
            
            try 
            {
                phone = Convert.ToInt32(employee.Phone);
            }
            catch 
            {
                MessageBox.Show("Enter Phone number in correct format !!");
            }
            try 
            {
                salary = Convert.ToInt32(employee.Salary);
            }
            catch 
            {
                MessageBox.Show("Enter salary in correct format !!"); 
            }
            string sql = "INSERT INTO Employees(Name, Username, Phone, Location, Position, Salary, JoinedDate, Branch) " +
                         "VALUES('" + employee.Name + "', '" + employee.Username + "', " + phone +
                         ", '" + employee.Location + "', '" + employee.Position + "'," + salary + ",'" + employee.JoinedDate +"','" + employee.Branch+"')";
            return this.ExecuteQuery(sql);
        }

       public int UpdateEmployee(Employee employee) 
        {
            string sql = "UPDATE Employees SET Name='" + employee.Name + "', Username='" + employee.Username 
                +"', Phone=" + employee.Phone +", Location='" + employee.Location + "', Position='" + employee.Position +"', Salary=" + employee.Salary 
                +",  Branch='" + employee.Branch+" ' WHERE EId=" + employee.EId;
            return this.ExecuteQuery(sql);
        }
        public int DeleteEmployee(int id)
        {
            string sql = "DELETE FROM Employees WHERE EId=" + id;
            return this.ExecuteQuery(sql);
        }
        public int SearchEmployee(Employee employee)
        {
            string sql = "SELECT * FROM Employees WHERE Phone = " + phone;
            return this.ExecuteQuery(sql);
        }

        public int GetEmployeeId(string name)
        {
            string sql = "SELECT EId FROM Employees WHERE EmployeeName='" + name + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["EId"]);
            }
            return -1;
        }
        public List<string> GetEmployeesNames()
        {
            string sql = "SELECT EmployeeName FROM Employees";
            SqlDataReader reader = this.GetData(sql);
            List<string> employeeNames = new List<string>();
            while (reader.Read())
            {
                employeeNames.Add(reader["EmployeeName"].ToString());
            }
            return employeeNames;
        }
    }
}
