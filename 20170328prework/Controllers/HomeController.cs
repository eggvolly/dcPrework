using _20170328prework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Caching;

namespace _20170328prework.Controllers
{
    public class HomeController : Controller
    {
        private static ObjectCache _Cache = MemoryCache.Default;
        private static object _LockObj = new object();

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Search()
        {
            var cacheData = _Cache["Home"];
            var viewModel = new SearchActionModel();

            try
            {
                viewModel = cacheData as SearchActionModel;
                if(viewModel == null)
                {
                    viewModel = new SearchActionModel();
                    viewModel.Name = String.Empty;
                    viewModel.PhoneNumber = String.Empty;
                }
            }
            catch
            {
                viewModel = new SearchActionModel();
                viewModel.Name = String.Empty;
                viewModel.PhoneNumber = String.Empty;
            }


            return PartialView(viewModel);
        }

        public void GoSearch(SearchActionModel actionModel)
        {
            CacheItemPolicy cachePolicy = new CacheItemPolicy();
            cachePolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(20);

            lock (_LockObj)
            {
                _Cache.Set("Home", actionModel, cachePolicy);
            }
        }

        public ActionResult Add()
        {
            return PartialView("_Add");
        }

        public ActionResult Check()
        {
            return View();
        }

    }
}