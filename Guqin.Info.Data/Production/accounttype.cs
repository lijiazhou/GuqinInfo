//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Guqin.Info.Data.Production
{
    using System;
    using System.Collections.Generic;
    
    public partial class accounttype
    {
        public accounttype()
        {
            this.useraccounts = new HashSet<useraccount>();
        }
    
        public int userTypeId { get; set; }
        public string userType { get; set; }
    
        public virtual ICollection<useraccount> useraccounts { get; set; }
    }
}
