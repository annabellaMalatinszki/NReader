using NReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NReaderAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await RSSParser.ParallelRSSDownloadAsync();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
