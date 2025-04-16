using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Manager
    {
        [Required]
        public int ManagerID { get; set; }

        [Required]
        public Name FullName { get; set; }

        public string UserID { get; set; } // FK to Identity user

        [Required]
        public int SchoolID { get; set; }

        public int? TenantID { get; set; }

        [JsonIgnore]
        public School School { get; set; }

        [JsonIgnore]
        public Tenant Tenant { get; set; }

    }
}