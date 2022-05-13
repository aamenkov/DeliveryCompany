using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompanyData.Entities
{   
    /// <summary>
    /// Класс для заявок.
    /// </summary>
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Номер заявки")]
        public Guid ApplicationId { get; set; }

        [Required]
        [MaxLength(255)]
        [Comment("Адрес, где забрать")]
        public string ReceivingAddress { get; set; }

        [MaxLength(50)]
        [Comment("Город, где забрать")]
        public string ReceivingTown { get; set; }
        
        [MaxLength(255)]
        [Comment("Адрес доставки")]
        public string DeliveryAddress { get; set; }

        [MaxLength(50)]
        [Comment("Город доставки")]
        public string DeliveryTown { get; set; }

        [Comment("Вес груза (кг)")]
        public int Weight { get; set; }

        [Comment("Длина груза (см)")]
        public int Length { get; set; }

        [Comment("Ширина груза (см)")]
        public int Width { get; set; }

        [Comment("Высота груза (см)")]
        public int Height { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Comment("Объем груза, по формуле Length * Width * Height (м^3)")]
        public double Volume
        {
            get { return (double)Length * Width * Height * 0.000001; }
            private set { ; }
        }

        [Comment("Дата и время забора груза")]
        public DateTime ReceivingDateTime;

        [MaxLength(11)]
        [Comment("Контактный номер телефона")]
        public string PhoneNumber { get; set; }

        [MaxLength(25)]
        [Comment("Статус заявки, возможные значения: 'Новая', 'Передано на выполнение', 'Выполнена', 'Отменена'")]
        public string Status { get; set; }

        [MaxLength(512)]
        [Comment("Комментарий к заказу")]
        public string Message { get; set; }

        [ForeignKey("DepartmentInfoKey")]
        [Comment("Ссылка на id-отделение")]
        public int DepartmentId { get; set; }
    }
}
