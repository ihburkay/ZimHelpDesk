using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZimHelpDesk.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25,ErrorMessage ="Belirlenen Karakter sayısını aştınız")]
        public string Name { get; set; }
    }
}
