using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BookstoreChainMVC
{
    public class BundleConfig
    {
        // Creating the Bundle Class Method
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Script bundle for jQuery and jQuery validation
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js", "~/Scripts/jquery-ui-{verison}.js", "~/Scripts/jquery.validate*"));

            // Script bundle for bootstrap and modernizer
            bundles.Add(new ScriptBundle("~/bundles/bootsrap").Include(
                "~/Scripts/bootstrap.js", "~/Scripts/respond.js", "~/Scripts/modernizr-*"));

            // Style bundle for site and bootstrap sylesheets
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css", "~/Content/Site.css", "~/Content/themes/ui-lightness/jquery-ui.*"));
        }
    }
}