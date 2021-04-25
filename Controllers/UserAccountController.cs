using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using teamfb.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace teamfb.Controllers
{
    public class UserAccountController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();
        
        //TODO remove after we finish auth testing
        // GET: UserAccount
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["Email"]!=null)
            {
                ViewBag.Name = Session["Email"];
                return View(db.UserAccount.ToList());
            }
            else
            {
                return View();
            }
            
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel newmodel)
        {
            var userAccounts = db.UserAccount.ToList();
            int index = userAccounts.FindIndex(f => f.UserName == newmodel.Email);
            if(index == -1)
            {
                return View(newmodel);
            }
            else
            {

                var UserAccount = userAccounts[index];
                
                if(newmodel.Password == UserAccount.Password)
                {
                    Session["Password"] = newmodel.Password.ToString();
                    Session["Email"] = newmodel.Email.ToString();
                    Session["ID"] = UserAccount.BusinessAcountID;
                    return RedirectToAction("Index");
                }

            }
            
            return View(newmodel); 
        }
        
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
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