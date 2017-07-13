<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SubscriberVerify.aspx.cs" Inherits="SubscriberVerify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderScript" runat="server">
    <style>
      th.dt-center,td.dt-center{
           text-align:center;
       }
      tr.selected, tr.selected:hover{
          background-color:rgb(204, 231, 226)!important;
         
      }
      
      .table-hover tbody tr.selected:hover td, .table-hover tbody tr.selected:hover th {
        background-color: rgb(204, 231, 226)!important;
    }
      .table-hover tbody tr.selected.odd:hover td, .table-hover tbody tr.selected.odd:hover th {
        background-color: rgb(204, 231, 226)!important;
    }
      .dt-buttons.btn-group{
          float:right;
          margin-left:1px;
      }
   </style>
 </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="wrapper wrapper-content animated fadeInRight">

           
                
             <div class="row">
               
                <div class="col-lg-12">
                    <div class="ibox float-e-margins">
                        <%--<div class="ibox-title">
                            <h5>Import Subscriber <small> Excel *.xlsx,*.csv only!! </small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                
                               
                            </div>
                        </div>--%>
                         <div class="ibox-title">
                        <span class="label label-primary pull-right">Today</span>
                        <h5>Summay</h5>
                    </div>
                        <div class="ibox-content" id="Content_report">
                            <div class="sk-spinner sk-spinner-wave">
                                       
                                       <p class="custom_progress_percentage"><span id="progress">0</span>%</p> <p style="clear:both"></p>
                                   
                                        <div class="sk-rect1"></div>
                                        <div class="sk-rect2"></div>
                                        <div class="sk-rect3"></div>
                                        <div class="sk-rect4"></div>
                                        <div class="sk-rect5"></div>
                                    </div>
                            <div>
                               
                                            <div class="row">
                                                <div class="col-md-4" style="text-align:right;">
                                                    <h1 class="no-margins" id="sum-total">406,42</h1>
                                                    <div class="font-bold text-navy"><span id="sum-total-percent"></span><i class="fa fa-level-up"></i> <small>Total</small></div>
                                                </div>
                                                <div class="col-md-4" style="text-align:center;">
                                                    <h1 class="no-margins" id="sum-active">206,12</h1>
                                                    <div class="font-bold text-navy"><span id="sum-active-percent">44% </span> <i class="fa fa-level-up"></i> <small>Active</small></div>
                                                </div>
                                                 <div class="col-md-4" style="text-align:left;">
                                                    <h1 class="no-margins" id="sum-inactive">206,12</h1>
                                                    <div class="font-bold text-navy"><span id="sum-inactive-percent">44% </span> <i class="fa fa-level-up"></i> <small>Inactive</small></div>
                                                </div>
                                            </div>

                                <div id="pie"></div>
                            </div>
                            <br /><br />
                            <div class="text-center">
                                 <div class="form-group col-md-12">
                            <input type="button" id="btnUploadFile" onclick="VerifyNow(this);" class="btn btn-w-m btn-success" value="Verify Email Now!!"  />

                                 <input type="button" id="ActiveEmail"  onclick="Active();" class="btn btn-primary" value="ActiveEmail"  />

                                 <input type="button" id="InActiveEmail" onclick="Inactive();" class="btn btn-primary" value="InactiveEmail"  />
                                     </div>
                                </div>

                            <div style="clear:both" ></div>
                        </div>
                        <div style="clear:both" ></div>
                </div>
</div>

            </div>

            <div class="row">
                <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>SubScriber List <span id="span_status_text" class="pull-right label label-primary">Active</span></h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div class="sub-custom-filter">
                            <select id="SGID_Filter" name="SGID_Filter" class="form-control  my-inputs">
                                        <%= GetGroup() %>
                         </select>
                        </div>     
                         
                        <div class="table-responsive">

 
                    <table id="datatab" class="table table-striped table-bordered table-hover " >
                    <thead>
                    <tr>
                      <th><input name="select_all" value="1"  type="checkbox" /></th>
                       <th>No.</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                         <th>Email</th>
                        <th>Status</th>
                     <%--   <th></th>--%>
                       
                    </tr>
                    </thead>
                    <tbody>

                    </tbody>

                    <tfoot>
                    <tr>
                        <th></th>
                       <th>No.</th>
                          <th>First Name</th>
                        <th>Last Name</th>
                         <th>Email</th>
                        <th>Status</th>
                     <%--   <th></th>--%>
                    </tr>
                    </tfoot>
                    </table>
                        </div>

                        

                    </div>
                </div>
            </div>
            </div>
   
           

    </div>

     <div class="modal inmodal" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content ibox-content animated bounceInRight">
                                    
                                    
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <i class="fa fa-laptop modal-icon"></i>
                                            <h4 class="modal-title">Notofication</h4>
                                            <small class="font-bold">การ import Subscriber</small>
                                        </div>
                                        <div class="modal-body">
                                            <p><strong>ท่านมีจำนวนการ import ทั้งหมด : </strong> <span id="total_import"></span></p>

                                            <p>ดำเนินการต่อ หรือไม่</p>
                                                   <%-- <div class="form-group"><label>Sample Input</label> <input type="email" placeholder="Enter your email" class="form-control"></div>--%>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary"  onclick="uploadnow(this);">ดำเนินการต่อ</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

    <input type="hidden" id="Sstatus" value="1" />
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
  
      <!-- d3 and c3 charts -->
   

      <script src="../Scripts/theme/plugins/c3/c3.min.js"></script>
    <script src="../Scripts/theme/plugins/d3/d3.min.js"></script>
     <script type="text/javascript">

         function stopPropagation(evt) {
             if (evt.stopPropagation !== undefined) {
                 evt.stopPropagation();
             } else {
                 evt.cancelBubble = true;
             }
         }


         function Active() {
             $("#Sstatus").val('1');
             $("#span_status_text").html("Active");
             var table = $('#datatab').DataTable();
             table.draw();
             return false;
         }
         function Inactive() {
             $("#Sstatus").val('0');
             $("#span_status_text").html("Inactive");
             var table = $('#datatab').DataTable();
             table.draw();

             return false;
         }
         function renderEditmode(d) {

             return '<input type="text" data-column="' + d.column + '" id="form-mode-' + d.column + '-' + d.id + '" class="form-control form-mode" style="display:none;width:100%" value="' + d.data + '" />';
         }

         function renderDataView(d) {
             return '<span class="form-mode_v">' + d.data + '</span>';
         }


         function UpdateButtonmode(table, $row) {
             var buttons_editMode = table.buttons(['.main-btn-delete', '.main-btn-edit']);
             var buttons_editAction = table.buttons(['.main-btn-cancel', '.main-btn-update']);
             //table.rows({ selected: true });
             //.find('input[type="checkbox"]');
             //var rowselected = table.rows().nodes().find('input[type="checkbox"]:checked');

             var $table = table.table().node();
             var $chkbox_checked = $('tbody input[type="checkbox"]:checked', $table);
             var $FormMode = $('tbody .form-mode:visible', $table);
             var $FormModeView = $('tbody .form-mode_v:visible', $table);

             var form_edit = $row.find(".form-mode");
             var form_view = $row.find(".form-mode_v");
             var rowChecked = $row.find('input[type="checkbox"]');

             var editmode = buttons_editMode.button().node().is(':visible');


             if ($chkbox_checked.length > 0 && editmode && $FormMode.length == 0) {

                 buttons_editMode.enable();
                 buttons_editAction.disable();

             } else {
                 if ($FormMode.length > 0 && rowChecked.is(':checked')) {
                     form_edit.show();
                     form_view.hide();
                 } else {
                     form_edit.hide();
                     form_view.show();
                 }
                 //buttons_editMode.disable();
                 // buttons_editAction.disable();
             }


             if ($chkbox_checked.length === 0) {
                 buttons_editMode.disable();
                 buttons_editAction.disable();
             }
             //table.rows({ selected: true }).every(function () {
             //    var d = this.data();

             //    var row = this.node();

             //    $(row).find(".form-mode").show();
             //    $(row).find(".form-mode_v").hide();
             //    //$(row).find(".form-mode").toggle('fast');

             //    //$(this).find(".form-mode").toggle('fast');
             //    // d.counter++; // update data source for the row

             //    //this.invalidate(); // invalidate the data DataTables has cached for this row
             //});

         }


         function uploadnow(e) {
             
             var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/UploadNow") %>";

             var data = { Key: $(e).data('key'), Total: $(e).data('total'), Group: $('#SGID_import').val() };
             var param = JSON.stringify({ parameters: data });
             AjaxPost(url, param, function () {
                 $('#myModal').find('.ibox-content').addClass('sk-loading');
             }, function (data) {


                 if (data.success) {
                     CheckImportProgress();
                     //$('#myModal').find('.ibox-content').removeClass('sk-loading');
                     //$('#myModal').modal('hide');
                 }
             });

             return false;
         }

         function VerifyNow(e) {

             var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/VerifyNow") %>";

             var data = { Key: $(e).data('key'), Total: $(e).data('total'), Group: $('#SGID_import').val() };
             var param = JSON.stringify({ parameters: data });
             AjaxPost(url, param, function () {
                 $('#Content_report').addClass('sk-loading');
             }, function (data) {


                 if (data.success) {
                     CheckVerifyProgress();


                     //$('#myModal').find('.ibox-content').removeClass('sk-loading');
                     //$('#myModal').modal('hide');
                 } else {
                     swal({
                         title: "No Data To Verify",
                         text: "ไม่มีราย Subscriber ที่ยังไม่ผ่านการ Verify"
                     });
                     $('#Content_report').removeClass('sk-loading');
                 }
             });

             return false;
         }


         function CheckVerifyProgress() {
             $('#Content_report').addClass('sk-loading');
                     var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/CheckStatusVerify") %>";

                     var data = null;
                     var param = JSON.stringify({ parameters: data });
                     AjaxPost(url, param, null, function (data) {

                         console.log("dd: " + data);

                         if (data.IsOnprocess) {
                             $('#progress').html(data.PerCentCompleted);

                             if (data.PerCentCompleted < 100) {
                                 setTimeout('CheckVerifyProgress()', 2000);
                             } else {
                                 var table = $('#datatab').dataTable();
                                 table.fnReloadAjax();

                                 setTimeout(function () {
                                     $('#Content_report').removeClass('sk-loading');

                                     $('<div class="alert alert-success">Import เรียบร้อยแล้ว กรุณา กดปุ่ม Close เพื่อปิดหน้าต่างนี้</div>').prependTo(".modal-content");
                                 }, 3000);
                         
                         
                             }
                         } else {
                             $('#Content_report').removeClass('sk-loading');
                         }
                     });

             
           
         }





         function GetProfile() {

             var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/GetTotal") %>";

             var data = null;
             var param = JSON.stringify({ parameters: data });
             AjaxPost(url, param, null, function (data) {

                 console.log(data);
                 //TotalAll
                 if (data) {

                     
                     var intActive = (parseFloat(data.TotalActive) * 100) / parseFloat(data.TotalAll); 
                     var intInactive = (parseFloat(data.TotalInactive) * 100) / parseFloat(data.TotalAll);  

                     var string = numeral(1000).format('0,0');

                     $('#sum-total').html(numeral(data.TotalAll).format('0,0'));

                     $('#sum-active').html(numeral(data.TotalActive).format('0,0'));
                     $('#sum-inactive').html(numeral(data.TotalInactive).format('0,0'));
                     $('#sum-total-percent').html();
                     $('#sum-active-percent').html(numeral(intActive).format('0') + "%");
                     $('#sum-inactive-percent').html(numeral(intInactive).format('0') + "%");

                     //var NulActive = numeral(intActive);
                     //var NuInactive = numeral(intInactive);

                     c3.generate({
                         bindto: '#pie',
                         data: {
                             columns: [
                                 ['Active', intActive],
                                 ['Inactive', intInactive]
                             ],
                             colors: {
                                 Active: '#1ab394',
                                 Inactive: '#BABABA'
                             },
                             type: 'pie'
                         }
                     });
                 }

                 //if (data.success) {
                 //    $('#progress').html(data.PerCentCompleted);

                 //    if (data.PerCentCompleted < 100) {
                 //        setTimeout('CheckImportProgress()', 2000);
                 //    } else {
                 //        var table = $('#datatab').dataTable();
                 //        table.fnReloadAjax();

                 //        setTimeout(function () {
                 //            $('#myModal').find('.ibox-content').removeClass('sk-loading');

                 //            $('<div class="alert alert-success">Import เรียบร้อยแล้ว กรุณา กดปุ่ม Close เพื่อปิดหน้าต่างนี้</div>').prependTo(".modal-content");
                 //        }, 3000);


                 //    }
                 //}
             });



         }

         $(document).ready(function () {
             CheckVerifyProgress();
             GetProfile();
           
             

             $("#input_btn_save").on('click', function (e) {
                 e.preventDefault();
                 var mainform = jQuery('form');
                 mainform.validate();
                 var ele = $(".required");
                 $.each(ele, function (index) {
                     $(this).rules('add', {
                         required: true,
                         messages: {
                             required: 'required field'
                         }
                     }
                     );
                 });



                 if (mainform.valid()) {
                     var post = $("#insert-form").find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize();
                     var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/InsertGroup") %>";
                    //{head: $('#ProcessTsForm').serialize(), detail: found_names},

                     var param = JSON.stringify({ parameters: qToJson(post) });
                     AjaxPost(url, param, null, function (data) {
                        

                         if (data.success) {
                            
                             toastr.success('Notification', data.msg);
                             //$('#datatab').DataTable().ajax.reload();

                             var table = $('#datatab').dataTable();
                             table.fnReloadAjax();
                             //table
                             //    .clear()
                             //    .draw();
                             //$('#datatab').DataTable().draw();
                             //oTable.draw();

                             $(".my-input").val("");

                            
                             
                             
                             //chkbox_select_all.prop('checked', false);
                         }
                     }, function (xhr, status) {
                            //var table = $('#datatab').dataTable();
                            // var chkbox_all = $('tbody input[type="checkbox"]', table);
                            // var chkbox_select_all = $('thead input[name="select_all"]', table).get(0);
                            // $(chkbox_all).prop('checked', false);
                            // $(chkbox_select_all).prop('checked', false);
                         });
                 }

               return false;
                
             });

             $('#datatab thead th').each(function (index) {
                 if (index > 1 && ($('#datatab thead th').length -1) != index) {
                     $(this).append('&nbsp;<input type="text" class="form-control" onclick="stopPropagation(event);" />');
                 }
                 
             });


             

             // Event listener to the two range filtering inputs to redraw on input
             $('#SGID_Filter').on('change', function () {
                 var table = $('#datatab').DataTable();
                 table.draw();
             });
             var rows_selected = [];
             var oTable = $('#datatab').DataTable({
                 processing: true,
                 serverSide: true,
                 responsive: true,
                 //deferRender: true,
                 stateSave: false,
                ajax: {
                     type: "POST",
                     url: "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/DataAll") %>",
                     contentType: 'application/json; charset=utf-8',
                     data: function (d) {


                         //add custom filter 
                         var CustomSearch = {
                             Key: "SGID",
                             Value: $("#SGID_Filter").val()
                         };
                         d['CustomSearch'] = CustomSearch;

                         var Status = {
                             Key: "Sbin",
                             Value: $("#Sstatus").val()
                         };
                         d['Status'] = Status;

                         return JSON.stringify({ parameters: d });
                     },
                 },
                 //"dom": 'frtiS',
                 //"scrollY": 500,
                 //"scrollX": true,
                 //"scrollCollapse": true,
                 //"scroller": {
                 //    loadingIndicator: false
                 //},
                pageLength:15,
                paging: true,
                lengthMenu: [15, 25, 50, 75, 100],
               
                columns: [
                    {
                        data: null,
                       
                        'searchable': false,
                        'orderable': false,
                        'width': '1%',
                        'className': 'dt-body-center',
                        'render': function (data, type, full, meta) {
                            return '<input type="checkbox">';
                        }
                    },
                    {
                        data: "RowNum",
                        'orderable': false,
                        "width": "3%",
                        'className': 'dt-center',

                    }, 
                    {
                        data: "FirstName",
                        render: function (data, type, full, meta) {
                            return renderDataView({ data: data, id: full.SID, column: "FirstName" }) + renderEditmode({ data: data, id: full.SID, column: "FirstName"});
                        }
                        

                    },
                    {
                        data: "LastName",
                         render: function (data, type, full, meta) {
                             return renderDataView({ data: data, id: full.SID, column: "LastName" }) + renderEditmode({ data: data, id: full.SID, column: "LastName" });
                        }
                    }
                    ,
                    {
                        data: "Email",
                        render: function (data, type, full, meta) {
                            return renderDataView({ data: data, id: full.SID, column: "Email" }) + renderEditmode({ data: data, id: full.SID, column: "Email" });
                        }
                    },
                     {
                         data: "Sbin",
                         'className': 'dt-center',
                         render: function (data, type, full, meta) {
                             if (data) {
                                 return '<span class="label label-primary">Active</span>';
                             } else {
                                 return '<span class="label">Inactive</span>';
                             }

                             
                         }
                    }

                ],
                'rowCallback': function (row, data, dataIndex) {
                    // Get row ID
                    //var rowId = data[0];

                    //// If row ID is in the list of selected row IDs
                    //if ($.inArray(rowId, rows_selected) !== -1) {
                    //    $(row).find('input[type="checkbox"]').prop('checked', true);
                    //    $(row).addClass('selected');
                    //}
                },
               
                //select: {
                //    style: "multi",
                //    className: 'selected'
                //},
                
                "order": [2, "asc"],
                dom: 'lBfrtip',
                buttons: [
                    {
                        text: 'Edit',
                        className: 'main-btn-edit',
                        action: function (e, dt, node, config) {
        
                            var rows = oTable.rows().nodes();
                            $.each(rows, function () {

                                var check = $(this).find('input[type="checkbox"]');
                                if (check.is(':checked')) {
                                    $(this).find(".form-mode").show();
                                    $(this).find(".form-mode_v").hide();
                                }
                            });
                           
                            var buttons_1 = oTable.buttons(['.main-btn-delete', '.main-btn-edit']);
                            var buttons_2 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                            buttons_1.disable();
                            buttons_2.enable();
                           
                           
                        }
                    },
                    {
                        text: 'Bin',
                        className: 'main-btn-delete',
                        action: function (e, dt, node, config) {


                            swal({
                                title: "Are you sure?",
                                text: "You will not be able to recover this record!",
                                type: "warning",
                                showCancelButton: true,
                                confirmButtonColor: "#DD6B55",
                                confirmButtonText: "Yes, delete it!",
                                closeOnConfirm: false
                            }, function () {


                                post = [];
                                oTable.rows().every(function () {
                                    var d = this.data();

                                    var row = this.node();

                                    var check = $(row).find('input[type="checkbox"]');
                                    if (check.is(':checked')) {
                                        post.push(d);
                                    }
                                });


                                var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/Delete") %>";
                            var param = JSON.stringify({ parameters: post });
                            AjaxPost(url, param, null, function (data) {
                                if (data.success) {

                                    toastr.success('Notification', data.msg);
                                    //oTable.draw();
                                    var table = $('#datatab').dataTable();
                                    table.fnReloadAjax();


                                }

                            });

                            swal.close();
                               
                            });





                           


                            //$('#my_confirm').modal()
                            //    .one('click', '#my_modal_action', function (e) {
                                   


                            //        $("#my_confirm").modal('hide');
                            //        e.preventDefault();
                                   
                            //    });
                           
                        }
                    }
                    ,
                    {
                        text: 'Cancel',
                        className: 'main-btn-cancel',
                        action: function (e, dt, node, config) {
                            


                            var rows = oTable.rows().nodes();
                            $.each(rows, function () {

                                var check = $(this).find('input[type="checkbox"]');
                               // if (check.is(':checked')) {
                                    $(this).find(".form-mode").hide();
                                    $(this).find(".form-mode_v").show();
                                //}
                            });
                            var buttons_1 = oTable.buttons(['.main-btn-delete', '.main-btn-edit']);
                            var buttons_2 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                            buttons_2.disable();
                            buttons_1.enable();
                        }
                    }
                    ,
                    {
                        text: 'Update',
                        className: 'main-btn-update',
                        action: function (e, dt, node, config) {
                            post = [];
                            oTable.rows().every(function () {
                                var d = this.data();

                                var row = this.node();

                              var editmode =  $(row).find(".form-mode");
                              var viewmode =  $(row).find(".form-mode_v");
                                var check = $(row).find('input[type="checkbox"]');
                                if (check.is(':checked')) {

                                    $.each(editmode, function () {
                                        var col = $(this).data('column');
                                        var id = d.SID;

                                        var v = $("#form-mode-" + col + "-" + id).val();
                                        d[col] = v;
                                    });


                                    post.push(d);
                                }

                            });


                            var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber1.aspx/Update") %>";
                            var param = JSON.stringify({ parameters: post });
                            AjaxPost(url, param, null, function (data) {


                                if (data.success) {

                                    toastr.success('Notification', data.msg);
                                    //oTable.draw();
                                    var table = $('#datatab').dataTable();
                                    table.fnReloadAjax();

                                    
                                    var buttons_4 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                                    
                                    buttons_4.disable();


                                }

                            });
                        }
                    }

                ]
                

             });

             // Handle click on checkbox
             $('#datatab tbody').on('click', 'input[type="checkbox"]', function (e) {

                 //if (e.target.tagName != "BUTTON" && e.target.tagName != "INPUT") {
                     var $row = $(this).closest('tr');

                     // Get row data
                     var data = oTable.row($row).data();

                     // Get row ID
                     var rowId = data[0];

                     // Determine whether row ID is in the list of selected row IDs 
                     var index = $.inArray(rowId, rows_selected);

                     // If checkbox is checked and row ID is not in list of selected row IDs
                     if (this.checked && index === -1) {
                         rows_selected.push(rowId);

                         // Otherwise, if checkbox is not checked and row ID is in list of selected row IDs
                     } else if (!this.checked && index !== -1) {
                         rows_selected.splice(index, 1);
                     }

                     if (this.checked) {
                         $row.addClass('selected');
                     } else {
                         $row.removeClass('selected');
                     }

                     // Update state of "Select all" control
                     updateDataTableSelectAllCtrl(oTable);
                    
                    
                     UpdateButtonmode(oTable, $row);
                   
                     e.stopPropagation();
                // }
                 
             });

             // Handle click on table cells with checkboxes
             $('#datatab').on('click', 'tbody td, thead th:first-child', function (e) {
                 if (e.target.tagName != "BUTTON" && e.target.tagName != "INPUT") {
                     $(this).parent().find('input[type="checkbox"]').trigger('click');
                 }
                
             });


             // Handle click on "Select all" control
             $('thead input[name="select_all"]', oTable.table().container()).on('click', function (e) {
                 if (this.checked) {
                     $('#datatab tbody input[type="checkbox"]:not(:checked)').trigger('click');
                 } else {
                     $('#datatab tbody input[type="checkbox"]:checked').trigger('click');
                 }

                 //updateDataTableSelectAllCtrl(oTable);
                 // Prevent click event from propagating to parent
                 e.stopPropagation();
             });

             // Handle table draw event
             oTable.on('draw', function () {
                 // Update state of "Select all" control
                 updateDataTableSelectAllCtrl(oTable);
             });
            
             oTable.columns().every(function (t) {
                 if (t > 1) {
                     var that = this;

                     $('input', this.header()).on('keyup change', function () {
                         that
                             .search(this.value)
                             .draw();
                     });
                 }
                
             });


             //var table = $('#myTable').DataTable();
             var buttons = oTable.buttons(['.main-btn-delete', '.main-btn-cancel', '.main-btn-update','.main-btn-edit']);
             buttons.disable();

            






            
         
           

        });

    </script>
 </asp:Content>
