using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERFC.Models.Admin
{
    public class AdmWmsServersVM
    {
        public int serverId { get; set; }
        public string servername { get; set; }
        public string dbname { get; set; }
        public string ipaddress { get; set; }
        public string sqluser { get; set; }
        public string sqlpass { get; set; }
        public string status { get; set; }
        public string created_by { get; set; }
        public string webaddress { get; set; }
        public DateTime create_date { get; set; }
    }

    public class AdmWmsServer
    {
        public int pageCount { get; set; }
        public bool canNext { get; set; }
        public List<AdmWmsServersVM> list { get; set; }
    }
}