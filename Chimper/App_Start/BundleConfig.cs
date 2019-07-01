using System.Web;
using System.Web.Optimization;

namespace Chimper
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-3.3.1.min.js",
                        "~/Scripts/jquery-migrate-3.0.1.min.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/owl.carousel.min.js",
                        "~/Scripts/jquery.stellar.min.js",
                        "~/Scripts/jquery.countdown.min.js",
                        "~/Scripts/jquery.magnific-popup.min.js",
                        "~/Scripts/bootstrap-datepicker.min.js",
                        "~/Scripts/aos.js",
                        "~/Scripts/typed.js",
                        "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/css/bootstrap.min.css",
                        "~/Content/css/magnific-popup.css",
                        "~/Content/css/jquery-ui.css",
                        "~/Content/css/owl.carousel.min.css",
                        "~/Content/css/owl.theme.default.min.css",
                        "~/Content/css/bootstrap-datepicker.css",
                        "~/Content/css/aos.css",
                        "~/Content/css/style.css",
                        "~/Content/fonts/icomoon/style.css",
                        "~/Content/fonts/flaticon/font/flaticon.css"));

            bundles.Add(new ScriptBundle("~/bundles/admin/js").Include(
                        "~/Content/vendor/jquery/jquery.min.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                        "~/Content/vendor/chart.js/Chart.min.js",
                        "~/Content/vendor/datatables/jquery.dataTables.js",
                        "~/Content/vendor/datatables/dataTables.bootstrap4.js",
                        "~/Content/vendor/js/sb-admin.min.js",
                        "~/Content/vendor/js/demo/datatables-demo.js",
                        "~/Content/vendor/js/demo/chart-area-demo.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/admin/css").Include(
                        "~/Content/vendor/fontawesome-free/css/all.min.css",
                        "~/Content/vendor/datatables/dataTables.bootstrap4.css",
                        "~/Content/Site.css",
                        "~/Content/vendor/css/sb-admin.css",
                        "~/Content/fonts/icomoon/style.css",
                        "~/Content/fonts/flaticon/font/flaticon.css"
                ));

        }
    }
}
