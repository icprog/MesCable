using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebUI.App_Start {
    public class BundleConfig {
        public static void RegistgerBundles(BundleCollection bundles) {
            var scriptLibPath = "~/Scripts/lib/";
            var scriptPath = "~/Scripts/";
            var styleCssPath = "~/Content/css/";
            var stylePath = "~/Content/";
            var scriptPreFix = "~/Scripts/";
            var stylePreFix = "~/Content/";

            //scirpts files
            bundles.Add(new ScriptBundle(scriptPreFix + "jquery").Include(scriptLibPath + "jquery-1.12.4.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "jquery-1.12.4").Include(scriptLibPath + "jquery-1.12.4.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "jquery-md5").Include(scriptLibPath + "jquery.md5.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "jquery-cookie").Include(scriptLibPath + "jquery.cookie.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "icheck").Include(scriptLibPath + "plugins/iCheck/icheck.min.js"));


            bundles.Add(new ScriptBundle(scriptPreFix + "bootstrap").Include(scriptLibPath + "bootstrap.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "metisMenu").Include(scriptLibPath + "plugins/metisMenu/jquery.metisMenu.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "slimscroll").Include(scriptLibPath + "plugins/slimscroll/jquery.slimscroll.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "layer").Include(scriptLibPath + "plugins/layer/layer.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "hplus").Include(scriptLibPath + "hplus.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "contabs").Include(scriptLibPath + "contabs.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "pace").Include(scriptLibPath + "plugins/pace/pace.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "admin/index").Include(scriptPath + "admin/index.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "system/menuConf").Include(scriptPath + "system/menuConf.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "bootstrap-switch").Include(scriptLibPath + "plugins/bootstrap-switch/bootstrap-switch.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "tableExport").Include(
                  scriptLibPath + "plugins/tableExport/tableExport.js",
                  scriptLibPath + "plugins/tableExport/jquery.base64.js",
                  scriptLibPath + "plugins/tableExport/html2canvas.js",
                  scriptLibPath + "plugins/tableExport/jspdf/libs/sprintf.js",
                  scriptLibPath + "plugins/tableExport/jspdf/libs/jspdf.min.js",
                  scriptLibPath + "plugins/tableExport/jspdf/libs/base64.js"


                ));



            bundles.Add(new ScriptBundle(scriptPreFix + "content").Include(scriptLibPath + "content.js"));


            bundles.Add(new ScriptBundle(scriptPreFix + "bootstrap-table").Include(
                scriptLibPath + "plugins/bootstrap-table/bootstrap-table.min.js",
                scriptLibPath + "plugins/bootstrap-table/locale/bootstrap-table-zh-CN.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "bootstrap-table-export").Include(
                 scriptLibPath + "plugins/bootstrap-table/extensions/export/tableExport.js",
                scriptLibPath + "plugins/bootstrap-table/extensions/export/bootstrap-table-export.min.js"
                ));
            bundles.Add(new ScriptBundle(scriptPreFix + "hotspot").Include(scriptLibPath + "jquery.hotspot.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "jsmind").Include(scriptLibPath + "plugins/jsMind/jsmind.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "jsTree").Include(scriptLibPath + "plugins/jsTree/jstree.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "chosen").Include(scriptLibPath + "plugins/chosen/chosen.jquery.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "cascadingdropdown").Include(scriptLibPath + "plugins/cascadingdropdown/jquery.cascadingdropdown.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "knockout").Include(scriptLibPath + "plugins/knockout/knockout-min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "webuploader").Include(scriptLibPath + "plugins/webuploader/webuploader.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "bootstrap-datepicker").Include(scriptLibPath + "plugins/datapicker/bootstrap-datepicker.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "signalR").Include(scriptLibPath + "jquery.signalR-2.2.1.min.js"));

            //draw charts lib
            bundles.Add(new ScriptBundle(scriptPreFix + "fusioncharts").Include(scriptLibPath + "plugins/fusioncharts-suite-xt/fusioncharts.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "fusioncharts-theme-fint").Include(scriptLibPath + "plugins/fusioncharts-suite-xt/themes/fusioncharts.theme.fint.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "fusioncharts-theme-carbon").Include(scriptLibPath + "plugins/fusioncharts-suite-xt/themes/fusioncharts.theme.carbon.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "fusioncharts-theme-zune").Include(scriptLibPath + "plugins/fusioncharts-suite-xt/themes/fusioncharts.theme.zune.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "echarts").Include(scriptLibPath + "plugins/echarts/echarts-all.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "highstock").Include(scriptLibPath + "plugins/highcharts/highstock/highstock.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "highstock-theme-darkunica").Include(scriptLibPath + "plugins/highcharts/highstock/themes/dark-unica.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "highstock-theme-sandsignika").Include(scriptLibPath + "plugins/highcharts/highstock/themes/sand-signika.js"));

            bundles.Add(new ScriptBundle(scriptPreFix + "highcharts").Include(scriptLibPath + "plugins/highcharts/highcharts/highcharts.js"));

            bundles.Add(new ScriptBundle(scriptPreFix + "context-menu").Include(scriptLibPath + "plugins/contextMenu/jquery.contextMenu.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "sweetalert").Include(scriptLibPath + "plugins/sweetalert/sweetalert.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "bootstrap-suggest").Include(scriptLibPath + "plugins/suggest/bootstrap-suggest.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "flipclock").Include(scriptLibPath + "plugins/flipClock/flipclock.min.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "clock").Include(scriptLibPath + "plugins/clock/moment.min.js",scriptLibPath + "plugins/clock/clock.js"));

            //demo
            bundles.Add(new ScriptBundle(scriptPreFix + "echarts-demo").Include(scriptLibPath + "demo/echarts-demo.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "fusioncharts-demo").Include(scriptLibPath + "demo/fusioncharts-demo.js"));
            bundles.Add(new ScriptBundle(scriptPreFix + "highcharts-demo").Include(scriptLibPath + "demo/highcharts-demo.js"));

            //style files
            bundles.Add(new StyleBundle(stylePreFix + "bootstrap").Include(styleCssPath + "bootstrap.min.css"));
            bundles.Add(new StyleBundle(stylePreFix + "font-awesome").Include(styleCssPath + "font-awesome.css"));
            bundles.Add(new StyleBundle(stylePreFix + "animate").Include(styleCssPath + "animate.css"));
            bundles.Add(new StyleBundle(stylePreFix + "style").Include(styleCssPath + "style.css"));
            bundles.Add(new StyleBundle(stylePreFix + "login").Include(styleCssPath + "login.css"));
            bundles.Add(new StyleBundle(stylePreFix + "admin/home").Include(stylePath + "admin/home.css"));
            bundles.Add(new StyleBundle(stylePreFix + "bootstrap-table").Include(styleCssPath + "plugins/bootstrap-table/bootstrap-table.min.css"));
            bundles.Add(new StyleBundle(stylePreFix + "hotspot").Include(styleCssPath + "plugins/hotspot/jquery.hotspot.css"));
            bundles.Add(new StyleBundle(stylePreFix + "context-menu").Include(styleCssPath + "plugins/contextMenu/jquery.contextMenu.min.css"));
            bundles.Add(new StyleBundle(stylePreFix + "sweetalert").Include(styleCssPath + "plugins/sweetalert/sweetalert.css"));
            bundles.Add(new StyleBundle(stylePreFix + "jsmind").Include(styleCssPath + "plugins/jsMind/jsmind.css"));
            bundles.Add(new StyleBundle(stylePreFix + "flipclock").Include(styleCssPath + "plugins/flipClock/flipclock.css"));
            bundles.Add(new StyleBundle(stylePreFix + "clock").Include(styleCssPath + "plugins/clock/clock.css"));
            bundles.Add(new StyleBundle(stylePreFix + "learunui-accordion").Include(styleCssPath + "plugins/learunui/learunui-accordion.css"));
            bundles.Add(new StyleBundle(stylePreFix + "jsTree").Include(styleCssPath + "plugins/jsTree/style.min.css"));
            bundles.Add(new StyleBundle(stylePreFix + "chosen").Include(styleCssPath + "plugins/chosen/chosen.css"));
            bundles.Add(new StyleBundle(stylePreFix + "webuploader").Include(styleCssPath + "plugins/webuploader/webuploader.css"));
            bundles.Add(new StyleBundle(stylePreFix + "bootstrap-datepicker").Include(styleCssPath + "plugins/datapicker/datepicker3.css"));
            bundles.Add(new StyleBundle(stylePreFix + "icheck-square-green").Include(styleCssPath + "plugins/iCheck/skins/square/green.css"));
            bundles.Add(new StyleBundle(stylePreFix + "bootstrap-switch").Include(styleCssPath + "plugins/bootstrap-switch/bootstrap-switch.min.css"));
            bundles.Add(new StyleBundle(stylePreFix + "material-table").Include("~/Content/material/material-table.css"));




        }
    }
}