﻿using System.Web;
using System.Web.Optimization;

namespace BikeSegura
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
                      "~/Scripts/jquery.mask.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryjax").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                      "~/Scripts/Chart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/holder").Include(
                      "~/Scripts/holder.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                      "~/Scripts/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/estilo.css",
                      "~/Content/fontawesome/all.min.css",
                      "~/Content/toastr.min.css"));
        }
    }
}
