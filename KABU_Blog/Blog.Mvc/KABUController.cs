﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Blog.Mvc
{
    public class KabuController : Controller
    {
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public string GetRoute(string routeName, bool fromParent = false)
        {
            object routeValue;
            var routeDatas = fromParent ? ControllerContext.ParentActionViewContext.RouteData.Values : RouteData.Values;

            var isExists = routeDatas.TryGetValue(routeName, out routeValue);
            if (isExists)
                return routeValue.ToString();
            throw new KeyNotFoundException();
        }

        public string GetErrorMessage(IEnumerable<string> errors)
        {
            return errors.Aggregate(string.Empty, (current, error) => current + (error + Environment.NewLine));
        }


        public string GetErrorMessage(Exception exception)
        {
            var errorMessage = string.Empty;
            while (exception != null)
            {
                errorMessage += exception.Message + Environment.NewLine;
                exception = exception.InnerException;
            }
            return errorMessage;
        }
    }
}