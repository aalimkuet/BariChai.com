using BillingERPConn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using TestProjectMVC.Models;

namespace TestProjectMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private DBUtility dbUtility = new DBUtility();
       
        public ActionResult Index()
        {


            //return View();

          //  return RedirectToAction("SignUp", "Login");

            //if (Session["UserID"] != null)
            //{

            //}
            //else
            //{
            //    
            //}

             return View();
        }

        public JsonResult ViewHouses()
        {
            Hashtable ht = new Hashtable();

            DataTable dt = dbUtility.GetDataBySQLString("SELECT Latitude, Longitude, Phone, price, HouseType, Name, LocationDescription FROM RentalHouse left join UserMaster on RentalHouse.UserId=UserMaster.UserId");
            
            var mapPosList = new List<MapPosition>();
            
            foreach (DataRow dr in dt.Rows)
            {
                MapPosition mapPos = new MapPosition();

                mapPos.Latitude = Convert.ToDecimal( dr["Latitude"].ToString());
                mapPos.Longitude = Convert.ToDecimal(dr["Longitude"].ToString());
                mapPos.Description = dr["LocationDescription"].ToString();
                mapPos.Price = dr["Price"].ToString();
                mapPos.Contact = dr["phone"].ToString();
                mapPos.HouseType = dr["HouseType"].ToString();
                mapPos.UserName = dr["Name"].ToString();
                mapPosList.Add(mapPos);
            }

            return Json(new { MyList = mapPosList }, JsonRequestBehavior.AllowGet);
            // return Json(true , JsonRequestBehavior.AllowGet);
        }

        public ActionResult RentHouses()
        {
            var ss = Session["UserID"];

            if (ss == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //string Description, decimal lat, decimal lng
            return View();
            // return Json(true , JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GoogleMap()
        {

            //string Description, decimal lat, decimal lng
            return View();
           // return Json(true , JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult GoogleMap1(MapPosition mapPos)
        {
            Hashtable ht = new Hashtable();

           var name = Session["UserId"];
            ht.Add("Latitude", mapPos.Latitude );
            ht.Add("Longitude", mapPos.Longitude);
            ht.Add("Description", mapPos.Description);
            ht.Add("Price", mapPos.Price);
            ht.Add("Contact", mapPos.Contact);
            ht.Add("UserID", Session["UserId"]);
            ht.Add("Housetype", mapPos.HouseType);

            DataTable dd = dbUtility.GetDataByProc(ht, "sp_insertMapLocation");
            
            //string Description, decimal lat, decimal lng

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}