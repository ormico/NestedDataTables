﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nestedDataTables.Web.Controllers
{
    public class ExamplesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStates()
        {
            return Json(State.Get(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCounties(string StateID)
        {
            return Json
            (
                (
                from s in State.Get()
                from c in s.Counties
                where s.StateID == StateID
                select new CountyModel(s.StateID, c)
                ).ToList()
            );
        }

        public ActionResult GetCities(string StateID, string CountyName)
        {
            return Json
            (
                (
                    from s in State.Get()
                    from c in s.Counties
                    from cty in c.Cities
                    where s.StateID == StateID && c.Name == CountyName
                    select new CityModel(s.StateID, c.Name, cty)
                ).ToList()
            );
        }
    }
}