using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERFC.Models.Admin
{
    public class UserSystemModel
    {
        public int SYSID { get; set; }
        public string SYSNAME { get; set; }
        public Nullable<bool> IsCheck { get; set; }
        public List<UserMenuModel> UserMenu { get; set; }
    }
}