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
    
    public partial class product
    {
        public product()
        {
            this.productphotoes = new HashSet<productphoto>();
        }
    
        public string name { get; set; }
        public System.DateTime madeTime { get; set; }
        public string deleted { get; set; }
        public int business { get; set; }
        public int stringType { get; set; }
        public int idPorduct { get; set; }
    
        public virtual business business1 { get; set; }
        public virtual stringtype stringtype1 { get; set; }
        public virtual ICollection<productphoto> productphotoes { get; set; }
    }
}
