using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ValuesController values = new ValuesController();
            var itemsInfo = values.GetItems();
            return View(itemsInfo);
        }

        [HttpPost]
        public ActionResult AddItem(string itemCode, string itemDesc, string itemReate)
        {
            ValuesController values = new ValuesController();
            values.PostItem(itemCode, itemDesc, itemReate);
            return View();
        }

        [HttpPost]
        public ActionResult PutItem(int id,string itemCode, string itemDesc, string itemReate)
        {
            ValuesController values = new ValuesController();
            values.PutItem(id, itemCode, itemDesc, itemReate);
            return View();
        }


        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            ValuesController values = new ValuesController();
            values.DeleteItem(id);
            return View();
        }
    }
}
