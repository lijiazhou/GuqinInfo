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
    
    public partial class major
    {
        public major()
        {
            this.users = new HashSet<user>();
        }
    
        public int idMajor { get; set; }
        public string majorName { get; set; }
    
        public virtual ICollection<user> users { get; set; }
    }
}