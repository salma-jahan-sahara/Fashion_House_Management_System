using Fashion_House_Management_System.DataAccess_Layer;
using Fashion_House_Management_System.DataAccess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion_House_Management_System.Business_Logic_Layer
{
    class WareHouseService
    {
        WareHouseDataAccess wareHouseDataAccess;
        public WareHouseService()
        {
            this.wareHouseDataAccess = new WareHouseDataAccess();
        }

        public List<WareHouse> GetAllWareHouses()
        {
            return this.wareHouseDataAccess.GetWareHouses();
        }
        public WareHouse GetWareHouse(int id)
        {
            return this.wareHouseDataAccess.GetWareHouse(id);
        }

        public int AddNewWareHouse(string wareHouseName, string location, int phone)
        {
            WareHouse wareHouse = new WareHouse()
            {
                WarehouseName = wareHouseName,
                Location = location,
                Phone = phone
            };
            this.wareHouseDataAccess = new WareHouseDataAccess();
            return this.wareHouseDataAccess.AddWareHouse(wareHouse);
        }
        
        public int UpdateExistingWareHouse(int wId, string wareHouseName, string location, int phone)
        {
            WareHouse wareHouse = new WareHouse()
            {
                WId = wId,
                WarehouseName = wareHouseName,
                Location = location,
                Phone = phone
            };
            this.wareHouseDataAccess = new WareHouseDataAccess();
            return this.wareHouseDataAccess.UpdateWareHouse(wareHouse);
        }
        
        public int DeleteWareHouse(int id)
        {
            return this.wareHouseDataAccess.DeleteWareHouse(id);
        }
        /*public int SearchWareHouse(string wareHouseName)
        {
            WareHouse wareHouse = new WareHouse() { WarehouseName = wareHouseName };
            return this.wareHouseDataAccess.SearchWareHouse(wareHouse);
        }*/
        public List<string> GetWareHouseNames()
        {
            return this.wareHouseDataAccess.GetWareHouseNames();
        }
    }
}
