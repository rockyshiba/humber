//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Week9_Authorization.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Programs
    {
        public Programs()
        {
            this.Instructors = new HashSet<Instructors>();
        }
    
        public int Id { get; set; }
        public string Program_name { get; set; }
        public Nullable<int> Program_head { get; set; }
    
        public virtual ICollection<Instructors> Instructors { get; set; }
        public virtual Instructors Instructors1 { get; set; }
    }
}