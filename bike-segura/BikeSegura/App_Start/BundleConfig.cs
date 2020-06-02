using System.Web;
using System.Web.Optimization;

namespace BikeSegura
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.intellisense.js",
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/jquery-3.3.1.slim.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate-vsdoc.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
                      "~/Scripts/jquery.mask.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chartjs").Include(
                      "~/Scripts/chart.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/holder").Include(
                      "~/Scripts/holder.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/meu-estilo.css",
                      "~/Content/fontawesome/all.min.css",
                      "~/Content/toastr.min.css"));
        }
    }
}
