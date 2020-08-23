using System.Web;
using System.Web.Optimization;

namespace Gateways
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
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/themes/base/jquery-ui.min.css")
                // .Include("~/Content/materialize.css")
                .Include("~/Content/font-awesome.css")
                .Include("~/Content/Site.css")
                .Include("~/Content/toastr.min.css"));

            bundles.Add(new StyleBundle("~/Plugins/css")
                .Include("~/Plugins/DataTables/DataTables-1.10.18/css/dataTables.bootstrap4.min.css")
                .Include("~/Plugins/timepicker-ui-addon/jquery-ui-timepicker-addon.css"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/umd/popper.min.js")
                .Include("~/Scripts/Site.js")
                // .Include("~/Scripts/materialize.js")
                .Include("~/Scripts/jquery-ui-1.12.1.min.js")
                .Include("~/Scripts/toastr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins")
                .Include("~/Plugins/DataTables/DataTables-1.10.18/js/jquery.dataTables.min.js")
                .Include("~/Plugins/DataTables/DataTables-1.10.18/js/dataTables.bootstrap4.min.js")
                .Include("~/Plugins/timepicker-ui-addon/jquery-ui-timepicker-addon.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
