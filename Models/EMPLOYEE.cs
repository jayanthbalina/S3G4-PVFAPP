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
    
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.HAS_SKILL = new HashSet<HAS_SKILL>();
            this.WORKS_IN = new HashSet<WORKS_IN>();
        }
    
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Address { get; set; }
        public Nullable<int> Supervisor_ID { get; set; }
    
        public virtual SUPERVISOR SUPERVISOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HAS_SKILL> HAS_SKILL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WORKS_IN> WORKS_IN { get; set; }
    }
}