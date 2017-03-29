using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Printing;
using System.Diagnostics;

namespace _20170328prework.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index()
        {
            return View();
        }


        //private void SendToPrinter()
        //{
        //    ProcessStartInfo info = new ProcessStartInfo();
        //    info.Verb = "print";
        //    info.FileName = @"c:\output.pdf";
        //    info.CreateNoWindow = true;
        //    info.WindowStyle = ProcessWindowStyle.Hidden;

        //    Process p = new Process();
        //    p.StartInfo = info;
        //    p.Start();

        //    p.WaitForInputIdle();
        //    System.Threading.Thread.Sleep(3000);
        //    if (false == p.CloseMainWindow())
        //        p.Kill();
        //}
    }
}