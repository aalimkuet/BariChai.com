using BillingERPConn;
using System;
using System.Collections;
using System.Data;

using System.Web.Mvc;


namespace TestProjectMVC.Controllers
{
    public class LoginController : Controller
    {

        private DBUtility dbUtility = new DBUtility();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult UserLogin(User user)
        {
            try
            {

                Hashtable ht = new Hashtable();

                ht.Add("UserId", user.UserId);
                ht.Add("password", user.password);

                DataTable dd = dbUtility.GetDataByProc(ht, "sp_insertLogin");

                if (dd.Rows[0]["Success"].ToString() != "Failed")
                {
                   /// FormsAuthentication.SetAuthCookie(user.UserId, true);
                    var userid = dd.Rows[0]["Success"].ToString();
                    
                    var aa =  dbUtility.GetDataBySQLString("Select Name from UserMaster Where UserID = '" +user.UserId+ "'");

                    Session["UserId"] = userid;
                    Session["UserName"] = aa.Rows[0]["Name"].ToString(); 
                    var ss = Session["UserId"];

                    return Json(new { str = "Sign In successful" }, JsonRequestBehavior.AllowGet);
                } 

                else
               {
                    //ViewBag.message = "Please Enter valid Credential";
                    return Json(new { str = "Please Enter valid Credential" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
               var ss= ex.Message ;
                return RedirectToAction("Index", "Login");
            }
            

            //string Description, decimal lat, decimal lng

            
        }
        
        public ActionResult SignUp()
        {

           // return RedirectToAction("RentHouses", "Home");

            //string Description, decimal lat, decimal lng

            return View();
        }
        
        public ActionResult DataSignUp(User user)
        {

            Hashtable ht = new Hashtable();

            ht.Add("UserId", user.UserId);
            ht.Add("password", user.password);
            ht.Add("UserName", user.UserName);


            DataTable dd = dbUtility.GetDataByProc(ht, "sp_insertUserSignUp");

            //return View("Index");

            return Json(new { str = dd.Rows[0]["FEEDBACK"].ToString() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }

   public class User
    {
        public string UserId { get; set; }
        public string password { get; set; }    
        public string UserName { get; set; }
    }

}