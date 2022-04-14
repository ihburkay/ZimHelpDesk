using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZimHelpDesk.Data
{
    public class Demand
    {
        [Key]
        public int DemandId { get; set; }
        [DisplayName("Talep Türü")]
        public int Type { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Konu")]
        public string Topic { get; set; }
        [StringLength(255,ErrorMessage ="Belirlenen karakter sayısını aştınız!")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? AgentId  { get; set; }
        public User Agent { get; set; }
        public DateTime? DeadLine { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        [DisplayName("Durum")]
        public int Status { get; set; }
        [DisplayName("Açık/Kapalı")]
        public bool IsActive { get; set; }
        [NotMapped]
        public ICollection<DemandDetail> Details { get; set; }
    }
}
