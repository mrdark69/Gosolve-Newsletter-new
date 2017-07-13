<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Template.aspx.cs" Inherits="Template" %>

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
    </style>

      <style id="builder-styles">table,table td{border-collapse:collapse}body{margin:0;padding:0}a,body,li,p,table,td{-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%}a{word-wrap:break-word}table{border-spacing:0}table,td{mso-table-lspace:0;mso-table-rspace:0};@media only screen and (max-width:640px){td[class=image-full],td[class=divider-full],td[class=buttons-full-width],td[class=buttons-full-width] a,td[class=buttons-full-width] span{padding-left:0!important;padding-right:0!important}table[class=main],td[class=main]{width:100%!important;min-width:200px!important}table[class=logo-img],table[class=image-in-table],table[class=text-column]{width:100%!important;float:none;margin-bottom:15px}table[class=logo-img] td,table[class=links] td,td[class=footer-side],td[class=social-links]{text-align:center!important}table[class=image-caption-column],table[class=logo-title],table[class=button]{width:100%!important;float:none}table[class=logo-title] td{text-align:center;height:auto}table[class=logo-title] h1,td[class=header] h1,td[class=title] h1{font-size:24px!important}table[class=logo-title] h2{font-size:18px!important}table[class=image-in-table] img,td[class=image-caption-content] img,td[class=image] img,td[class=image-full] img,td[class=header-img] img{width:100%!important;height:auto!important}td[class=footer],td[class=image],td[class=image-group],td[class=image-text],td[class=divider-simple],td[class=social],td[class=buttons],td[class=content-buttons],td[class=title],td[class=block-text],td[class=two-columns],td[class=image-caption]{padding-left:15px!important;padding-right:15px!important}td[class=image-caption-content] h2,td[class=text] h2,td[class=block-text] h2{font-size:20px!important;line-height:170%!important}td[class=image-caption-content] p,td[class=text] p,td[class=image-text] p,td[class=block-text] li,td[class=block-text] p{font-size:16px!important;line-height:170%!important}table[class=image-in-table] td,table[class=links],table[class=image-caption-container],td[class=text],td[class=image-text]>table{width:100%!important}td[class=image-caption-top-gap]{height:15px!important}td[class=image-caption-bottom-gap]{height:5px!important}table[class=preheader],td[class=gap],td[class=preheader-gap],td[class=preheader-link],tr[class=header-nav]{display:none}td[class=header]{padding:25px!important}td[class=header] h2{font-size:20px!important}td[class=footer] p{font-size:13px!important}table[class=footer-side],table[class=content]{width:100%!important;float:none!important}table[class=footer-social-icons]{float:none!important;margin:0 auto!important}td[class=social-icon-link]{padding:0 5px!important}td[class=image-group] img{width:100%!important;height:auto!important;margin:15px 0!important}td[class=preheader-text]{width:100%}td[class=buttons-full-width] a{width:100%!important;border-radius:0!important}td[class=buttons-full-width] span{width:100%!important}td[class=gallery-image]{width:100%!important;padding:0!important}table[class=social],td[class=head-logo]{width:100%!important;text-align:center!important}table[class=footer-btn]{text-align:center!important;width:100%!important;margin-bottom:10px}table[class=footer-btn-wrap]{margin-bottom:0;width:100%!important}td[class=head-social]{width:100%!important;text-align:center!important;padding-top:20px}}td.video.fullWidth iframe{width: 100%}</style>


    <link rel="stylesheet" href="app.min.css">
   <%--  <link href="/Content/plugins/summernote/summernote.css" rel="stylesheet">
    <link href="/Content/plugins/summernote/summernote-bs3.css" rel="stylesheet">--%>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="fh-breadcrumb ibox-content"  id="main-template-list">
                            <div class="sk-spinner sk-spinner-wave">
                                      
                                        <div class="sk-rect1"></div>
                                        <div class="sk-rect2"></div>
                                        <div class="sk-rect3"></div>
                                        <div class="sk-rect4"></div>
                                        <div class="sk-rect5"></div>
                                    </div>
                <div class="fh-column">
                    <div class="full-height-scroll">
                        <ul class="list-group elements-list" id="template-list-left">
                           <%-- <li class="list-group-item active">
                                <a data-toggle="tab" href="#tab-1">
                                    <small class="pull-right text-muted"> 16.02.2015</small>
                                    <strong>Ann Smith</strong>
                                    <div class="small m-t-xs">
                                        <p>
                                            Survived not only five centuries, but also the leap scrambled it to make.
                                        </p>
                                        <p class="m-b-none">
                                            <i class="fa fa-map-marker"></i> Riviera State 32/106
                                        </p>
                                    </div>
                                </a>
                            </li>
                            <li class="list-group-item ">
                                <a data-toggle="tab" href="#tab-2">
                                    <small class="pull-right text-muted"> 11.10.2015</small>
                                    <strong>Paul Morgan</strong>
                                    <div class="small m-t-xs">
                                        <p class="m-b-xs">
                                            There are many variations of passages of Lorem Ipsum.
                                            <br/>
                                        </p>
                                        <p class="m-b-none">

                                            <span class="label pull-right label-primary">SPECIAL</span>
                                            <i class="fa fa-map-marker"></i> California 10F/32
                                        </p>
                                    </div>
                                </a>
                            </li>--%>
                            


                        </ul>

                    </div>
                </div>

                <div class="full-height">
                    <div class="full-height-scroll white-bg border-left">

                        <div class="element-detail-box">

                             <div class="pull-right">
                                    <div class="tooltip-demo">
                                        <button type="button" id="btn_add_new_template" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add New Template  </button>
                                    </div>
                           </div>
                           

                            <div class="tab-content" id="editor-content-display">


                                <%--<div id="tab-1" class="tab-pane active">
                                    <button type="button" class="btn btn-primary btn-sm"><i class="fa fa-cog"></i> Edit </button>
                                      <button type="button" class="btn btn-primary btn-sm"><i class="fa fa-save"></i> Save </button>
                                        <button type="button" class="btn btn-danger btn-sm"><i class="fa fa-trash-o"></i> Remove  </button>
                             
                                   

                                </div>

                                <div id="tab-2" class="tab-pane ">
                                    <button type="button" class="btn btn-primary btn-sm"><i class="fa fa-cog"></i> Edit </button>
                                      <button type="button" class="btn btn-primary btn-sm"><i class="fa fa-save"></i> Save </button>
                                        <button type="button" class="btn btn-danger btn-sm"><i class="fa fa-trash-o"></i> Remove  </button>
                                  
                                </div>--%>

                                
                            </div>

                        </div>

                    </div>
                </div>



            </div>

</asp:Content>




<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
    <%--<script src="/Scripts/theme/plugins/summernote/summernote.min.js"></script>--%>

     <script src="common.min.js"></script><!-- inject:js -->
    <script src="app.min.js"></script><!-- endinject -->
    <script>


        $(document).ready(function () {


            store.clearAll();


            $('form').bind('submit', function (e) {
                e.preventDefault();
                // etc
            });

            $('#modal_html_builder').on('shown.bs.modal', function () {
                $(document).off('focusin.modal');

               

                var sel = store.get('TemplateSel');
                if (sel != null) {
                    $('#t-title').val((sel.Title == null ? "" : sel.Title));
                }


            });

           // GetTemplatelist();
           

          
        });


        function GetTemplatelist(callback,p) {
            var url = "<%= ResolveUrl("/Application/ajax/template/ajax_webmethod_template.aspx/GetAll") %>";

           

            var data = {  };

            var param = JSON.stringify({ parameters: data });

            AjaxPost(url, param, function () {
                $('#main-template-list').addClass('sk-loading');
            }, function (data) {

                console.log(data);
                store.set('all_template', data);

                BindingHtmlTemplateleft(data);
                BindingHtmlTemplateRight(data);





                setTimeout(function () {
                    $('#main-template-list').removeClass('sk-loading');




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

        function BindingHtmlTemplateleft(data) {
            ret = '';

            for (var t in data) {

                var a = moment(data[t].CreateDateLocal); 
                ret += '<li class="list-group-item " data-keyid="' + data[t].TID +'" >';
                ret += '<a data-toggle="tab" href="#tab-'+t+'">';
                ret += ' <small class="pull-right text-muted"> '+a.format('l')+'</small>';
                ret += '<strong>' + (data[t].Title == "" ? "No Name" : data[t].Title)+ '</strong>';
                ret += '<div style="clear:both;"></div>';
                ret += '<div class="small m-t-xs">';
                ret += '<p></p>';
               // ret += '<p>Survived not only five centuries, but also the leap scrambled it to make.</p>';
                if (data[t].IsNew) {
                    ret += '<p class="m-b-none">  <span class="label pull-right label-primary">New!</span>';
                } 
                
                ret += '<i class="fa fa-map-marker"></i> ' + data[t].Author;
                ret += '</p>';
                ret += '</div>';
                ret += '</a>';
                ret += '</li>';
            }


            $('#template-list-left').html(ret);
          
        }

        function BindingHtmlTemplateRight(data) {
            ret = '';
            
               
           
            for (var t in data) {

                ret += '<div id="tab-'+t+'" class="tab-pane">';
                ret +=  '<button type="button" data-keyid="'+data[t].TID+'" class="btn-edit-template-content btn btn-primary btn-sm"><i class="fa fa-cog"></i> Edit </button> ';
                //ret +=  '<button type="button" class="btn btn-primary btn-sm"><i class="fa fa-save"></i> Save </button> ';
                ret += '<button type="button" data-keyid="' + data[t].TID +'" class="btn-del-template-content btn btn-danger btn-sm"><i class="fa fa-trash-o"></i> Remove  </button> ';
                ret +=  '';
                ret +=  '<div class="html-body-content">';
                ret +=  data[t].EL.html;
                ret +=  '</div>';
                ret +=  '';
                ret +=  '';
                ret +=  '';
                ret +=  '';
                ret +=  '';
                ret +=  '</div>';
            }

            $('#editor-content-display').html(ret);
           
        }

        function UpdateTemplate(callback) {
            var url = "<%= ResolveUrl("/Application/ajax/template/ajax_webmethod_template.aspx/UpdateTemplate") %>";

            var el = store.get('jqueryEmail')

            if (el) {

                var t = store.get('TemplateSel');

                var tid = 0;
                var eid = "";
                var file = "";
                var path = "";
                if (t) {
                    eid = t.EID;
                    tid = t.TID;
                    file = t.DemoFileName;
                    path = t.DemoPath;
                }
                var data = { TID: tid, EID: eid, Title: $("#t-title").val(), EL: el, DemoFileName: file, DemoPath: path };

                var param = JSON.stringify({ parameters: data });

                AjaxPost(url, param, function () {
                    $('#model_html_builder_content').addClass('sk-loading');
                }, function (data) {

                    if (data.EID) {

                        toastr.success('Notification', "Template is updated!!");

                        store.set('TemplateSel', data);



                        setTimeout(function () {
                            GetTemplatelist(callback);

                            $('#model_html_builder_content').removeClass('sk-loading');

                            $('#modal_html_builder').modal('hide');

                        }, 1000);
                    }
                });
            }

        }

        function AddnewTemplate(callback,p) {
            var url = "<%= ResolveUrl("/Application/ajax/template/ajax_webmethod_template.aspx/InsertNewTemplate") %>";

            var el = store.get('jqueryEmail')

            if (el) {

                var t = store.get('TemplateSel');
               
                var tid = 0;
                if (t) {
                   
                    tid = t.TID;
                }
                var data = { TID:tid, Title: $("#t-title").val(), EL:el};

                var param = JSON.stringify({ parameters: data });

                AjaxPost(url, param, function () {
                    $('#model_html_builder_content').addClass('sk-loading');
                }, function (data) {

                    if (data.EID) {

                        toastr.success('Notification', "Add New Template Successful!!!");

                        store.set('TemplateSel', data);

                       

                        setTimeout(function () {
                            GetTemplatelist(callback,p);

                            $('#model_html_builder_content').removeClass('sk-loading');

                            $('#modal_html_builder').modal('hide');

                        }, 1000);
                    }
                });
            }
           
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
                    ret += '<div class="media-doc" ><i class="fa fa-file"></i></div>';
                }


                ret += '</a><button class="icon-check btn btn-info btn-circle" type="button"  onclick="return false;" style="display:none;"><i class="fa fa-check"></i></button > </div >';
            }
            // style="display:none;" <i style="display:none;" class="icon-check fa fa-certificate"></i> 
            return ret;
        }
    </script>
</asp:Content>
 