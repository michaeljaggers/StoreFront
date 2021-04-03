﻿using System.Web.Optimization;

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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/style.default.min.css",
                        "~/Content/css/custom.css"));
        }
    }
}
