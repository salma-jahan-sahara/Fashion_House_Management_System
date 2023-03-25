using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fashion_House_Management_System.DataAccess_Layer
{
    class WareHouseDataAccess: DataAccessLayer
    {
        public int phone;
        public List<WareHouse> GetWareHouses()
        {
            string sql = "SELECT * FROM WareHouses";
            SqlDataReader reader = this.GetData(sql);
            List<WareHouse> wareHouses = new List<WareHouse>();
            while (reader.Read())
            {
                WareHouse wareHouse = new WareHouse();
                wareHouse.WId = Convert.ToInt32(reader["WId"]);
                wareHouse.WarehouseName = reader["WarehouseName"].ToString();
                wareHouse.Location = reader["Location"].ToString();
                wareHouse.Phone = Convert.ToInt32(reader["Phone"]);
                wareHouses.Add(wareHouse);
            }
            return wareHouses;
        }
        public WareHouse GetWareHouse(int id) 
        {
            string sql = "SELECT * FROM WareHouses WHERE WId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                WareHouse wareHouse = new WareHouse();
                wareHouse.WId = Convert.ToInt32(reader["WId"]);
                wareHouse.WarehouseName = reader["WarehouseName"].ToString();
                wareHouse.Location = reader["Location"].ToString();
                wareHouse.Phone = Convert.ToInt32(reader["Phone"]);

                return wareHouse;
            }
            return null;
        }
        public int AddWareHouse(WareHouse wareHouse)
        {
            try
            {
                phone = Convert.ToInt32(wareHouse.Phone);
            }
            catch
            {
                MessageBox.Show("Enter Phone number in correct format !!");
            }
            string sql = "INSERT INTO WareHouses(WarehouseName,Location,Phone) VALUES('" + wareHouse.WarehouseName + "', '"+wareHouse.Location+"', "+phone+")";
            return this.ExecuteQuery(sql);
            
        }
       
        public int UpdateWareHouse(WareHouse wareHouse)
        {
            string sql = "UPDATE WareHouses SET WarehouseName='" + wareHouse.WarehouseName + "',Location='" + wareHouse.Location + "', Phone='" + wareHouse.Phone + "' WHERE WID=" + +wareHouse.WId;
            return this.ExecuteQuery(sql);
            
        }
        public int DeleteWareHouse(int id)
        {
            string sql = "DELETE FROM WareHouses WHERE WId=" + id;
            return this.ExecuteQuery(sql);
        }
        
        public int GetWareHouseId(string name)
        {
            string sql = "SELECT WId FROM WareHouses WHERE WareHouseName='" + name + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["WId"]);
            }
            return -1;
        }
        public List<string> GetWareHouseNames()
        {
            string sql = "SELECT WarehouseName FROM WareHouses";
            SqlDataReader reader = this.GetData(sql);
            List<string> wareHouseNames = new List<string>();
            while (reader.Read())
            {
                wareHouseNames.Add(reader["WarehouseName"].ToString());
            }
            return wareHouseNames;
        }
    }
}
