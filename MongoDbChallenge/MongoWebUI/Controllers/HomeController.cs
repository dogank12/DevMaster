using MongoWebUI.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoWebUI.Controllers
{
    [LogActionFilter]
    public class HomeController : Controller
    {
        string  _x = "https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_databases.htm";
        private const string NEWLINE = "<br />\n";
        private const string LINKFORMAT = "<a href=\"{0}\">{1}</a> {2}";
        private readonly string _personLink = string.Format(LINKFORMAT, "Person/List/234", "Person", ""); //  " < a href=\"Person/List/234\">Person</a>";
        private readonly string _personDoganLink = string.Format(LINKFORMAT, "Person/Dogan", "Dogan", " broken; commented out in route.config"); //  "<a href=\"Person/Dogan\">Dogan</a>";
        private readonly string _homeGetCurrentTimeLink = string.Format(LINKFORMAT, "Home/CurrentTime", "GetCurrentTime", " Demonstrates Caching and Action Selector"); //  "<a href=\"Home/CurrentTime\">GetCurrentTime</a> Demonstrates Caching and Action Selector";
        private readonly string _homeIndexLink = string.Format(LINKFORMAT, "Person/Index", "Person Index", ""); //  "<a href=\"Person/Index\">Person Index</a>";
        private readonly string _homeViewLink = string.Format(LINKFORMAT, "Home/MyView", "Home MyView", ""); 

        // GET: Home
        //public ActionResult Index()
        //{
        //  return View();
        //}
        [OutputCache(Duration = 10)]
        public string Index()
        {
            List<string> _links
                = new List<string> { _personLink, _personDoganLink
                , _homeGetCurrentTimeLink, _homeIndexLink, _homeViewLink };

            string _output = "Welcome to my lair." + NEWLINE;
            foreach (var _s in _links)
            {
                _output += _s + NEWLINE;
            }

            return _output;

        }

        /// <summary>
        /// demonstrates caching for 10 secs
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 10)]
        [ActionName("CurrentTime")]
        public string GetCurrentTime()
        {
            return TimeString();
        }

        [NonAction]
        public string TimeString()
        {
            return DateTime.Now.ToString("T");
        }


        public ActionResult MyView()
        {
            return View();
        }
    }
}