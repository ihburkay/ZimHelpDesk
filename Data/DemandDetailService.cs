using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace ZimHelpDesk.Data
{
    public class DemandDetailService
    {
        public readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DemandDetailService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        //Get All DemandDetails
        public List<DemandDetail> GetDemandDetails(int status = 0)
        {
            var detailList = _db.DemandDetails.Include(b => b.Demand).Where(s => s.Status == status).ToList();
            return detailList;
        }
        public DemandDetail GetDemandDetailById(int Id)
        {
            return _db.DemandDetails.Include(d => d.Demand).FirstOrDefault(r => r.Id == Id);

        }
        //Insert DemandDetail

        public string Create(DemandDetail detail)
        {
            _db.DemandDetails.Add(detail);
            _db.SaveChanges();
            return "Save Successfully";
        }

        // Get DemandDetail by Id
        public List<DemandDetail> GetDemandDetailsByDemandId(int id)
        {
            var details = _db.DemandDetails.Include(d=>d.Demand).Where(x => x.DemandId == id).ToList();
            return details;
        }

    }
}
