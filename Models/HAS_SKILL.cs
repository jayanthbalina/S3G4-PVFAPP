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
    
    public partial class HAS_SKILL
    {
        public Nullable<int> SKILL_CODE { get; set; }
        public Nullable<int> EMPLOYEE_ID { get; set; }
        public int SKILL_ID { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        public virtual SKILL SKILL { get; set; }
    }
}
