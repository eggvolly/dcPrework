using _20170328prework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20170328prework.Controllers
{
    public class ToolBarController : Controller
    {
        // GET: ToolBar
        public ActionResult ToolBar(string controllerName)
        {
            if(String.IsNullOrEmpty(controllerName))
            {
                return RedirectToAction("Index", "Home");
            }

            //TODO: 登入檢核
            var viewModel = new ToolBarViewModel();
            viewModel.ControllerName = controllerName;

            return PartialView("_ToolBar", viewModel);
        }
    }
}