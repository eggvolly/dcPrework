using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Printing;
using System.Diagnostics;
using _20170328prework.Reports;
using _20170328prework.Database;
using Microsoft.Reporting.WebForms;
using _20170328prework.Models;

namespace _20170328prework.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportPrint()
        {
            //var db = new HomePageEntities();
            //var entityList = db.ForumArticle.ToList();

            //IList<ReportModel> reportList = new List<ReportModel>();
            //foreach (var item in entityList)
            //{
            //    var tmp = new ReportModel();
            //    tmp.RecId = item.RecId.ToString();
            //    tmp.Subject = item.Subject;
            //    tmp.LikeCount = item.LikeCount.Value;

            //    reportList.Add(tmp);
            //}

            IList<ReportModel> reportList = new List<ReportModel>();
            reportList.Add(new ReportModel()
            {
                RecId = "1",
                Subject = "Test",
                LikeCount = 20
            });

            reportList.Add(new ReportModel()
            {
                RecId = "2",
                Subject = "Test2",
                LikeCount = 10
            });

            reportList.Add(new ReportModel()
            {
                RecId = "3",
                Subject = "Test3",
                LikeCount = 24
            });

            try
            {
                var result = new service.Report(Server.MapPath("~/Reports/Report1.rdlc"), "test", reportList, service.Report.Type.PDF);
                return File(result.Content, result.MimeType);
            }
            catch
            {
                throw;
            }


        }

    }
}