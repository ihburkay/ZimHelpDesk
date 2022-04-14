using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZimHelpDesk.Data
{
    public class UserService
    {
        public readonly  ApplicationDbContext _db;
        private  readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        //Get All DemandDetails
        public List<User> GetAllUsersByDepId(int depId)
        {
            var userlist = _db.Users.Where(x=>x.DepartmentId==depId).ToList();
            return userlist;
        }
        public List<User> GetAllUsers()
        {
            var userlist = _db.Users.Include(a=>a.Department).Where(x=>x.IsActive==true).ToList();
            return userlist;
        }
        public List<Department> GetAllDepartments()
        {
            var departments = _db.Departments.ToList() ;
            return departments;
        }
        public bool IsAdminForAttend()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var allusers = _db.Users.Where(x=>x.UserName==userName).ToList();
            var user =  _db.Users.FirstOrDefault(s=>s.UserName==userName);
            if (user.IsAdmin) return true;
            return false;
        }
        public string GetUserName() 
        { 
            return (string)_httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public void UpdateDepartmentForUser(int deptId,int userId)
        {
            var user =_db.Users.Find(userId);
            user.DepartmentId=deptId;
            _db.Users.Update(user);
            _db.SaveChanges();
        }
    }
}
