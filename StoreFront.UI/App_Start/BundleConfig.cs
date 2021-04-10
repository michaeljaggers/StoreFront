using System.Web.Optimization;

namespace StoreFront.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/lightbox").Include(
                        "~/Content/vendor/lightbox2/js/lightbox.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/front").Include(
                        "~/Scripts/js/front.js"));

            bundles.Add(new ScriptBundle("~/bundles/nouislider").Include(
                        "~/Content/vendor/nouislider/nouislider.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-select").Include(
                        "~/Content/vendor/bootstrap-select/js/bootstrap-select.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/owl-carousel2").Include(
                        "~/Content/vendor/owl.carousel2/owl.carousel.min.js",
                        "~/Content/vendor/owl.carousel2.thumbs/owl.carousel2.thumbs.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/vendor").Include(
                        "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                        "~/Content/vendor/bootstrap-select/css/bootstrap-select.min.css",
                        "~/Content/vendor/lightbox2/css/lightbox.min.css",
                        "~/Content/vendor/nouislider/nouislider.min.css",
                        "~/Content/vendor/owl.carousel2/assets/owl.carousel.min.css",
                        "~/Content/vendor/owl.carousel2/assets/owl.theme.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/style.default.min.css",
                        "~/Content/css/custom.css"));
        }
    }
}
