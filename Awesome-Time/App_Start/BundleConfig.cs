using System.Web;
using System.Web.Optimization;

namespace Awesome_Time
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.validate-checkboxfix.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/main-style.min.css"));

            bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
                      "~/Content/bootstrap-datepicker.css"));//Use only in stock boostrap forms

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                        "~/Scripts/tinymce.min.js",
                        "~/Scripts/jquery.tinymce.min.js"));

            bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
                      "~/Content/bootstrap-datepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Scripts/bootstrap-datepicker.min.js"));
        }
    }
}
