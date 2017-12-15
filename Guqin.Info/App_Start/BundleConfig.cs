using System.Web.Optimization;

namespace Guqin.Info.MVC
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/text.css",
                      "~/Content/margin.css",
                      "~/Content/align.css",
                      "~/Content/input.css",
                      "~/Content/background.css",
                      "~/Content/image.css",
                      "~/Content/shadow.css",
                      "~/Content/column.css",
                      "~/Content/border.css",
                      "~/Content/color.css",
                      "~/Content/padding.css",
                      "~/Content/position.css",
                      "~/Content/radius.css"));
        }
    }
}
