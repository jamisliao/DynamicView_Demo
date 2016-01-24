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
        /// <summary>
        /// Html generator
        /// </summary>
        private IHtmlGeneratorHelper _htmlGenerator;

        /// <summary>
        /// 瀏覽的頁面名稱
        /// </summary>
        private string _pageName;

        /// <summary>
        /// 使用者Id
        /// </summary>
        private string _id;

        /// <summary>
        /// CustomView
        /// </summary>
        /// <param name="pageName">瀏覽的頁面名稱</param>
        /// <param name="id">使用者Id</param>
        /// <param name="htmlGenerator">Html generator</param>
        public CustomView(string pageName, string id, IHtmlGeneratorHelper htmlGenerator)
        {
            this._pageName = pageName;
            this._id = id;
            this._htmlGenerator = htmlGenerator;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var htmlContent = this._htmlGenerator.GetHtml(this._pageName, this._id);
            WriteHtml(writer, htmlContent);
        }

        /// <summary>
        /// 將Html寫入TextWrite
        /// </summary>
        /// <param name="textWriter">TextWrite</param>
        /// <param name="html">Html</param>
        private void WriteHtml(TextWriter textWriter, string html)
        {
            textWriter.Write(html);
        }
    }
}