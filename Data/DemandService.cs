using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZimHelpDesk.Data
{
    public class DemandService
    {
     
        public static  ApplicationDbContext _db;
        private static  IHttpContextAccessor _httpContextAccessor;
        public DemandService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }
        public DemandDetailService detailService = new DemandDetailService(_db, _httpContextAccessor);
        //Get All Demand of current user
        public List<Demand> GetDemandsByUser()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var demandList = _db.Demands.Where(x=>x.User.UserName==userName).ToList();
            return demandList;
        }
        public List<Demand> GetMyDemandsByStatus(int status)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var demandList = _db.Demands.Where(x => x.User.UserName == userName && x.Status==status).ToList();
            return demandList;
        }
        public List<Demand>GetAttendedDemands() {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _db.Users.FirstOrDefault(x=>x.UserName==userName);
            var demandList = _db.Demands.Where(x => x.AgentId == user.UserId).ToList();
            return demandList;
        }

        /*
         *Get All Demand by status
         */
        public List<Demand> GetAllDemands()
        {            
            var demandList = _db.Demands.Include(b=>b.User).ToList();
            return demandList;
        }
        //Insert Demand

        public string Create(Demand demand)
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _db.Users.FirstOrDefault(s=>s.UserName == userName);
            if (user == null) { 
                User obj = new User{
                    UserName = userName,
                    DepartmentId = CodeTable.Department.MANUFACTURE };
                _db.Users.Add(obj);
               _db.SaveChanges();
                demand.UserId = obj.UserId;
            }          
            else demand.UserId =user.UserId;
            _db.Demands.Add(demand);
            _db.SaveChanges();

            //create detail

          // var AdminUser = _db.Users.FirstOrDefault(x=>x.DepartmentId==CodeTable.Department.INFORMATION && x.IsAdmin==true).UserId;
            _db.DemandDetails.Add(new DemandDetail { 
                    DemandId = demand.DemandId,
                    Created = demand.Created,
                    Status =demand.Status
                });
            _db.SaveChanges();
            return "Save Successfully";
        }

        // Get Demand by Id
        public Demand GetDemandById(int id)
        {
            Demand demand = _db.Demands.FirstOrDefault(s => s.DemandId == id);
            return demand;
        }

        //Update Demand
        public string UpdateDemand (Demand demand)
        {
            _db.Demands.Update(demand);
            _db.SaveChanges();
            return "Updated Successfully";
        }

        //Delete Demand

        public string DeleteDemand(Demand demand)
        {
            _db.Demands.Remove(demand);
            _db.SaveChanges();
            return "Deleted Successfully";
        }

    }
}
