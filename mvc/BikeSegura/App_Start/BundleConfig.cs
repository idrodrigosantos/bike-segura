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
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
                        "~/Scripts/inputmask/inputmask/inputmask.js",
                        "~/Scripts/Inputmask/inputmask/jquery.inputmask.js",
                        "~/Scripts/Inputmask/inputmask/inputmask.extensions.js",
                        "~/Scripts/Inputmask/inputmask/inputmask.date.extensions.js",
                        //and other extensions you want to include
                        "~/Scripts/Inputmask/inputmask/inputmask.numeric.extensions.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/all.css",
                        "~/Content/meu-estilo.css"));
        }
    }
}
