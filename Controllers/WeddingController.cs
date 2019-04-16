using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{

    public class WeddingController: Controller
    {
        private WeddingPlannerContext dbContext;
        public WeddingController(WeddingPlannerContext context)
        {
            dbContext = context;
        }

        public bool IsUserInSession()
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            if(UserID is null){
                return false;
            }
            return true;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(!IsUserInSession())
                return RedirectToAction("Index", "User");
            
            List<Wedding> Wedding = dbContext.Wedding
                .Include(w => w.Guests)
                .ThenInclude(g => g.User)
                .Where(g => g.WeddingDate > DateTime.Now)
                .ToList();

            return View(Wedding);
        }

        [HttpGet("NewWedding")]
        public IActionResult NewWedding()
        {
            if(!IsUserInSession())
                return RedirectToAction("Index", "User");

            return View();
        }

        [HttpPost("NewWedding")]
        public IActionResult CreateNewWedding(NewWedding form)
        {
            if(!IsUserInSession())
                return RedirectToAction("Index", "User");

            if(ModelState.IsValid){

                int? UserID = HttpContext.Session.GetInt32("UserID");
                form.CreatedBy = (int)UserID;
                Wedding wedding = new Wedding(form);
                dbContext.Add(wedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View("NewWedding");
        }

        [HttpGet("WeddingDetail/{WeddingId}")]
        public IActionResult WeddingDetail(int WeddingId)
        {
            if(!IsUserInSession())
                return RedirectToAction("Index", "User");

            Wedding wedding = dbContext.Wedding
                .Include(w => w.Guests)
                .ThenInclude(uw => uw.User)
                .FirstOrDefault(w => w.WeddingId == WeddingId);

            return View(wedding);
        }

        [HttpGet("AttendWedding/{WeddingId}")]
        public IActionResult AttendWedding(int WeddingId)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            Guest guest = new Guest();
            guest.UserId = (int)UserID;
            guest.WeddingId = WeddingId;
            dbContext.Guest.Add(guest);
            dbContext.SaveChanges();

            return RedirectToAction("dashboard");
        }

        [HttpGet("DeleteAttendance/{WeddingId}")]
        public IActionResult DeleteAttendance(int WeddingId)
        {
            int? UserID = HttpContext.Session.GetInt32("UserID");
            Guest guest = dbContext.Guest
                .FirstOrDefault(g => g.UserId == UserID && g.WeddingId == WeddingId);

            dbContext.Remove(guest);
            dbContext.SaveChanges();

            return RedirectToAction("dashboard");
        }

        [HttpGet("DeleteWeddingProgram/{WeddingId}")]
        public IActionResult DeleteWeddingProgram(int WeddingId)
        {
            Wedding wedding = dbContext.Wedding
                .FirstOrDefault(w => w.WeddingId == WeddingId);
            dbContext.Remove(wedding);
            dbContext.SaveChanges();
            
            return RedirectToAction("dashboard");
        }
    }
}