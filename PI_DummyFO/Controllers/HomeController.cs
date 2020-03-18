using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PI_DummyFO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public string DataHoraAtual()
        {
            return DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }
    }
}