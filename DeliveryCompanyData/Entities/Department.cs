using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace DeliveryCompanyData.Entities
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DepartmentId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Town { get; set; }
        public List<Application> ApplicationList { get; set; }
    }
}
