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
    
    public partial class core_audit_trail
    {
        public int Id { get; set; }
        public string module { get; set; }
        public string description { get; set; }
        public string userid { get; set; }
        public Nullable<System.DateTime> createdte { get; set; }
        public string workstation { get; set; }
        public string appname { get; set; }
    }
}
