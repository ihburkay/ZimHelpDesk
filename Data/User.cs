using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZimHelpDesk.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int DepartmentId { get; set; }
        public bool IsAdmin { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public Department Department { get; set; }
    }
}
