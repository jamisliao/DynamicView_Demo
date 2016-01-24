using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicView_Demo.Models;
using DynamicView_Demo.Models.Helper;
using DynamicView_Demo.Models.View;

namespace DynamicView_Demo.Controllers
{
    public class DynamicViewController : Controller
    {
        public ActionResult GetView(string pageName, string id)
        {
            //// remove default view engine
            this.ViewEngineCollection.Clear();

            //// add custom view engine
            this.ViewEngineCollection.Add(new CustomViewEngine());

            var view = string.Format("{0}-{1}", id, pageName);

            return View(view);
        }
    }
}