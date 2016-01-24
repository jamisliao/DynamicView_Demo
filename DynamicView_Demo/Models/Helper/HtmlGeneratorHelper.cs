using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DynamicView_Demo.Models.Helper
{
    public class HtmlGeneratorHelper : IHtmlGeneratorHelper
    {
        /// <summary>
        /// Create Html
        /// </summary>
        /// <param name="pageName">page name</param>
        /// <param name="id">id</param>
        /// <returns>html</returns>
        public string GetHtml(string pageName, string id)
        {
            StringBuilder sb = new StringBuilder();
            var content = string.Empty;

            var dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (pageName == "View1")
            {
                content = string.Format("<div>I am {0}</div><div>PageName : {1}</div>", id, pageName);

                sb.AppendLine(content);
            }
            else if (pageName == "View2")
            {
                content = string.Format("<div>I am {0}</div><div>PageName : {1}</div><div>Now time : {2}</div>", id, pageName, dateTimeStr);

                sb.AppendLine(content);
            }

            return sb.ToString();
        }
    }
}