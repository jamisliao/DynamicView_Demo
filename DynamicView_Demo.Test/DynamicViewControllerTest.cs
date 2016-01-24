using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicView_Demo.Controllers;

namespace DynamicView_Demo.Test
{
    [TestClass]
    public class DynamicViewControllerTest
    {
        [TestMethod]
        public void GetView_Test()
        {
            var pageName = "View1";
            var id = "321";

            var httpRequest = new HttpRequest("", "http://localhost/DynamicView/GetView", "");
            var httpContext = new HttpContext(httpRequest, new HttpResponse(new StringWriter()));
            var userAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.10) " +
                 "Gecko/20100914 Firefox/3.6.10";
            var browser = new HttpBrowserCapabilities
            {
                Capabilities = new Hashtable { { string.Empty, userAgent } }
            };
            var factory = new BrowserCapabilitiesFactory();
            factory.ConfigureBrowserCapabilities(new NameValueCollection(), browser);

            httpContext.Request.Browser = browser;

            var target = ControllerFactory.CreateController<DynamicViewController>(httpContext);
            var viewResult = target.GetView(pageName, id) as ViewResult;
            viewResult.ExecuteResult(target.ControllerContext);

            var expected = string.Format("<div>I am {0}</div><div>PageName : {1}</div>\r\n", id, pageName);
            var actual = httpContext.Response.Output.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
