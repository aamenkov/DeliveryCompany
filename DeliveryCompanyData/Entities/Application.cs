using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryCompanyData.Entities
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }
        public string ReceivingAddress { get; set; }
        public string ReceivingTown { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryTown { get; set; }
        public int Weight { get; set; }
        public int PhoneNumber { get; set; }
        public bool IsWorking { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        [ForeignKey("DepartmentInfoKey")]
        public Guid DepartmentId { get; set; }
    }
}
