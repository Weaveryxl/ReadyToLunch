using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationPractise3.Helpers
{
    public static class ButtonHelper
    {
        public static MvcHtmlString Button(string id, string text, string att = "btn btn-default pull-right", string function = null) // btn btn-default pull-right, location.href='@Url.Action('Index', 'Orders')'
        {
            return new MvcHtmlString(String.Format("< input type = 'button' id = '{0}' value = '{1}' class='{2}' onclick='{3}' />",id ,text ,att ,function));
        }
    }
}