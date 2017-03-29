using _20170328prework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;

namespace _20170328prework.Controllers
{
    public class TestController : Controller
    {
        private static ObjectCache _Cache = MemoryCache.Default;
        private static object _LockObj = new object();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            var cacheData = _Cache["Test"];
            var viewModel = new TestActionViewModel();

            try
            {
                viewModel = cacheData as TestActionViewModel;
                if (viewModel == null)
                {
                    viewModel = new TestActionViewModel();
                    viewModel.Test = String.Empty;
                    viewModel.PhoneNumber = String.Empty;
                }
            }
            catch
            {
                viewModel = new TestActionViewModel();
                viewModel.Test = String.Empty;
                viewModel.PhoneNumber = String.Empty;
            }


            return PartialView(viewModel);
        }

        public void GoSearch(TestActionViewModel actionModel)
        {
            CacheItemPolicy cachePolicy = new CacheItemPolicy();
            cachePolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(20);

            lock (_LockObj)
            {
                _Cache.Set("Test", actionModel, cachePolicy);
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