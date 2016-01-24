using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicView_Demo.Models.Helper;

namespace DynamicView_Demo.Models.View
{
    public class CustomViewEngine : IViewEngine
    {
        /// <summary>
        /// Fined view
        /// </summary>
        /// <param name="controllerContext">controller context</param>
        /// <param name="viewName">view name</param>
        /// <param name="masterName">layout view</param>
        /// <param name="useCache">use chace</param>
        /// <returns>ViewEngineResult</returns>
        public ViewEngineResult FindView(ControllerContext controllerContext,
                string viewName, string masterName, bool useCache)
        {
            var viewObj = SplitViewName(viewName);

            return new ViewEngineResult(new CustomView(viewObj.Item2, viewObj.Item1, new HtmlGeneratorHelper()), this);
        }

        /// <summary>
        /// Find partial view
        /// </summary>
        /// <param name="controllerContext">controller context</param>
        /// <param name="partialViewName">partial view name</param>
        /// <param name="useCache">use cache</param>
        /// <returns>ViewEngineResult</returns>
        public ViewEngineResult FindPartialView(ControllerContext controllerContext,
               string partialViewName, bool useCache)
        {
            var viewObj = SplitViewName(partialViewName);

            return new ViewEngineResult(new CustomView(viewObj.Item2, viewObj.Item1, new HtmlGeneratorHelper()), this);
        }

        /// <summary>
        /// Disposable view
        /// </summary>
        /// <param name="controllerContext">controller context</param>
        /// <param name="view">view</param>
        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            IDisposable disDisposable = view as IDisposable;
            if (null != disDisposable)
            {
                disDisposable.Dispose();
            }
        }

        /// <summary>
        /// Splite viewName 
        /// </summary>
        /// <param name="viewName">view name</param>
        /// <returns>pagename and id</returns>
        private Tuple<string, string> SplitViewName(string viewName)
        {
            var tmp = viewName.Split('-');
            var tuple = Tuple.Create(tmp[0], tmp[1]);

            return tuple;
        }
    }
}