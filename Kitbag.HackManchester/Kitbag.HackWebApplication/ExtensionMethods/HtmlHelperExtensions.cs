using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Kitbag.HackWebApplication.ExtensionMethods
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Gets the gravatar image URL.
        /// </summary>
        /// <param name="emailId">The email id.</param>
        /// <param name="imgSize">Size of the img.</param>
        /// <returns></returns>
        public static MvcHtmlString RenderGravatarImage(this HtmlHelper helper, string emailId, int imgSize)
        {
            // Convert emailID to lower-case
            emailId = emailId.ToLower();

            var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(emailId, "MD5").ToLower();

            // build Gravatar Image URL
            var imageUrl = string.Format(@"<img src=""http://www.gravatar.com/avatar/{0}?s={1}&d=mm&r=g"" />", hash, imgSize);

            return new MvcHtmlString(imageUrl);
        }
    }
}