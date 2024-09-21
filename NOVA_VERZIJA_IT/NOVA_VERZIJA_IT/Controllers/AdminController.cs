using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using NOVA_VERZIJA_IT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NOVA_VERZIJA_IT.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public AdminController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult ListUsers()
        {
            var roles = _dbContext.Roles.ToList();
            var users = _dbContext.Users.ToList();

            ViewBag.UserRoles = users.ToDictionary(
            user => user.Id,
            user => user.Roles.Select(ur => roles.FirstOrDefault(r => r.Id == ur.RoleId)?.Name)
            .ToList());
        

            return View(users);
        }

        

        
    }
}