﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFMigrationExample.DataAccess;

namespace EFMigrationExample.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataContext db = new DataContext();

            var categories = db.Categories.ToList();

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
    }
}