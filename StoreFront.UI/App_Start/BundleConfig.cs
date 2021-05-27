using System.Web.Optimization;

namespace StoreFront.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Script Bundles

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/vendor/jquery/jquery.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Scripts/respond.js",
                        "~/Content/vendor/bootstrap-select/js/bootstrap-select.min.js",
                        "~/Content/vendor/lightbox2/js/lightbox.min.js",
                        "~/Content/vendor/nouislider/nouislider.min.js",
                        "~/Content/vendor/owl.carousel2/owl.carousel.min.js",
                        "~/Content/vendor/owl.carousel2.thumbs/owl.carousel2.thumbs.min.js",
                        "~/Scripts/js/front.js"));

            bundles.Add(new ScriptBundle("~/bundles/contact").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Style Bundles

            bundles.Add(new StyleBundle("~/Content/vendorstyles").Include(
                        "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                        "~/Content/vendor/bootstrap-select/css/bootstrap-select.min.css",
                        "~/Content/vendor/lightbox2/css/lightbox.min.css",
                        "~/Content/vendor/nouislider/nouislider.min.css",
                        "~/Content/vendor/owl.carousel2/assets/owl.carousel.min.css",
                        "~/Content/vendor/owl.carousel2/assets/owl.theme.default.min.css",
                        "~/Content/DataTables/css/jquery.dataTables.jqueryui.min.css",
                        "~/Content/DataTables/css/jquery.dataTables.min.css"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                        "~/Content/css/style.default.min.css",
                        "~/Content/css/custom.css"));
        }
    }
}
