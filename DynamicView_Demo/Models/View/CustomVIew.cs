using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicView_Demo.Models.Helper;

namespace DynamicView_Demo.Models.View
{
    public class CustomView : IView
    {
        private IHtmlGeneratorHelper _htmlGenerator;
        private string _pageName;
        private string _shopId;

        public CustomView(string pageName, string shopId, IHtmlGeneratorHelper htmlGenerator)
        {
            this._pageName = pageName;
            this._shopId = shopId;
            this._htmlGenerator = htmlGenerator;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var htmlContent = this._htmlGenerator.GetHtml(this._pageName, this._shopId);
            WriteHtml(writer, htmlContent);
        }

        private void WriteHtml(TextWriter textWriter, string html)
        {
            textWriter.Write(html);
        }
    }
}