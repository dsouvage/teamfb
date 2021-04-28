using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using teamfb.Models;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net;

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

                int[] salesPerMonth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] balancePerMonth = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int max = -1;
                foreach (var financeitem in query)
                {
                    salesPerMonth[financeitem.DateOfTransaction.Month - 1] += financeitem.Quantity;

                    if (salesPerMonth[financeitem.DateOfTransaction.Month - 1] > max)
                    {
                        max = salesPerMonth[financeitem.DateOfTransaction.Month - 1];
                        switch (financeitem.DateOfTransaction.Month)
                        {
                            case 1:
                                ViewBag.BestMonth = "Jan";
                                break;
                            case 2:
                                ViewBag.BestMonth = "Feb";
                                break;
                            case 3:
                                ViewBag.BestMonth = "Mar";
                                break;
                            case 4:
                                ViewBag.BestMonth = "Apr";
                                break;
                            case 5:
                                ViewBag.BestMonth = "May";
                                break;
                            case 6:
                                ViewBag.BestMonth = "Jun";
                                break;
                            case 7:
                                ViewBag.BestMonth = "Jul";
                                break;
                            case 8:
                                ViewBag.BestMonth = "Aug";
                                break;
                            case 9:
                                ViewBag.BestMonth = "Sep";
                                break;
                            case 10:
                                ViewBag.BestMonth = "Oct";
                                break;
                            case 11:
                                ViewBag.BestMonth = "Nov";
                                break;
                            case 12:
                                ViewBag.BestMonth = "Dec";
                                break;

                        }
                    }
                }

                DashboardModel dbm = new DashboardModel();
                dbm.data.datasets.data = salesPerMonth;
                List<Orders> query2 = db.Orders.SqlQuery("SELECT * FROM [dbo].[Orders] WHERE BusinessAcountID=@id", new SqlParameter("@id", Session["ID"])).ToList();

                ViewBag.count = query2.Count();

                List<Finance> query3 = db.Finance.SqlQuery("Select * from Finances where BusinessAcountID=@id", new SqlParameter("@id", Session["ID"])).ToList();
                max = -1;
                int min = 2100000000;
                foreach (var financeitem in query3)
                {
                    balancePerMonth[financeitem.DateOfTransaction.Month - 1] += financeitem.Balance;

                    if (balancePerMonth[financeitem.DateOfTransaction.Month - 1] > max)
                    {
                        max = balancePerMonth[financeitem.DateOfTransaction.Month - 1];

                        switch (financeitem.DateOfTransaction.Month)
                        {
                            case 1:
                                ViewBag.BestMonthBalance = "Jan";
                                break;
                            case 2:
                                ViewBag.BestMonthBalance = "Feb";
                                break;
                            case 3:
                                ViewBag.BestMonthBalance = "Mar";
                                break;
                            case 4:
                                ViewBag.BestMonthBalance = "Apr";
                                break;
                            case 5:
                                ViewBag.BestMonthBalance = "May";
                                break;
                            case 6:
                                ViewBag.BestMonthBalance = "Jun";
                                break;
                            case 7:
                                ViewBag.BestMonthBalance = "Jul";
                                break;
                            case 8:
                                ViewBag.BestMonthBalance = "Aug";
                                break;
                            case 9:
                                ViewBag.BestMonthBalance = "Sep";
                                break;
                            case 10:
                                ViewBag.BestMonthBalance = "Oct";
                                break;
                            case 11:
                                ViewBag.BestMonthBalance = "Nov";
                                break;
                            case 12:
                                ViewBag.BestMonthBalance = "Dec";
                                break;

                        }
                    }

                    if (balancePerMonth[financeitem.DateOfTransaction.Month - 1] < min)
                    {
                        min = balancePerMonth[financeitem.DateOfTransaction.Month - 1];

                        switch (financeitem.DateOfTransaction.Month)
                        {
                            case 1:
                                ViewBag.WorstMonthBalance = "Jan";
                                break;
                            case 2:
                                ViewBag.WorstMonthBalance = "Feb";
                                break;
                            case 3:
                                ViewBag.WorstMonthBalance = "Mar";
                                break;
                            case 4:
                                ViewBag.WorstMonthBalance = "Apr";
                                break;
                            case 5:
                                ViewBag.WorstMonthBalance = "May";
                                break;
                            case 6:
                                ViewBag.WorstMonthBalance = "Jun";
                                break;
                            case 7:
                                ViewBag.WorstMonthBalance = "Jul";
                                break;
                            case 8:
                                ViewBag.WorstMonthBalance = "Aug";
                                break;
                            case 9:
                                ViewBag.WorstMonthBalance = "Sep";
                                break;
                            case 10:
                                ViewBag.WorstMonthBalance = "Oct";
                                break;
                            case 11:
                                ViewBag.WorstMonthBalance = "Nov";
                                break;
                            case 12:
                                ViewBag.WorstMonthBalance = "Dec";
                                break;

                        }
                    }

                }

                dbm.balance = balancePerMonth;

                int summationBalance = 0;

                foreach (var financeitem in query3)
                {
                    summationBalance += financeitem.Balance;
                }

                ViewBag.sumbalance = "$";
                ViewBag.sumbalance += summationBalance.ToString();

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
            catch (Exception e)
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
                List<Document> query = db.Document.SqlQuery("Select * from Document where BusinessAcountID=@id", new SqlParameter("@id", Session["ID"])).ToList();
                return View(query);
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Documents(DocumentModal dm)
        {
            string user = (string)Session["Email"];
            

            try
            {
                Document doc = new Document();
                byte[] lol;
                using (Stream inputStream = dm.Data.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    lol = memoryStream.ToArray();
                }

                doc.data = lol;
                doc.BusinessAcountID = (int)Session["ID"];
                doc.name = dm.Data.FileName;
                
                List<Document> query = db.Document.SqlQuery("Select * from Document where BusinessAcountID=@id and name=@name", new SqlParameter("@id", Session["ID"]), new SqlParameter("@name",doc.name)).ToList();
                if (query.Count < 1)
                {
                    db.Document.SqlQuery("Insert into Document (name,data,BusinessAcountID) Values (@name,@data,@id)", new SqlParameter("@id", Session["ID"]), new SqlParameter("@name", dm.Data.FileName), new SqlParameter("@data", doc.data)).ToList();
                    //var val = db.Document.Add(doc);
                    db.SaveChanges();
                }
                else
                {
                    db.Document.SqlQuery("Update Document SET data=@data where BusinessAcountID=@id and name=@name", new SqlParameter("@id", Session["ID"]), new SqlParameter("@name", dm.Data.FileName),new SqlParameter("@data",doc.data));
                    db.SaveChanges();
                }
                
                

                return RedirectToAction("Documents", "Home");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Documents", "Home");
            }

        }

        
    }
}
