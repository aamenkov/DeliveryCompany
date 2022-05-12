using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompanyData.Entities
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Идентификатор отделения")]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        [Comment("Наименование отделения")]
        public string Name { get; set; }

        /// <summary>
        /// Коллекция заявок отделения
        /// </summary>
        public List<Application> ApplicationList { get; set; }
    }
}
