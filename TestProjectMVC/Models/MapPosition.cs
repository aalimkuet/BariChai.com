using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProjectMVC.Models
{
    public class MapPosition
    {
        public decimal Latitude { get; set; }
        public  decimal Longitude { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string HouseType { get; set; }
        public string Contact { get; set; }
        
        public string UserID { get; set; }
        public string UserName { get; set; }
    }

}