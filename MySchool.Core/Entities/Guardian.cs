using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Guardian
    {
        [Key]
        public int GuardianID { get; set; }
        public string FullName { get; set; }
        public string? Type{ get; set; }
        public string UserID { get; set; }
        public DateTime? GuardianDOB { get; set; }=DateTime.Now;
        public virtual ICollection<AccountStudentGuardian> AccountStudentGuardians { get; set; }
        public ICollection<Student> Students { get; set; } // Navigation Property 
    }
}