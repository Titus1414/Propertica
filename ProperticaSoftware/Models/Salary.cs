//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProperticaSoftware.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Salary
    {
        public int Id { get; set; }
        public Nullable<int> Eid { get; set; }
        public string PaidBy { get; set; }
        public Nullable<System.DateTime> PayDate { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Employe Employe { get; set; }
    }
}