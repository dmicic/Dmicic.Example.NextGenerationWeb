using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NextGenWeb.UI.Controllers
{
    public class HomeController : Controller
    {
        public IBus Bus { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string term)
        {
            this.Bus.Send<Message.SearchForCommand>(x => x.Term = term);
            return this.Json(string.Empty);
        }

        public ActionResult Result()
        {
            ViewBag.Provider = string.Empty;
            if (this.Request.QueryString.AllKeys.Contains("provider"))
            {
                ViewBag.Provider = this.Request.QueryString["provider"];
                ViewBag.Provider = char.ToUpper(ViewBag.Provider[0]).ToString() + ViewBag.Provider.Substring(1);

            }
            return this.View();
        }
    }
}
