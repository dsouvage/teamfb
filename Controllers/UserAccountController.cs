using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using teamfb.Models;

namespace teamfb.Controllers
{
    public class UserAccountController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();
        // GET: UserAccount
        [HttpGet]
        public ActionResult Index()
        {
            
            return View(db.UserAccount.ToList());
            
        }
        public ActionResult Verify()
        {
            return Verify();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}