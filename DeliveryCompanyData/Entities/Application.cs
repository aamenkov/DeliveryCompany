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
        [MaxLength(255)]
        [Required]
        public string ReceivingAddress { get; set; }
        [MaxLength(50)]
        public string ReceivingTown { get; set; }
        [MaxLength(255)]
        public string DeliveryAddress { get; set; }
        [MaxLength(50)]
        [Required]
        public string DeliveryTown { get; set; }
        [Required]
        public int Weight { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        [Required]
        public string Status { get; set; }
        [MaxLength(512)]
        public string Message { get; set; }
        [ForeignKey("DepartmentInfoKey")]
        public Guid DepartmentId { get; set; }
    }
}
