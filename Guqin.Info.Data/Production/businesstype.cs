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
    
    public partial class businesstype
    {
        public businesstype()
        {
            this.businesses = new HashSet<business>();
        }
    
        public int idbusinessType { get; set; }
        public string buisnessType { get; set; }
    
        public virtual ICollection<business> businesses { get; set; }
    }
}
