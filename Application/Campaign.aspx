<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Campaign.aspx.cs" Inherits="_Campaign" %>
<asp:Content ID="HeaderScript" ContentPlaceHolderID="HeaderScript" runat="server">

    <style type="text/css">

        form{
            height:100% !important;
        }
        /*.modal-dialog {
          width: 100%;
          height: 100%;
          margin: 0;
          padding: 0;
        }

        .modal-content {
          height: auto;
          min-height: 100%;
          border-radius: 0;
        }*/
        @media screen and (min-width: 768px)
        {
            .modal-dialog {
                width: 95% !important;
               
            }
        }
        .app{
            z-index:5000 !important;
        }
        .email-builder-component{
             z-index:5000 !important;
        }
        .alertify{
             z-index:5000 !important;
        }

        .inmodal .modal-header {
          
            z-index: 5;
            position: relative;
            background-color: #fff;
        }
        #email-builder>.email-builder-preview-actions{
            top:-55px !important;
        }



        #email-builder .email-builder-header {
            
            top: -2px !important;
           
        }

        #email-builder .email-builder-content {
            margin-top: 55px !important;
            
        }

        .alertify-logs{
            z-index:5000 !important;
        }

        .material-icons{
            color:#fff ;
        }
        .md-btn-group{
            font-size:12px;
        }

        #email-builder .email-builder-header{
            box-shadow:none !important;
        }
        #email-builder>.email-builder-preview-actions.preview{
            box-shadow:none !important;
        }
        /*.note-editor.note-frame.fullscreen{
            z-index:3000 !important;
        }*/

        .modal_media{
            height:100% ;
            background-color:#f8fafb;
        }
        #btn-custom-add-media button{
            margin-right:2px;
        }

        #main-template-list{
            padding:0 !important;
        }
        .html-body-content{
            margin-top:60px;
        }

        .modal-body .ibox-content{
            padding:0px !important;

        }
        .modal-body {
         padding: 10px 30px 30px 30px !important;
        }
        span.select2-container {
            z-index:10050;
            width:50% !important;
        }
        .campaign-option-pan .form-group{
            margin-bottom:5px;
        }
        #email-builder .email-builder-header-actions {
            display: inline-block;
            /* display: flex; */
            /* justify-content: center; */
            width: 100%;
            text-align: right;
        }
        #option-campaign-click{
            margin-left:10px;
            padding-top:10px;
        }
        .clockpicker-popover {
        z-index: 999999 !important;
        }
        .unread td a, .unread td{
            font-weight:normal !important;
        }
    </style>

      <style id="builder-styles">table,table td{border-collapse:collapse}body{margin:0;padding:0}a,body,li,p,table,td{-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%}a{word-wrap:break-word}table{border-spacing:0}table,td{mso-table-lspace:0;mso-table-rspace:0};@media only screen and (max-width:640px){td[class=image-full],td[class=divider-full],td[class=buttons-full-width],td[class=buttons-full-width] a,td[class=buttons-full-width] span{padding-left:0!important;padding-right:0!important}table[class=main],td[class=main]{width:100%!important;min-width:200px!important}table[class=logo-img],table[class=image-in-table],table[class=text-column]{width:100%!important;float:none;margin-bottom:15px}table[class=logo-img] td,table[class=links] td,td[class=footer-side],td[class=social-links]{text-align:center!important}table[class=image-caption-column],table[class=logo-title],table[class=button]{width:100%!important;float:none}table[class=logo-title] td{text-align:center;height:auto}table[class=logo-title] h1,td[class=header] h1,td[class=title] h1{font-size:24px!important}table[class=logo-title] h2{font-size:18px!important}table[class=image-in-table] img,td[class=image-caption-content] img,td[class=image] img,td[class=image-full] img,td[class=header-img] img{width:100%!important;height:auto!important}td[class=footer],td[class=image],td[class=image-group],td[class=image-text],td[class=divider-simple],td[class=social],td[class=buttons],td[class=content-buttons],td[class=title],td[class=block-text],td[class=two-columns],td[class=image-caption]{padding-left:15px!important;padding-right:15px!important}td[class=image-caption-content] h2,td[class=text] h2,td[class=block-text] h2{font-size:20px!important;line-height:170%!important}td[class=image-caption-content] p,td[class=text] p,td[class=image-text] p,td[class=block-text] li,td[class=block-text] p{font-size:16px!important;line-height:170%!important}table[class=image-in-table] td,table[class=links],table[class=image-caption-container],td[class=text],td[class=image-text]>table{width:100%!important}td[class=image-caption-top-gap]{height:15px!important}td[class=image-caption-bottom-gap]{height:5px!important}table[class=preheader],td[class=gap],td[class=preheader-gap],td[class=preheader-link],tr[class=header-nav]{display:none}td[class=header]{padding:25px!important}td[class=header] h2{font-size:20px!important}td[class=footer] p{font-size:13px!important}table[class=footer-side],table[class=content]{width:100%!important;float:none!important}table[class=footer-social-icons]{float:none!important;margin:0 auto!important}td[class=social-icon-link]{padding:0 5px!important}td[class=image-group] img{width:100%!important;height:auto!important;margin:15px 0!important}td[class=preheader-text]{width:100%}td[class=buttons-full-width] a{width:100%!important;border-radius:0!important}td[class=buttons-full-width] span{width:100%!important}td[class=gallery-image]{width:100%!important;padding:0!important}table[class=social],td[class=head-logo]{width:100%!important;text-align:center!important}table[class=footer-btn]{text-align:center!important;width:100%!important;margin-bottom:10px}table[class=footer-btn-wrap]{margin-bottom:0;width:100%!important}td[class=head-social]{width:100%!important;text-align:center!important;padding-top:20px}}td.video.fullWidth iframe{width: 100%}</style>


    <link rel="stylesheet" href="app.min.css">
   <%--  <link href="/Content/plugins/summernote/summernote.css" rel="stylesheet">
    <link href="/Content/plugins/summernote/summernote-bs3.css" rel="stylesheet">--%>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content">
        <div class="row" >
            <div class="col-lg-3">
                <div class="ibox float-e-margins">
                    

                    <div class="ibox-content mailbox-content">
                        <div class="file-manager">
                            <button class="btn btn-block btn-primary compose-mail" id="btn_add_new_campaign" >Create Campaign</button>
                            <div class="space-25"></div>
                            <h5>Status</h5>
                            <ul class="folder-list m-b-md" style="padding: 0">
                                <li><a href="javascript:void(0);" data-sid="0" class="c_status"> <i class="fa fa-inbox "></i> All Campaign<%-- <span class="label label-warning pull-right">16</span> --%></a></li>
                             <%--   <li><a href="javascript:void(0)"  data-sid="2" class="c_status"> <i class="fa fa-clock-o"></i> Waiting Send</a></li>--%>
                                <li><a href="javascript:void(0)"  data-sid="3" class="c_status"> <i class="fa fa-cogs"></i>Sending</a></li>
                                <li><a href="javascript:void(0)l"  data-sid="4" class="c_status"> <i class="fa fa-check-square"></i> Completed <%--<span class="label label-danger pull-right">2</span>--%></a></li>
                                <li><a href="javascript:void(0)l"  data-sid="6" class="c_status">  <i class="fa fa-stop"></i> Cancel</a></li>
                                <li><a href="javascript:void(0)"  data-sid="5" class="c_status"> <i class="fa fa-trash-o"></i> Trash</a></li>
                                
                            </ul>
                           <%-- <h5>Categories</h5>
                            <ul class="category-list" style="padding: 0">
                                <li><a href="#"> <i class="fa fa-circle text-navy"></i> Work </a></li>
                                <li><a href="#"> <i class="fa fa-circle text-danger"></i> Documents</a></li>
                                <li><a href="#"> <i class="fa fa-circle text-primary"></i> Social</a></li>
                                <li><a href="#"> <i class="fa fa-circle text-info"></i> Advertising</a></li>
                                <li><a href="#"> <i class="fa fa-circle text-warning"></i> Clients</a></li>
                            </ul>--%>

<%--                            <h5 class="tag-title">Labels</h5>
                            <ul class="tag-list" style="padding: 0">
                                <li><a href=""><i class="fa fa-tag"></i> Family</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Work</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Home</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Children</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Holidays</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Music</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Photography</a></li>
                                <li><a href=""><i class="fa fa-tag"></i> Film</a></li>
                            </ul>--%>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-9 animated fadeInRight ">
               
            <div class="mail-box-header">

                <div  class="pull-right mail-search">
                    <%--<div class="input-group">
                        <input type="text" class="form-control input-sm" name="search" placeholder="Search email">
                        <div class="input-group-btn">
                            <button type="submit" class="btn btn-sm btn-primary">
                                Search
                            </button>
                        </div>
                    </div>--%>
                </div>
                <h2>
                   <span id="c-status">All Campaign</span> <span id="c-total"></span>
                   
                </h2>
                <div class="mail-tools tooltip-demo m-t-md">
                    <div class="btn-group pull-right">
                        <button class="btn btn-white btn-sm" id="c_pre"><i class="fa fa-arrow-left"></i></button>
                        <button class="btn btn-white btn-sm" id="c_next"><i class="fa fa-arrow-right"></i></button>

                    </div>
                    <button class="btn btn-white btn-sm" id="c_refresh" data-toggle="tooltip" data-placement="left" title="Refresh inbox"><i class="fa fa-refresh"></i> Refresh</button>
                  <%--  <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" title="Mark as read"><i class="fa fa-eye"></i> </button>
                    <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" title="Mark as important"><i class="fa fa-exclamation"></i> </button>--%>
                    <button class="btn btn-white btn-sm" id="c_cancel" data-toggle="tooltip" data-placement="top" title="Mark as read"> <i class="fa fa-stop"></i> </button>
                    <button class="btn btn-white btn-sm" id="c_bin" data-toggle="tooltip" data-placement="top" title="Move to trash"><i class="fa fa-trash-o"></i> </button>
                   
                </div>
            </div>
                <div class="mail-box ibox-content" id="main-campaign-list">
                    
                     <div class="sk-spinner sk-spinner-wave">
                                      
                                        <div class="sk-rect1"></div>
                                        <div class="sk-rect2"></div>
                                        <div class="sk-rect3"></div>
                                        <div class="sk-rect4"></div>
                                        <div class="sk-rect5"></div>
                                    </div>

                <table class="table table-hover table-mail">
                <tbody id="data-campaign-list">
               <%-- <tr class="unread">
                    <td class="check-mail">
                        <input type="checkbox" class="i-checks">
                    </td>
                    <td class="mail-ontact"><a href="mail_detail.html">Anna Smith</a></td>
                    <td class="mail-subject"><a href="mail_detail.html">

                         <small>Completion with: 8%</small>
                                            <div class="progress progress-mini">
                                                <div style="width: 90%;" class="progress-bar"></div>
                                            </div>

                                             </a></td>


                    <td class=""><i class="fa fa-paperclip"></i></td>
                    <td class="text-right mail-date">6.10 AM</td>
                </tr>--%>
                
                </tbody>
                </table>


                </div>
            </div>
        </div>
        </div>
   
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
     <!-- iCheck -->
  <script src="common.min.js"></script><!-- inject:js -->
    <script src="app.cam.js"></script><!-- endinject --><%--?ver=<%= DateTime.Now.ApiService_DateToTimestamp() %>--%>
    <script>
        //$(document).ready(function () {
        //    $('.i-checks').iCheck({
        //        checkboxClass: 'icheckbox_square-green',
        //        radioClass: 'iradio_square-green',
        //    });
        //});
    </script>
   
    <script>

     
        $(document).ready(function () {

            $.fn.modal.Constructor.prototype.enforceFocus = $.noop;
           
            $('#modal_builder_1').html('Campaign Manage');
            $('#modal_builder_2').html('Close Campaign Manage');

            store.clearAll();


            $('form').bind('submit', function (e) {
                e.preventDefault();
                // etc
            });

            $('#modal_html_builder').on('shown.bs.modal', function () {
              //  $(document).off('focusin.modal');

                $(".select2_demo_2").select2({ dropdownParent: $('#modal_html_builder') });

                $('.clockpicker').clockpicker();

                $('#data_1').datepicker({
                    setDate: 'now',
                    todayBtn: "linked",
                    keyboardNavigation: false,
                    forceParse: false,
                    calendarWeeks: true,
                    autoclose: true
                });

                var sel = store.get('ItemSel');
                if (sel != null) {
                    $('#t-title').val((sel.Title == null ? "" : sel.Title));
                    $('#campaign_subject').val(sel.Subject);


                    var $radiosSubscriptAction = $('input[name="SubscriptAction"]');
                    $radiosSubscriptAction.removeAttr('checked');
                    $radiosSubscriptAction.filter('[value=' + sel.Unsub + ']').prop('checked', true);
                    //if ($radiosSubscriptAction.is(':checked') === false) {
                       
                    //}
                    //$('input[name="SubscriptAction"]').val(sel.Unsub);


                    var $radiosSubsend_now = $('input[name="Sub_sendNow"]');
                    $radiosSubsend_now.removeAttr('checked');
                    $radiosSubsend_now.filter('[value=' + sel.IsSchedule + ']').prop('checked', true);

                    //if ($radiosSubsend_now.is(':checked') === false) {
                        
                    //}
                    //$('input[name="Sub_sendNow"]').val(sel.IsSchedule);
                   
                    //var s = $(".select2_demo_2").select2('val');

                    $(".select2_demo_2").select2('val',sel.SG.split(','));
                    var a = moment(sel.DateTimePublish);

                    $('#data_1').val(a.format('MM/DD/YYYY'));
                    $('.clockpicker input').val(a.format('HH:MM'));
                  

                    store.set('fileat', JSON.parse(sel.FileMail));

                    var fn = store.get('fileat');
                    var f = "";
                    for (var i in fn) {
                      f += "[" + fn[i].FileName + "] ";
                    }
                 

                    $('#file_list_m').append(f);
                    //store.get('fileat')
                    //var a = moment(d + " " + c, 'MM/DD/YYYY HH:mm', true);

                }


            });

            // GetTemplatelist();
            //GetSubscriberGroup();

           // BindEvent();
        });


        


        function GetSubscriberGroup() {
            var url = "<%= ResolveUrl("/Application/ajax/subscriber/ajax_webmethod_subscriber.aspx/GetAll") %>";



            var data = {};

            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, null, function (data) {


                console.log(data);
                ret = '';

                for (var i in data) {
                    ret += '<option value="' + data[i].SGID + '">' + data[i].SGName+'</option>';
                     
                }
                //ret += '';
                //ret += '';
                //ret += '';
                //ret += '';
                //ret += '';
                $('#selec_sup').html(ret);
               
                //setTimeout(function () {
                   
                    

                //}, 1000);
            });
        }

        function GetTemplatelist(callback, p) {
            var url = "<%= ResolveUrl("/Application/ajax/campaign/ajax_webmethod_campaign.aspx/GetAll") %>";

            var data = {};
            if (store.get('rawdata') == null) {
                 data = {
                    Start: 0,
                    Size: 15,
                    CSID: 0
                };
                 store.set("rawdata", data);
            } else {
                data = store.get('rawdata');
            }
            
           // var data = {};
     

            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {
                $('#main-campaign-list').addClass('sk-loading');
            }, function (data) {

               
                store.set('all_campaign', data);

                GenerateHtmlCampaign(data);
               
                setTimeout(function () {


                    CheckProgress();
                    $('#main-campaign-list').removeClass('sk-loading');


                    $('.i-checks').iCheck({
                        checkboxClass: 'icheckbox_square-green',
                        radioClass: 'iradio_square-green',
                    });

                    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                        e.target // newly activated tab
                        e.relatedTarget // previous active tab


                        var tid = $(this).closest('.list-group-item').data('keyid');

                        var alldata = store.get('all_template');

                        var sel = alldata.filter(function (el) {
                            return el.TID == tid;
                        });

                        if (sel) {
                            store.set('TemplateSel', sel[0]);

                            store.set('jqueryEmail', sel[0].EL);


                        }

                    })


                    if (callback != 'undefined' && typeof callback == 'function') {
                        callback(p);
                    }

                }, 1000);
            });
        }


        function BindEvent() {

            $('#c_next').on('click', function () {
                var raw = store.get('rawdata');
                var p = raw.Start;

                raw['Start'] = p + raw.Size;

                store.set("rawdata", raw);

                GetTemplatelist();
            });

            $('#c_pre').on('click', function () {
                var raw = store.get('rawdata');
                var p = raw.Start;

                var pp = p - raw.Size;
                raw['Start'] = (pp < 0 ? 0 : pp);

                store.set("rawdata", raw);

                GetTemplatelist();
            });


            $('.c_status').on('click', function () {
                var s = $(this).data('sid');
                var raw = store.get('rawdata');

                $('#c-status').html($(this).html());
                raw['CSID'] = s;
                store.set("rawdata", raw);
                GetTemplatelist();

                return false;
            })


            $('#c_refresh').on('click', function () {
                GetTemplatelist();
            });

            $('#c_cancel').on('click', function () {

                var ch = [];
                if ($('.i-checks:checked').length) {
                   $.each($('.i-checks:checked'), function () {

                        ch.push($(this).val());
                    });
                }
               
                console.log(ch);

                if (ch.length > 0) {

                    swal({
                        title: "Are you sure?",
                        text: "คุณต้องการยกเลิก การใช้งาน รายการที่ท่านเลือกใช่หรือไม่",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Yes, Cancel it!",
                        closeOnConfirm: false
                    }, function () {




                        var url = "<%= ResolveUrl("/Application/ajax/campaign/ajax_webmethod_campaign.aspx/Cancel") %>";
                            var param = JSON.stringify({ parameters: ch });
                            AjaxPost(url, param, null, function (data) {
                                if (data.success) {

                                    toastr.success('Notification', data.msg);
                                    
                                    GetTemplatelist();

                                }

                            });

                            swal.close();

                        });


                } else {
                    swal({
                        title: "Please Check less one",
                        text: "กรุณาเลือก รายการอย่างน้อย 1 รายการ"
                    });

                }

                

            });


            $('#c_bin').on('click', function () {
                var ch = [];
                if ($('.i-checks:checked').length) {
                    $.each($('.i-checks:checked'), function () {

                        ch.push($(this).val());
                    });
                }

                if (ch.length > 0) {

                    swal({
                        title: "Are you sure?",
                        text: "คุณต้องการที่จะ ย้ายรายการที่เลือกลงสู่ Trash ใช่หรือไม่",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonColor: "#DD6B55",
                        confirmButtonText: "Yes, Trash it!",
                        closeOnConfirm: false
                    }, function () {




                        var url = "<%= ResolveUrl("/Application/ajax/campaign/ajax_webmethod_campaign.aspx/Trash") %>";
                             var param = JSON.stringify({ parameters: ch });
                             AjaxPost(url, param, null, function (data) {
                                 if (data.success) {

                                     toastr.success('Notification', data.msg);

                                     GetTemplatelist();

                                 }

                             });

                             swal.close();

                         });


                 } else {
                     swal({
                         title: "Please Check less one",
                         text: "กรุณาเลือก รายการอย่างน้อย 1 รายการ"
                     });

                 }
            });
        }

        function GenerateHtmlCampaign(data) {
            var ret = '';
            var total = 0;
            var scid = 0;
            var scidtitle = 'All Campaign';
            if (data.length > 0) {
                for (var t in data) {
                    var a = moment(data[t].CreateDateLocal);
                    var r = "unread";
                    if (t % 2 != 0) {
                        r = "read"
                    }

                    var l = "label-primary";
                    switch (data[t].CSID){
                        case 6:
                            l = 'label-warning';
                            break;
                        case 5:
                            l = 'label-danger';
                            break;
                        case 4:
                            l = 'label-success';
                            break;
                    }


                    var percent = 0;
                    var total = data[t].TotalSend;
                    var sent = data[t].TotalSent;

                    percent = (parseFloat(sent) * 100) / parseFloat(total);

                    var ss = '<span id="status_title_' + data[t].CID + '" class="status_title_ label ' + l + ' pull-right">' + data[t].CSIDTitle + '</span>';

                    ret += ' <tr class="' + r + '">';
                    ret += '    <td class="check-mail">';
                    ret += '         <input type="checkbox" name="c_check[]" class="i-checks" value="' + data[t].CID + '">';
                    ret += '     </td>';
                    ret += '        <td class="mail-subject" ><a href="javascript:void(0);" class="item-edit" data-ssid="' + data[t].CSID + '" data-cid="' + data[t].CID + '">' + data[t].Subject + '</a>' + ss + '</td>';
                    ret += '        <td class="mail-ontact"><small>Completion with: <span class="percent_process" id="percent_process' + data[t].CID + '">' + parseInt(percent) + '</span>%</small>';
                    ret += '        <div class="progress progress-mini">';
                    ret += '        <div  id="percent_process_bar' + data[t].CID + '" style="width:' + parseInt(percent) + '%"  class="progress-bar"></div>';
                    ret += '        </div></td>';

                    ret += '        <td class=""> ' + (data[t].FileMail != "" ? '<i class="fa fa-paperclip"></i>' : '') + '  </td>';
                    ret += '         <td class="text-right mail-date">' + a.format("llll") + '</td>';
                    ret += ' </tr>';

                }

                var status = "";
                total = data[0].TotalRows;
                scid = data[0].CSID;
                scidtitle = data[0].CSIDTitle;
            } else{
                ret = '<tr><td colspan="5">No record</td></tr>';
                total = 0;
            }

            if (total < store.get('rawdata').Size) {
                $('#c_next').attr("disabled", "disabled");
            } else {
                $('#c_next').removeAttr("disabled");
            }


            if (store.get('rawdata').Start == 0) {
                $('#c_pre').attr("disabled", "disabled");
            } else
            {
                $('#c_pre').removeAttr("disabled");
            }

            $('#c-total').html( "(" + total + ")");
           
            $('#data-campaign-list').html(ret);

        }


        function UpdateTemplate(callback) {
            var url = "<%= ResolveUrl("/Application/ajax/campaign/ajax_webmethod_campaign.aspx/UpdateCampaign") %>";

            var el = store.get('jqueryEmail');



            if (el) {

                var t = store.get('ItemSel');
                var sj = $('#campaign_subject').val();
                var s = $(".select2_demo_2").select2('val');
                var tt = $('#t-title').val();
                var r = $('input[name="SubscriptAction"]:checked').val();

                var tm = $('input[name="Sub_sendNow"]:checked').val();
                var d = $('#data_1').val();
                var c = $('.clockpicker input').val();



                var a = moment(d + " " + c, 'MM/DD/YYYY HH:mm', true);


                var cid = 0;
                var eid = "";
                if (t) {
                    eid = t.EID;
                    cid = t.CID;
                }
                var data = {
                    CID: cid,
                    EID: eid,
                    Title: tt,
                    EL: el,
                    SGarr: s,
                    Subject: sj,
                    Unsub: r,
                    IsSchedule: tm,
                    CSID: 1,
                    DateTimePublish: a.format(),
                    FileMail: JSON.stringify(store.get('fileat'))
                };

                var param = JSON.stringify({ parameters: data });

                AjaxPost(url, param, function () {
                    $('#model_html_builder_content').addClass('sk-loading');
                }, function (data) {

                    if (data.EID) {

                        toastr.success('Notification', "Campaign is updated!!");

                        store.set('ItemSel', data);



                        setTimeout(function () {
                            GetTemplatelist(callback);

                            $('#model_html_builder_content').removeClass('sk-loading');

                            $('#modal_html_builder').modal('hide');

                        }, 1000);
                    }
                });
            }

        }

        function AddnewCampaign(callback, p) {
            var url = "<%= ResolveUrl("/Application/ajax/campaign/ajax_webmethod_campaign.aspx/InsertNewCampaign") %>";

            var el = store.get('jqueryEmail');

           

            if (el) {

                var t = store.get('CampaignSel');
                var sj = $('#campaign_subject').val();
                var s = $(".select2_demo_2").select2('val');
                var tt = $('#t-title').val();
                var r = $('input[name="SubscriptAction"]:checked').val();

                var tm = $('input[name="Sub_sendNow"]:checked').val();
                var d = $('#data_1').val();
                var c = $('.clockpicker input').val();

               

                var a = moment(d + " " + c, 'MM/DD/YYYY HH:mm', true); 

                
                var cid = 0;
                if (t) {

                    cid = t.CID;
                }
                var data = {
                    CID: cid,
                    Title: tt,
                    EL: el,
                    SGarr: s,
                    Subject: sj,
                    Unsub: r,
                    IsSchedule: tm,
                    CSID:1,
                    DateTimePublish: a.format(),
                    FileMail: JSON.stringify(store.get('fileat')) 
                };

                var param = JSON.stringify({ parameters: data });

                AjaxPost(url, param, function () {
                    $('#model_html_builder_content').addClass('sk-loading');
                }, function (data) {

                    if (data.EID) {

                        toastr.success('Notification', "Add New Campaign Successful!!!");

                        store.set('TemplateSel', data);



                        setTimeout(function () {
                            GetTemplatelist(callback, p);

                            $('#model_html_builder_content').removeClass('sk-loading');

                            $('#modal_html_builder').modal('hide');

                        }, 1000);
                    }


                    
                });
            }

        }


        function CheckProgress() {



            var url = "<%= ResolveUrl("/Application/ajax/campaign/ajax_webmethod_campaign.aspx/GetAll_checkprocess") %>";

            var data = {};
            if (store.get('rawdata_mailbox') == null) {
                data = {
                    Start: 0,
                    Size: 15,
                    CSID: 0
                };
                store.set("rawdata_mailbox", data);
            } else {
                data = store.get('rawdata_mailbox');
            }

            // var data = {};


            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, null, function (ret) {
                console.log(ret);
                for (var i in ret) {






                    var total = ret[i].TotalSend;
                    var sent = ret[i].TotalSent;

                    var percent = (parseFloat(sent) * 100) / parseFloat(total);

                    $('#percent_process' + ret[i].CID).html(parseInt(percent));
                    $('#percent_process_bar' + ret[i].CID).width(parseInt(percent) + '%');


                    if (ret[i].CSID == 4 && parseInt(percent) >= 100) {
                        $('#status_title_' + ret[i].CID).html('Completed');
                        $('#status_title_' + ret[i].CID).removeClass('label-primary');
                        $('#status_title_' + ret[i].CID).addClass('label-success');
                    }
                }

                var arr = jQuery.grep(ret, function (n, i) {
                    return (n.CSID == 3);
                });

                if (arr.length > 0) {
                    setTimeout('CheckProgress()', 2000);
                }


            });


        }

        function BindingCat() {
            var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/GetMediaCat") %>";

            var data = {};
            var param = JSON.stringify({ parameters: data });
            AjaxPost(url, param, null, function (data) {
                store.set("Cat_data", data);


                HtmlBinding();

            });
        }

        function HtmlBinding() {

            var data = store.get("Cat_data");
            var ret = "";
            for (var i in data) {
                ret += '<option value="' + data[i].TaxID + '">' + data[i].Title + '</option>';
            }


            $('#sel_cat').append(ret);
            // $('#select-form-detail-cat').append(ret);
            //$('#sel-update-media-bulk').append(ret);
        }

        function getTemplateall() {
            var url = "<%= ResolveUrl("/Application/ajax/template/ajax_webmethod_template.aspx/GetAll") %>";

            var data = {  };
            var param = JSON.stringify({ parameters: data });
            AjaxPost(url, param, function () {
                $('#media-list_template').addClass('sk-loading');
            }, function (data) {

                store.set('all_template', data);

                $('#lightBoxGallery_template').html(generateTemplateData(data));



                $('.template-block').on('click', function () {
                    var chek = $(this).find(':checkbox');
                    var a = $(this).find('a.img_data');

                    $('.template-block').removeClass('media-block-selected');

                    $('.template-block').find(':checked').removeAttr("checked");

                    //Toggle Checkbox Select
                    chek.prop("checked", function (i, val) {
                        return !val;
                    });

                    if (chek.prop("checked")) {
                        var alldata = store.get('all_template');

                        var sel = alldata.filter(function (el) {
                            return el.TID == chek.val();
                        });

                        if (sel) {
                            store.set('TemplateSel', sel[0]);
                            store.set('jqueryEmail', sel[0].EL);
                        }
                    }
                    


                });

               
                setTimeout(function () {
                    $('#media-list_template').removeClass('sk-loading');
                }, 1000);
            });
        }
        function getmediall() {

            var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/GetMedia") %>";

            var data = { Tax: $("#sel_cat").val(), Type: $("#sel_type").val() };
            var param = JSON.stringify({ parameters: data });
            AjaxPost(url, param, function () {
                $('#media-list').addClass('sk-loading');
            }, function (data) {

                $('#lightBoxGallery').html(generateMediaData(data));

                $('.media-block').on('click', Click_BindingToRightDetail);

                store.remove('key_onSel');
                $("#media_detail_block").hide();

                setTimeout(function () {
                    $('#media-list').removeClass('sk-loading');
                }, 1000);
            });

        }

        
        function Click_BindingToRightDetail() {



            var chek = $(this).find(':checkbox');
            var a = $(this).find('a.img_data');

            $('.media-block').removeClass('media-block-selected');

            $('.media-block').find(':checked').removeAttr("checked");

            //Toggle Checkbox Select
            chek.prop("checked", function (i, val) {
                return !val;
            });

            if (chek.prop("checked")) {

                $(this).addClass('media-block-selected');
            }

            if (chek.prop("checked")) {
                // var data = JSON.parse(decodeURIComponent(a.data('gallery')));
                var getData = store.get("key_" + chek.val());

                //set select
                store.set("key_onSel", getData);
            }


            var data = store.get("key_onSel");


            $('.media-block .icon-check').hide();
            $('#block_' + data.MID + ' .icon-check').show();
            //$(this).find('.icon-check').show();

            //if ($('.media-block').find(':checked').length == 0) {
            //    $('.media-block .icon-check').hide();
            //}

            var string = data.FileType,
                expr = /image/;  // no quotes here

            if (expr.test(string)) {
                $('.media_img_big').show();
            } else {
                $('.media_img_big').hide();
            }


            var url = data.Path + "/" + data.FileName;
            $('#media_detail_block .media_img_big').find('img').prop('src', url);


            var fn = $('#media_detail_block').find('label.media_file_name');
            var fy = $('#media_detail_block').find('label.media_file_type');
            var fo = $('#media_detail_block').find('label.media_file_on');
            var fd = $('#media_detail_block').find('label.media_file_dimensions');
            var ft = $('#media_detail_block').find('input.media_file_title');

            var fs = $('#media_detail_block').find('label.media_file_size');

            fn.html(data.FileName);
            fy.html(data.FileType);
            fo.html(data.DateUpload);
            fd.html(data.Dimensions);
            // ft.val(data.Title);
            fs.html(data.FileSizeFormat);




            var MediaTax = data.MediaTax;


            BindingTax(MediaTax);


            $("#media_detail_block").show();


            var allcheck = $('#lightBoxGallery').find('input[name="media_checkbox"]:checked');
            console.log(allcheck.length);
            if (allcheck.length == 0) {
                $("#media_detail_block").hide();
            }

            return false;
        }
        function BindingTax(MediaTax, append = false) {
            var taxlist = '';
            for (var i in MediaTax) {
                taxlist += '<li><a href="javascript:void(0);">' + MediaTax[i].Title + '</a></li>';
            }
            if (append) {
                $('#tax_media_list').append(taxlist);
            } else {
                $('#tax_media_list').html(taxlist);
            }


        }


        function generateTemplateData(data) {
            var ret = "";
            for (d in data) {
                var url = data[d].DemoPath + "/" + data[d].DemoFileName;
               // store.set("key_" + data[d].MID, data[d]);
                //encodeURIComponent(JSON.stringify(data[d])) style="display:none;
                ret += '<div class="template-block" id="t-block_' + data[d].TID + '">';
                ret += '<input type="checkbox" value="' + data[d].TID + '" name="media_checkbox"  id="media_checkbox" />';
                ret += '<a href= "javascript:void(0)" class="img_data" title="' + data[d].Title + '" >';

                ret += '<img class="img-responsive" src="' + url + '">';


                ret += '</a><button class="icon-check btn btn-info btn-circle" type="button"  onclick="return false;" style="display:none;"><i class="fa fa-check"></i></button > </div >';
            }
            // style="display:none;" <i style="display:none;" class="icon-check fa fa-certificate"></i> 
            return ret;
        }

        function generateMediaData(data) {
            var ret = "";
            for (d in data) {
                var url = data[d].Path + "/" + data[d].FileName;
                store.set("key_" + data[d].MID, data[d]);
                //encodeURIComponent(JSON.stringify(data[d]))
                ret += '<div class="media-block" id="block_' + data[d].MID + '">';
                ret += '<input type="checkbox" value="' + data[d].MID + '" name="media_checkbox" style="display:none; id="media_checkbox" />';
                ret += '<a href= "javascript:void(0)" class="img_data" title="' + data[d].Title + '" >';

                var string = data[d].FileType,
                    expr = /image/;  // no quotes here

                if (expr.test(string)) {
                    ret += '<img class="img-responsive" src="' + url + '">';
                } else {
                    ret += '<div class="media-doc" ><i class="fa fa-file"></i>  <span style="font-size:11px;color:#cccccc;">' + data[d].FileName + '</span></div>';
                }


                ret += '</a><button class="icon-check btn btn-info btn-circle" type="button"  onclick="return false;" style="display:none;"><i class="fa fa-check"></i></button > </div >';
            }
            // style="display:none;" <i style="display:none;" class="icon-check fa fa-certificate"></i> 
            return ret;
        }
    </script>
</asp:Content>
 