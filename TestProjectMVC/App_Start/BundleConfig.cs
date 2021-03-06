﻿using System.Web;
using System.Web.Optimization;

namespace TestProjectMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
           "~/Scripts/bootstrap.js",
           "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/site.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/fonts/icomoon/icomoon.css",
                      "~/Content/css/main.css"
                ));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                "~/Content/js/jquery.js",
                "~/Content/js/tether.min.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/moment.js",
                "~/Content/js/common.js",
                "~/Content/js/jquery.validate.unobtrusive.min.js",
                "~/Content/js/jquery.validate.unobtrusive.js",
                "~/Content/vendor/unifyMenu/unifyMenu.js",
                "~/Content/vendor/onoffcanvas/onoffcanvas.js",
                "~/Content/vendor/slimscroll/slimscroll.min.js",
                "~/Content/vendor/slimscroll/custom-scrollbar.js"
                ));
        }
    }
}
