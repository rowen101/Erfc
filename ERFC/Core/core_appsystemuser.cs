//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERFC.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class core_appsystemuser
    {
        public int sysId { get; set; }
        public int userId { get; set; }
        public string createdby { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
    
        public virtual core_users core_users { get; set; }
    }
}