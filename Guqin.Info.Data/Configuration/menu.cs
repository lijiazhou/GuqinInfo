//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Guqin.Info.Data.Configuration
{
    using System;
    using System.Collections.Generic;
    
    public partial class menu
    {
        public menu()
        {
            this.menu1 = new HashSet<menu>();
        }
    
        public int idMenu { get; set; }
        public string menuName { get; set; }
        public Nullable<int> submenu { get; set; }
        public string actionName { get; set; }
        public string controllerName { get; set; }
        public string @class { get; set; }
        public int itemOrder { get; set; }
        public int idProject { get; set; }
    
        public virtual ICollection<menu> menu1 { get; set; }
        public virtual menu menu2 { get; set; }
        public virtual project project { get; set; }
    }
}
