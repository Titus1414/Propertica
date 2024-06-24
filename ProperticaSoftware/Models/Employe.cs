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
    
    public partial class Employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employe()
        {
            this.Attendences = new HashSet<Attendence>();
            this.AttendenceRecords = new HashSet<AttendenceRecord>();
            this.Recipts = new HashSet<Recipt>();
            this.Salaries = new HashSet<Salary>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Uid { get; set; }
        public Nullable<int> Did { get; set; }
        public Nullable<int> Dsid { get; set; }
        public Nullable<int> Atid { get; set; }
        public Nullable<int> Atrid { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string CNIC { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Landline { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public string Picture { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendence> Attendences { get; set; }
        public virtual Attendence Attendence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendenceRecord> AttendenceRecords { get; set; }
        public virtual AttendenceRecord AttendenceRecord { get; set; }
        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recipt> Recipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}