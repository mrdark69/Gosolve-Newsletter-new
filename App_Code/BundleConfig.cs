using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace gs_newsletter
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {


           

            // Order is very important for these files to work, they have explicit dependencies
           

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/MainScript").Include(
                 
                    "~/Scripts/theme/jquery-2.1.1.js",
                    "~/Scripts/theme/bootstrap.min.js",
                   "~/Scripts/theme/plugins/metisMenu/jquery.metisMenu.js",
                   "~/Scripts/theme/plugins/slimscroll/jquery.slimscroll.min.js",
                   "~/Scripts/theme/plugins/dataTables/datatables.min.js",
                   "~/Scripts/theme/plugins/dataTables/dataTables.scroller.min.js",
                   //"~/Scripts/theme/plugins/dataTables/dataTables.editor.min.js",
                   "~/Scripts/theme/plugins/store/store.legacy.min.js",
                   "~/Scripts/theme/plugins/dataTables/dataTables.select.min.js",
                    "~/Scripts/theme/plugins/dataTables/dataTables.checkboxes.min.js",
                    "~/Scripts/theme/plugins/dataTables/fnReloadAjax.js",
                    
                 

                    //"~/Scripts/theme/plugins/dataTables/dataTables.buttons.min.js",
                    "~/Scripts/theme/inspinia.js",
                    "~/Scripts/theme/plugins/pace/pace.min.js",
                    "~/Scripts/theme/plugins/validate/jquery.validate.min.js",
                    "~/Scripts/theme/plugins/jquery-ui/jquery-ui.min.js",
                    "~/Scripts/theme/plugins/toastr/toastr.min.js",
                    "~/Scripts/theme/plugins/momentjs/moment.js",
                    "~/Scripts/theme/plugins/numeraljs/numeral.js",
                    "~/Scripts/theme/plugins/jasny/jasny-bootstrap.min.js",
                    "~/Scripts/theme/plugins/sweetalert/sweetalert.min.js",
                     "~/Scripts/theme/plugins/iCheck/icheck.min.js",
                     "~/Scripts/theme/plugins/steps/jquery.steps.min.js",
                      "~/Scripts/theme/plugins/select2/select2.full.min.js",
                      "~/Scripts/theme/plugins/datapicker/bootstrap-datepicker.js",
                      "~/Scripts/theme/plugins/clockpicker/clockpicker.js",
                    //"~/Scripts/theme/plugins/blueimp/jquery.blueimp-gallery.min.js",
                    "~/Scripts/theme/plugins/dropzone/dropzone.js",
                    "~/Scripts/app.tool.js",
                     "~/Scripts/theme/main.js"
                   ));


            


              ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/respond.min.js",
                    DebugPath = "~/Scripts/respond.js",
                });

            //BundleTable.EnableOptimizations = true;
        }
    }
}