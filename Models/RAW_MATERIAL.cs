//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RAW_MATERIAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RAW_MATERIAL()
        {
            this.SUPPLIES = new HashSet<SUPPLIES>();
            this.USES = new HashSet<USES>();
        }
    
        public int Material_ID { get; set; }
        public string Material_Name { get; set; }
        public string Material_Standard_Cost { get; set; }
        public string Unit_Of_Measure { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUPPLIES> SUPPLIES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USES> USES { get; set; }
    }
}
