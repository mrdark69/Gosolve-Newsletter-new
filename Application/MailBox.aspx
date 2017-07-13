<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="MailBox.aspx.cs" Inherits="_MailBox" %>

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
                width: 85% !important;
               
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
            padding:10px !important;

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

        #mailboxtextarea{
            min-height:500px;
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
                            <button class="btn btn-block btn-primary compose-mail" id="btn_add_new_campaign" >Create Mail</button>
                            <div class="space-25"></div>
                            <h5>Status</h5>
                            <ul class="folder-list m-b-md" style="padding: 0">
                                <li><a href="javascript:void(0);" data-sid="0" class="c_status"> <i class="fa fa-inbox "></i> All Mail<%-- <span class="label label-warning pull-right">16</span> --%></a></li>
                               <%-- <li><a href="javascript:void(0)"  data-sid="2" class="c_status"> <i class="fa fa-clock-o"></i> Waiting Send</a></li>--%>
                                <li><a href="javascript:void(0)"  data-sid="3" class="c_status"> <i class="fa fa-cogs"></i>Sending</a></li>
                                <li><a href="javascript:void(0)l"  data-sid="4" class="c_status"> <i class="fa fa-check-square"></i> Completed <%--<span class="label label-danger pull-right">2</span>--%></a></li>
                                <li><a href="javascript:void(0)l"  data-sid="6" class="c_status">  <i class="fa fa-stop"></i> Cancel</a></li>
                                <li><a href="javascript:void(0)"  data-sid="5" class="c_status"> <i class="fa fa-trash-o"></i> Trash</a></li>
                                
                            </ul>
                         
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
                   <span id="c-status">All Mail</span> <span id="c-total"></span>
                   
                </h2>
                <div class="mail-tools tooltip-demo m-t-md">
                    <div class="btn-group pull-right">
                        <button class="btn btn-white btn-sm" id="c_pre"><i class="fa fa-arrow-left"></i></button>
                        <button class="btn btn-white btn-sm" id="c_next"><i class="fa fa-arrow-right"></i></button>

                    </div>
                    <button class="btn btn-white btn-sm" id="c_refresh" data-toggle="tooltip" data-placement="left" title="Refresh"><i class="fa fa-refresh"></i> Refresh</button>
                  <%--  <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" title="Mark as read"><i class="fa fa-eye"></i> </button>
                    <button class="btn btn-white btn-sm" data-toggle="tooltip" data-placement="top" title="Mark as important"><i class="fa fa-exclamation"></i> </button>--%>
                    <button class="btn btn-white btn-sm" id="c_cancel" data-toggle="tooltip" data-placement="top" title="Cancel Mail"> <i class="fa fa-stop"></i> </button>
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
               
                
                </tbody>
                </table>


                </div>
            </div>
        </div>
        </div>
   
    <div class="modal inmodal fade" id="modal_mail_builder"  role="dialog"  aria-hidden="true">
                                         
                                <div class="modal-dialog modal-lg">
                                    <div class="modal-content">
                                        
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <h4 class="modal-title" id="modal_mail_1">MailBox Manage</h4>
                                            <%--<small class="font-bold">Lorem Ipsum is simply dummy text of the printing and typesetting industry.</small>--%>
                                        </div>
                                        <div class="modal-body">
                                            <div class="ibox-content" id="model_mail_builder_content">
                                                 <div class="sk-spinner sk-spinner-wave">
                                      
                                                    <div class="sk-rect1"></div>
                                                    <div class="sk-rect2"></div>
                                                    <div class="sk-rect3"></div>
                                                    <div class="sk-rect4"></div>
                                                    <div class="sk-rect5"></div>
                                                </div>
                                                   <div id="mail-text-block">
                                                       <div class="form-group" style="text-align:right;">
                                                              <button class="btn btn-success btn-b-add-template" id="btn-b-add-template" onclick="PublishCampaign()"> Publish This Mail Now <i class="fa fa-share-alt"></i></button>
                                                           <button class="btn btn-success" style="display:none;" id="btn-b-update-template" onclick="UpdateTemplate()"><i class="fa fa-save"></i> Update Mail Now</button>
                                                       </div>
                                                       <div class="form-group">
                                                            <label class="col-sm-1 control-label">
                                                                Sucscriber: </label>
                                                           <div class="col-sm-6">
                                                               <input type="text" id="mail_address" placeholder="xxx@mail.com;yyy@mail.com" class="form-control">
                                                            </div>
                                                            <div class="col-sm-5">
                                                                <label>Subscriber Group<br /><small class="text-navy">[optional]</small> </label>
                                                                <select class="select2_demo_2 form-control"  id="selec_sup" multiple="multiple">
                                                                    
                                                                </select>
                                                            </div>
                                                           
                                                            <div style="clear:both"></div>
                                                        </div>
                                                         <div class="form-group">
                                                            <label class="col-sm-1 control-label">Subject: </label>

                                                            <div class="col-sm-6"><input type="text" id="campaign_subject" placeholder="Subject" class="form-control"></div>
                                                            <label class="col-sm-1 control-label">Attach File</label>
                                                            <div class="col-sm-4"><a href="#" onclick="AddFileCustom()"><i class="fa fa-paperclip"></i> Select File: </a>&nbsp;&nbsp;
                                                            <span id="file_list_m"></span>
                                                            </div>
                                                                <div style="clear:both"></div>
                                                         </div>

                                                       <div class="form-group">
                                                                <label class="col-sm-3 control-label">unsubscription: <br>
                                                                <small class="text-navy">Would you like user action with email</small></label>
                                                                <div class="col-sm-6">
                                                                    <div><label> <input type="radio" name="SubscriptAction" value="true" checked /> Yes, user can unsubscribe this campaign</label></div>
                                                                    <div><label> <input type="radio" name="SubscriptAction" value="true" /> No, This campaign are allow to unsubscribe </label></div>
                                                                </div>
                                                              
                                                                
                                                                <div style="clear:both"></div>
                                                            </div>
                                                       <textarea id="mailboxtextarea">Hello, World!</textarea>
                                                   </div>
                                                  
                                             

                                                <div class="modal_media" id="modal_media" style="display:none;">
                                                    <div class="row">
                                                        <div class="col-md-12" style="text-align:right;padding: 5px 20px 5px 5px;">
          <button style="display:none" id="btn-custom-add-medias-m"  class="btn-custom-add-medias btn btn-success"><i class="fa fa-plus"></i> Add Image</button>
          <button style="display:none" id="btn-custom-add-medias-f" onclick="SelectFile()" class="btn-custom-add-medias btn btn-success"><i class="fa fa-paperclip"></i> Add File</button>
          <button class="btn btn-primary" onclick="CloseImageAddPanel();" id="btn-close-media">
                                                                  <i class="fa fa-window-close" aria-hidden="true" style="color:#fff"></i> Close
                                                              </button>
                                                        </div>
                                                    </div>
                                                        <div class="row">
                                                            <div class="col-md-8 col-lg-8">
                                                                <div class="ibox float-e-margins">

                                                                    <div class="ibox-content" id="media-list">
                                                                        <div class="sk-spinner sk-spinner-wave">

                                                                            <div class="sk-rect1"></div>
                                                                            <div class="sk-rect2"></div>
                                                                            <div class="sk-rect3"></div>
                                                                            <div class="sk-rect4"></div>
                                                                            <div class="sk-rect5"></div>
                                                                        </div>
                                                                        <h2>Media gallery</h2>

                                                                        <div role="form" class="form-inline">
                                                                            <div class="col-md-8">

                                                                                <div class="form-group">
                                                                                    <select id="sel_type" class="form-control">
                                                                                        <option value="">All Media Item</option>
                                                                                        <option value="image">Image</option>
                                                                                        <option value="other">Other</option>
                                                                                    </select>


                                                                                    <select id="sel_cat" class="form-control">
                                                                                        <option value="0">All Media Category</option>

                                                                                    </select>
                                                                                </div>

                                                                               
                                                                            </div>






                                                                            <div style="clear:both"></div>
                                                                        </div>

                                                                        <div class="hr-line-dashed"></div>


                                                                        <div class="lightBoxGallery" id="lightBoxGallery">


                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 col-lg-4">

                                                                <div class="ibox" id="media-detail-block">
                                                                    <div class="ibox-title"><h5>Media Detail</h5></div>
                                                                    <div class="ibox-content" id="media-detail">
                                                                        <div class="sk-spinner sk-spinner-wave">

                                                                            <div class="sk-rect1"></div>
                                                                            <div class="sk-rect2"></div>
                                                                            <div class="sk-rect3"></div>
                                                                            <div class="sk-rect4"></div>
                                                                            <div class="sk-rect5"></div>
                                                                        </div>
                                                                        <div id="media_detail_block" style="display:none;" class="form-horizontal">

                                                                            <div class="media_img_big">
                                                                                <img src="" />
                                                                            </div>

                                                                            <div style="clear:both"></div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-3 control-label">Filename:</label>

                                                                                <div class="col-sm-9">
                                                                                    <div><label class="media_file_name"> adasdas  </label></div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-3 control-label">File type:</label>

                                                                                <div class="col-sm-9">
                                                                                    <div><label class="media_file_type"> adasdas  </label></div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-3 control-label">Uploaded on:</label>

                                                                                <div class="col-sm-9">
                                                                                    <div><label class="media_file_on"> adasdas  </label></div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group">
                                                                                <label class="col-sm-3 control-label">Dimensions:</label>

                                                                                <div class="col-sm-9">
                                                                                    <div><label class="media_file_dimensions"> adasdas  </label></div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-3 control-label">File Size:</label>

                                                                                <div class="col-sm-9">
                                                                                    <div><label class="media_file_size"> adasdas  </label></div>
                                                                                </div>
                                                                            </div>



                                                                            <!--<div class="hr-line-dashed"></div>
                                                                            <div class="form-group">
                                                                                <label class="col-sm-2 control-label">Title</label>
                                                                                <div class="col-sm-10"><input type="text" class="form-control media_file_title"></div>
                                                                            </div>-->

                                                                            <div class="hr-line-dashed"></div>


                                                                            <div class="form-group">
                                                                                <div class="col-md-12">
                                                                                    <h5 class="tag-title">Category</h5>
                                                                                    <ul class="tag-list" id="tax_media_list" style="padding: 0">
                                                                                        <%--
                                                                                        <li><a href="">Family</a></li>
                                                                                        <li><a href="">Work</a></li>
                                                                                        <li><a href="">Home</a></li>
                                                                                        <li><a href="">Children</a></li>
                                                                                        <li><a href="">Holidays</a></li>
                                                                                        <li><a href="">Music</a></li>
                                                                                        <li><a href="">Photography</a></li>
                                                                                        <li><a href="">Film</a></li>--%>
                                                                                    </ul>
                                                                                    <div class="clearfix"></div>
                                                                                </div>

                                                                            </div>







                                                                        </div>

                                                                    </div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                </div>
                                            </div>
                                          
                                         
                                        </div>

                                        <div class="modal-footer">
                                            <button type="button" id="modal_mail_2" class="btn btn-white" data-dismiss="modal">Close MailBox Manage</button>
                                            <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>

</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    
    <script src="app.mailbox.js"></script>
    <script src="bower_components/tinymce/tinymce.min.js"></script>
  <%--  <script src="bower_components/tinymce/jquery.tinymce.min.js"></script> ?ver=<%= DateTime.Now.ApiService_DateToTimestamp() %>
    <script src="bower_components/tinymce/tinymce.jquery.min.js"></script>--%>
   <script type="text/javascript">

       $(document).ready(function () {

           $.fn.modal.Constructor.prototype.enforceFocus = $.noop;
           store.clearAll();
           $('form').bind('submit', function (e) {
               e.preventDefault();
               // etc
           });

           
           $('#modal_mail_builder').on('shown.bs.modal', function () {
               $(".select2_demo_2").select2({ dropdownParent: $('#modal_mail_builder') });

               store.remove('fileat');

               var sel = store.get('ItemSel');
               if (sel != null) {

                   $(tinymce.get('mailboxtextarea').getBody()).html(sel.EL.html);

                   $('#t-title').val((sel.Title == null ? "" : sel.Title));
                   $('#campaign_subject').val(sel.Subject);

                  // $('input[name="SubscriptAction"]').val(sel.Unsub);

                   //$('input[name="Sub_sendNow"]').val(sel.IsSchedule);

                   var $radiosSubscriptAction = $('input[name="SubscriptAction"]');
                   $radiosSubscriptAction.removeAttr('checked');
                   $radiosSubscriptAction.filter('[value=' + sel.Unsub + ']').prop('checked', true);

                  
                   //var s = $(".select2_demo_2").select2('val');
                   $('#mail_address').val(sel.Mailaddress);
                   $(".select2_demo_2").select2('val', sel.SG.split(','));
                   //var a = moment(sel.DateTimePublish);

                  // $('#data_1').val(a.format('MM/DD/YYYY'));
                   //$('.clockpicker input').val(a.format('HH:MM'));

                   if (sel.FileMail != "")
                    store.set('fileat', JSON.parse(sel.FileMail));

                   var fn = store.get('fileat');
                   var f = "";
                   for (var i in fn) {
                       f += "[" + fn[i].FileName + "] ";
                   }


                   $('#file_list_m').html(f);
                   //store.get('fileat')
                   //var a = moment(d + " " + c, 'MM/DD/YYYY HH:mm', true);

               }


         

           });

           BindCreateMail();
           GetSubscriberGroup();
           GetTemplatelist();
           BindEvent();

         

       });

       function CheckProgress() {

          

           var url = "<%= ResolveUrl("/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/GetAll_checkprocess") %>";

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

           AjaxPost(url, param,null, function (ret) {
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

       function BindCreateMail() {
           $(document).find('button#btn_add_new_campaign')
               .on('click', function (e) {

                   e.preventDefault;
                   
                   $('#t-title').val('');
                   
                   $('#btn-b-update-template').hide();
                   $('#btn-b-add-template').show();
                   
                   $('#modal_mail_builder').modal({
                       backdrop: 'static',
                       keyboard: false
                   });
                   

               });
           
       }
      

       function GetTemplatelist() {
           var url = "<%= ResolveUrl("/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/GetAll") %>";

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

            AjaxPost(url, param, function () {
                $('#main-campaign-list').addClass('sk-loading');
            }, function (data) {

                
                store.set('all_mailbox', data);

                GenerateHtmlCampaign(data);

                setTimeout(function () {

                    CheckProgress();

                    $('#main-campaign-list').removeClass('sk-loading');

                    BindEditmode();
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

                            store.set('jqueryEmail_mailbox', sel[0].EL);


                        }

                    })


                   

                }, 1000);
            });
        }

   </script>
    
</asp:Content>
