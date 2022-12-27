using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookApplication.Models.Entitiy;
namespace BookApplication.Controllers
{
    public class GenderController : Controller
    {
        MvcDbLibraryEntities2 db = new MvcDbLibraryEntities2();
        // GET: Gender
        public ActionResult Index()
        {
            var values = db.TBLGENDER.ToList();
            return View(values);
        }
    }
}