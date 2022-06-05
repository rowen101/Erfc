using ERFC.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERFC.Models.Admin
{
    public class AdmWmsServerWarehouseVM
    {
        public int serverwarehouseId { get; set; }
        public int serverId { get; set; }
        public string warehousecode { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string created_by { get; set; }
        public DateTime create_date { get; set; }
        public string servername { get; set; }
        public string storageidentity { get; set; }
        public string brancode { get; set; }

    }

    public class AdmWmsServerWarehouse
    {
        public int pageCount { get; set; }
        public bool canNext { get; set; }
        public List<AdmWmsServerWarehouseVM> list { get; set; }
    }
}