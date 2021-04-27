using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teamfb.Models;
using System.Data.Entity;

namespace teamfb.Controllers
{
    public class HomeController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];

                List<Finance> query = db.Finance.SqlQuery("Select * from Finances where BusinessAcountID=@id AND ItemType='Sale'", new SqlParameter("@id", Session["ID"])).ToList();

                int[] salesPerMonth = {0,0,0,0,0,0,0,0,0,0,0,0};

                foreach(var financeitem in query)
                {
                    salesPerMonth[financeitem.DateOfTransaction.Month - 1] += financeitem.Quantity;
                }

                DashboardModel dbm = new DashboardModel();
                dbm.data.datasets.data = salesPerMonth;

                return View(dbm);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }

        }

        public ActionResult Register()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        public ActionResult Login()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }


        public ActionResult Clients()
        {
            ViewBag.Message = "Your clientele page.";

            if (Session["Email"] != null)
            {
                List<Clients> query = db.Clients.SqlQuery("Select * from Clients where BusinessAcountID=@id", new SqlParameter("@id", Session["ID"])).ToList();
                return View(query);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        [HttpPost]
        public ActionResult Clients(ClientModal cm)
        {
            string user = (string)Session["Email"];
            Clients trans = new Clients((int)Session["ID"], user, cm.FullName, cm.Date, cm.Phone, cm.Email);
            try
            {
                db.Clients.Add(trans);
                db.SaveChanges();

                return RedirectToAction("Clients", "Home");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Home");
            }

        }


        public ActionResult About()
        {
            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Welcome! Feel free to email support if you have any queries.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }
        public ActionResult Finance()
        {
            ViewBag.Message = "Your finances page.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                List<Finance> query = db.Finance.SqlQuery("Select * from Finances where BusinessAcountID=@id", new SqlParameter("@id", Session["ID"])).ToList();
                return View(query);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }
        [HttpPost]
        public ActionResult Finance(FinanceModal fm)
        {
            string user = (string)Session["Email"];
            Finance trans = new Finance((int)Session["ID"], user, fm.Quantity, fm.Date, fm.Type, fm.Description, fm.Balance);
            try
            {
                db.Finance.Add(trans);
                db.SaveChanges();    
           
                return RedirectToAction("Finance", "Home");

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Home");
            }
           
        }

        public ActionResult Statistics()
        {
            ViewBag.Message = "Your statistics page.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Your products page.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        public ActionResult Orders()
        {
            ViewBag.Message = "Your Orders page.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                List<Orders> query = db.Orders.SqlQuery("Select * from Orders where BusinessAcountID=@id", new SqlParameter("@id", Session["ID"])).ToList();
                return View(query);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }
        [HttpPost]
        public ActionResult Orders(OrderModal om)
        {
            string user = (string)Session["Email"];
            Orders trans = new Orders((int)Session["ID"], user, om.Quantity, om.DateOfTransaction, om.DateOrderDue, om.ItemType, om.Description, om.ClientEmail);
            try
            {
                db.Orders.Add(trans);
                db.SaveChanges();

                return RedirectToAction("Orders", "Home");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult Employees()
        {
            ViewBag.Message = "Your Employees page.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        public ActionResult Documents()
        {
            ViewBag.Message = "Your documents page.";

            if (Session["Email"] != null)
            {
                ViewBag.Name = Session["Email"];
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }
    }
}
