using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERFC.Models.Admin
{

    public class AdmWmsUserWarehouseAccessVM
    {
        public int userId { get; set; }
        public int serverwarehouseId { get; set; }
        public string warehousecode { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string created_by { get; set; }
    }

    public class AdmWmsUserServerWarehouseVM
    {
        public int userId { get; set; }
        public int serverwarehouseId { get; set; }
        public string username { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string created_by { get; set; }
        public DateTime create_date { get; set; }

        public string fullname { get; set; }
        public string warehousecode { get; set; }
    }

    public class AdmWmsUserServerWarehouse
    {
        public int pageCount { get; set; }
        public bool canNext { get; set; }
        public List<AdmWmsUserServerWarehouseVM> list { get; set; }
    }
}