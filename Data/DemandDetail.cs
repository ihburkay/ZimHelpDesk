using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZimHelpDesk.Data
{
    public class DemandDetail
    {
        [Key]
        public int Id { get; set; }
        public int DemandId { get; set; }
        public Demand Demand { get; set; }
        public DateTime Created { get; set; }       
        public int Status { get; set; }
    }
}
