<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="SubscriberGroup.aspx.cs" Inherits="_SubscriberGroup" %>
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
                        <div class="ibox-title">
                            <h5>Subscriber Group Insert Box</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                               
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div role="form" id="insert-form">
                                <div class="form-group col-md-5">
                                    <label for="Name" class="control-label">Group Name</label>
                                
                                         <input type="text" placeholder="Enter Name" id="SGName" name="SGName" 
                                           class="form-control required my-input">
                                    
                                    
                                </div>
                                 <div class="form-group col-md-5">
                                    <label for="Name" class="control-label">Group Detail</label>
                                
                                         <input type="text" placeholder="Enter Detail" id="SGDetail" name="SGDetail"
                                           class="form-control required my-input">
                                 </div>
                                
                                <div class="form-group col-md-2">
                                        <label style="height:12px;display:block;"></label>
                                        <button  type="button" id="input_btn_save" class="btn btn-w-m btn-primary">Save</button>
                                        <%--<asp:Button ID="input_btn_save" runat="server" Text="Save"   CssClass="btn btn-w-m btn-primary" />--%>
                                 </div>
                                <div style="clear:both"></div>
                            </div>
                        </div>
                    </div>
                </div>
                

            </div>

       <div class="row">
                <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>SubScriber Group</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                        </div>
                    </div>
                    <div class="ibox-content">

                        <div class="table-responsive">

 
                    <table id="datatab" class="table table-striped table-bordered table-hover " >
                    <thead>
                    <tr>
                      <th><input name="select_all" value="1"  type="checkbox" /></th>
                       <th>No.</th>
                        <th>Group Name</th>
                        <th>Group Detail</th>
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
                        <th>Group Name</th>
                        <th>Group Detail</th>
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
                                <div class="modal-content animated bounceInRight">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <i class="fa fa-laptop modal-icon"></i>
                                            <h4 class="modal-title">Modal title</h4>
                                            <small class="font-bold">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</small>
                                        </div>
                                        <div class="modal-body">
                                            <p><strong>Lorem Ipsum is simply dummy</strong> text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown
                                                printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting,
                                                remaining essentially unchanged.</p>
                                                    <div class="form-group"><label>Sample Input</label> <input type="email" placeholder="Enter your email" class="form-control"></div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary">Save changes</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
</asp:Content>

<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
     <script type="text/javascript">

         function stopPropagation(evt) {
             if (evt.stopPropagation !== undefined) {
                 evt.stopPropagation();
             } else {
                 evt.cancelBubble = true;
             }
         }


         function renderEditmode(d) {

             return '<input type="text" data-column="' + d.column + '" id="form-mode-' + d.column+'-' + d.id + '" class="form-control form-mode" style="display:none;width:100%" value="' + d.data + '" />';
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

         $(document).ready(function () {

            
          

           $("#input_btn_save").on('click', function (e) {

               var mainform = jQuery('form');
               mainform.validate();
               var ele = $(".required");
               $.each(ele,function (index) {
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
                     var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber.aspx/InsertGroup") %>";
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
             var rows_selected = [];
             var oTable = $('#datatab').DataTable({
                 processing: true,
                 serverSide: true,
                 responsive: true,
                 //deferRender: true,
                 stateSave: false,
                ajax: {
                     type: "POST",
                     url: "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber.aspx/DataAll") %>",
                     contentType: 'application/json; charset=utf-8',
                     data: function (d) {
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
                        data: "SGName",
                        render: function (data, type, full, meta) {
                            return renderDataView({ data: data, id: full.SGID, column: "SGName" }) + renderEditmode({ data: data, id: full.SGID, column: "SGName"});
                        }
                        

                    },
                    {
                        data: "SGDetail",
                         render: function (data, type, full, meta) {
                             return renderDataView({ data: data, id: full.SGID, column: "SGDetail" }) + renderEditmode({ data: data, id: full.SGID, column: "SGDetail" });
                        }
                    },
                     {
                         data: "Sstatus",
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


                            //$(".form-editmode").toggle('300', function () {
                               
                            //});

                            //var table = oTable.DataTable();
                            //var buttons = table.buttons(['.edit', '.delete']);

                            //var $chkbox_checked = $('tbody input[type="checkbox"]:checked', oTable);

                            //$.each($chkbox_checked, function () {
                            //    $(this).parent().find('.form-mode').show(); 
                            //    $(this).parent().find('.form-mode_v').hide(); 
                            //});

                            //{ selected: true }
                            var rows = oTable.rows().nodes();
                            $.each(rows, function () {

                                var check = $(this).find('input[type="checkbox"]');
                                if (check.is(':checked')) {
                                    $(this).find(".form-mode").show();
                                    $(this).find(".form-mode_v").hide();
                                }
                            });
                            //oTable.rows({ selected: true }).every(function () {
                            //    var d = this.data();

                            //    var row = this.node();

                            //    $(row).find(".form-mode").show(); 
                            //    $(row).find(".form-mode_v").hide();
                            //    //$(row).find(".form-mode").toggle('fast');

                            //    //$(this).find(".form-mode").toggle('fast');
                            //   // d.counter++; // update data source for the row

                            //    //this.invalidate(); // invalidate the data DataTables has cached for this row
                            //});
                            var buttons_1 = oTable.buttons(['.main-btn-delete', '.main-btn-edit']);
                            var buttons_2 = oTable.buttons(['.main-btn-cancel', '.main-btn-update']);
                            buttons_1.disable();
                            buttons_2.enable();
                           
                            //$(".paging_simple_numbers").toggle('fast');
                            //$(".dataTables_length").toggle('fast');

                            //$(".dataTables_filter").toggle('fast');

                            //$(".form-viewmode").toggle("hide");
                            //var count = oTable.rows({ selected: true }).count();

                            //oTable.rows({ selected: true }).every(function () {
                            //    var d = this.data();

                            //    d.counter++; // update data source for the row

                            //    this.invalidate(); // invalidate the data DataTables has cached for this row
                            //});

                            //oTable.draw();
                           
                            //oTable.rows({ selected: true }).every(function () {
                            //    $(this).find(".form-editmode").show();
                            //});

                           // alert(count);

                            //var rows_selected = oTable.column(0).checkboxes.selected();
                            //console.log(rows_selected);
                            // Iterate over all selected checkboxes
                            //$.each(rows_selected, function (index, rowId) {
                            //    // Create a hidden element 
                            //    console.log(rows_selected);
                            //});
                        }
                    },
                    {
                        text: 'Bin',
                        className: 'main-btn-delete',
                        action: function (e, dt, node, config) {

                            $('#my_confirm').modal()
                                .one('click', '#my_modal_action', function (e) {
                                    post = [];
                                    oTable.rows().every(function () {
                                        var d = this.data();

                                        var row = this.node();
                                        
                                        var check = $(row).find('input[type="checkbox"]');
                                        if (check.is(':checked')) {
                                            post.push(d);
                                        }
                                    });


                                    var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber.aspx/Delete") %>";
                                    var param = JSON.stringify({ parameters: post });
                                    AjaxPost(url, param, null, function (data) {
                                        if (data.success) {

                                            toastr.success('Notification', data.msg);
                                            //oTable.draw();
                                            var table = $('#datatab').dataTable();
                                            table.fnReloadAjax();

                                            
                                            //table
                                            //    .clear()
                                            //    .draw();
                                            // $('#datatab').DataTable().ajax.reload();


                                        }

                                    });


                                    $("#my_confirm").modal('hide');
                                    e.preventDefault();
                                   
                                });
                           
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
                                        var id = d.SGID;

                                        var v = $("#form-mode-" + col + "-" + id).val();
                                        d[col] = v;
                                    });


                                    post.push(d);
                                }

                                //$(row).find(".form-mode").toggle('fast');

                                //$(this).find(".form-mode").toggle('fast');
                                // d.counter++; // update data source for the row

                                //this.invalidate(); // invalidate the data DataTables has cached for this row
                            });


                            var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber.aspx/Update") %>";
                            var param = JSON.stringify({ parameters: post });
                            AjaxPost(url, param, null, function (data) {


                                if (data.success) {

                                    toastr.success('Notification', data.msg);
                                    //oTable.draw();
                                    var table = $('#datatab').dataTable();
                                    table.fnReloadAjax();
                                    //table
                                    //    .clear()
                                    //    .draw();
                                    // $('#datatab').DataTable().ajax.reload();

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
                    //chekc when click on edit mode;
                    // do something ....
                     //if (editmode) {
                     //    if (this.checked) {
                     //        form_edit.show();
                     //        form_view.hide();
                     //    } else {
                     //        form_edit.hide();
                     //        form_view.show();
                     //    }
                     //}
                     //if (oTable.rows({ selected: true }).count > 0) {

                     //} else {

                     //}

                     // Prevent click event from propagating to parent
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

             //$("#hh").on('click', function (e) {
             //    $.each(rows_selected, function (index, rowId) {

             //        console.log(rowId);
             //        // Create a hidden element 
             //        //$(this).append(
             //        //    $('<input>')
             //        //        .attr('type', 'hidden')
             //        //        .attr('name', 'id[]')
             //        //        .val(rowId)
             //        //);
             //    });

             //    // FOR DEMONSTRATION ONLY     

             //    // Output form data to a console     
             //    //$('#example-console').text($(form).serialize());
             //    //console.log("Form submission", $(form).serialize());

             //    // Remove added elements
             //    //$('input[name="id\[\]"]', form).remove();

             //    // Prevent actual form submission
             //    e.preventDefault();
             //});

             //dom: 'Bfrtip',
             //    buttons: [
             //        {
             //            text: 'My button',
             //            action: function (e, dt, node, config) {
             //                alert('Button activated');
             //            }
             //        }
             //    ]
             //oTable.on('order.dt search.dt', function () {
             //    oTable.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
             //        cell.innerHTML = i + 1;
             //    });
             //}).draw();
             //oTable.on('order.dt search.dt', function () {
             //    oTable.column(0).nodes().each(function (cell, i) {
             //        cell.innerHTML = i + 1;
             //    });
             //}).draw();






            
         
           

        });

    </script>
 </asp:Content>
