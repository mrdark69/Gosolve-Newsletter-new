<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Media.aspx.cs" Inherits="Media" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="ibox">
                <div class="ibox-title"><h5>Media Upload</h5></div>
                 <div class="ibox-content">
                     <div  class="dropzone" id="mydropzone" >
                        <div class="fallback">
                            <input name="file" type="file" multiple />
                        </div>
                    </div> 
                  </div>
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
                                
                                
<%--                                <button class="btn btn-primary" type="submit">Search</button>--%>
                                <a href="javascript:void(0)" id="add_new_cat">Add New Category</a>
                                </div>
                                 <div class="col-md-4" style="text-align:right">
                                     <div class="btn-group">
                                        <button data-toggle="dropdown" class="btn btn-primary btn-sm dropdown-toggle">Action <span class="caret"></span></button>
                                        <ul class="dropdown-menu">
                                            <li><a href="javascript:void(0);" onclick="BulkUpdate(2)">Add To Category</a></li>
                                            <li><a href="javascript:void(0);" onclick="BulkUpdate(1)">Delete</a></li>
                                         
                                        </ul>
                                    </div>
                                     <%-- <div class="form-group">
                                       <select class="form-control" id="sel_bulk_update">
                                           <option value="1">Delete</option>
                                           <option value="2">Add To Category</option>
                                       </select>
                                    </div>
                                     <button class="btn btn-primary" type="button"  onclick="BulkUpdate();">Bulk Action</button>--%>
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

                   <div class="ibox" id="media-detail-block" >
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

                                    <div class="form-group"><label class="col-sm-3 control-label">Filename:</label>

                                    <div class="col-sm-9">
                                        <div><label class="media_file_name"> adasdas  </label></div>
                                    </div>
                                    </div>
                                    <div class="form-group"><label class="col-sm-3 control-label">File type:</label>

                                    <div class="col-sm-9">
                                        <div><label class="media_file_type"> adasdas  </label></div>
                                    </div>
                                    </div>

                                   <div class="form-group"><label class="col-sm-3 control-label">Uploaded on:</label>

                                    <div class="col-sm-9">
                                        <div><label class="media_file_on"> adasdas  </label></div>
                                    </div>
                                    </div>

                                   <div class="form-group"><label class="col-sm-3 control-label">Dimensions:</label>

                                    <div class="col-sm-9">
                                        <div><label class="media_file_dimensions"> adasdas  </label></div>
                                    </div>
                                    </div>
                                   <div class="form-group"><label class="col-sm-3 control-label">File Size:</label>

                                    <div class="col-sm-9">
                                        <div><label class="media_file_size"> adasdas  </label></div>
                                    </div>
                                    </div>


                               
                                <div class="hr-line-dashed"></div>
                                 <div class="form-group"><label class="col-sm-2 control-label">Title</label>
                                    <div class="col-sm-10"><input type="text" class="form-control media_file_title"></div>
                                </div>

                               <div class="hr-line-dashed"></div>

                                  
                                   <div class="form-group">
                                       <div class="col-md-12">
                                              <h5 class="tag-title">Category</h5>
                                            <ul class="tag-list" id="tax_media_list" style="padding: 0">
                                                <%--<li><a href="">Family</a></li>
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

                                
                                    <div class="form-group">
                               
                                    <div class="col-sm-9">

                                        <select id="select-form-detail-cat" class="form-control input-sm" >
                                            <option value="0">no category</option>
                                        </select>
                                    </div>
                                        <div class="col-sm-3">
                                             <button type="button" id="btn-add-tax-sel" class="btn btn-primary btn-xs">Add</button>
                                        </div>
                                 
                                     </div>

                                <div class="hr-line-dashed"></div>
                                <div class="form-group">
                                    <div class="col-sm-12 col-sm-offset-2">
                                        <button class="btn btn-w-m btn-danger" onclick="DeleteMedia()" type="button">Delete</button>
                                        <button class="btn btn-primary" onclick="save()" type="button">Save changes</button>
                                    </div>
                                </div>
                               
                               
                            </div>

                            </div>
                         </div>
                   
                    </div>
            </div>
        </div>
    

    <%--//modal--%> 
       <div class="modal inmodal" id="_add_cat_modal" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content animated bounceInRight">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <i class="fa fa-laptop modal-icon"></i>
                                            <h4 class="modal-title">Add New Category</h4>
                                            
                                        </div>
                                        <div class="modal-body">
                                            <p><strong>กรุณาใส่ Category ที่ท่านต้องการ</strong> </p>
                               <div class="form-group"><label>ชื่อ</label> <input type="text" name="Cat_title"  id="Cat_title" class="form-control  required"></div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary" id="btn_add_category" >Save changes</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
    <div class="modal inmodal" id="_update_media_cat_modal" tabindex="-1" role="dialog" aria-hidden="true">
                                <div class="modal-dialog">
                                <div class="modal-content animated bounceInRight">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                            <i class="fa fa-laptop modal-icon"></i>
                                            <h4 class="modal-title">Add New Category</h4>
                                            
                                        </div>
                                        <div class="modal-body">
                                            <p><strong>กรุณาใส่ Category ที่ท่านต้องการ</strong> </p>
                               <div class="form-group"><label>ชื่อ</label> 
                                   <select id="sel-update-media-bulk" class="form-control" >
                                        <option value="0">no category</option>
                                      </select></div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                                            <button type="button" class="btn btn-primary" id="btn_update_media_category" >Save changes</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
</asp:Content>
<asp:Content ID="FooterScript" ContentPlaceHolderID="ContentFooter" runat="server">
     
        <script type="text/javascript">

            //Dropzone.options.dropzoneForm = {
               
            //};
            Dropzone.autoDiscover = false;
            $(document).ready(function () {
                store.clearAll();

                BindingCat();
                //init media all
                getmediall();

                var myDropzone = new Dropzone("div#mydropzone", {
                    url: "<%= ResolveUrl("/Application/ajax/media/ajax_upload_media.aspx") %>",
                    paramName: "file", // The name that will be used to transfer the file
                    maxFilesize: 20, // MB
                    dictDefaultMessage: "<strong>Drop files here or click to upload. </strong></br> สามารถลากรูปภาพที่ต้องการมาวาง หรือ click เพื่อเลือกภาพได้เลยครับ"

                });

                myDropzone.on("complete", function (file) {
                    myDropzone.removeFile(file);

                    getmediall();
                   
                  
                });

                $('#sel_type,#sel_cat').on('change', function () {
                    getmediall();
                });

                $('#add_new_cat').on('click', function (e) {
                    $('#_add_cat_modal').modal('show');
                });

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

                $('#btn-add-tax-sel').on('click', function () {
                    var sel = $('#select-form-detail-cat').val();
                    var sd = store.get('key_onSel');
                    var title = $("#select-form-detail-cat option:selected").text();
                    var MID = sd.MID;
                    var t = sd.MediaTax;
                    //var newv = [];
                    if (sel > 0) {

                        var c = t.filter(function (el) {
                            return el.TaxID == sel && el.MID == MID;
                        });
                        if (!c.length) {
                            t.push({ TaxID: parseInt(sel), MID: MID, Title: title });
                        }

                        sd.MediaTax = t;
                        store.set('key_onSel', sd);

                        BindingTax(t);

                    }
                });

                $('#btn_add_category').on('click', function (e) {

                    
                    e.preventDefault;


                    if (mainform.valid()) {
                        var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/InsertCat") %>";
                        var data = { CatVal: $("#Cat_title").val() };

                        var param = JSON.stringify({ parameters: data });

                        AjaxPost(url, param, null, function (data) {

                            if (data.success) {

                                toastr.success('Notification', data.msg);


                                BindingCat();
                                getmediall();


                                $('#_add_cat_modal').modal('hide');
                            }
                        });


                    }
                    return false;
                });


               


                $('#btn_update_media_category').on('click', function (e) {
                    e.preventDefault;

                    var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/BulkUpdateCat") %>";
                    var data = [];
                    var _CatVals = $("#sel-update-media-bulk").val();
                    var _d = store.get('data_sel_list');
                    for (var i in _d) {
                        data.push({ TaxID: _CatVals, MID:_d[i].MID})
                    }

                    var param = JSON.stringify({ parameters: data });

                    AjaxPost(url, param, null, function (data) {

                        if (data.success) {

                            toastr.success('Notification', data.msg);


                            getmediall();
                            $('#_update_media_cat_modal').modal('hide');

                            
                        }
                    });


                    return false;
                });




                $('.media_file_title').on('change', function (e) {
                    e.preventDefault;
                    var data = store.get("key_onSel");

                    data.Title = $(this).val();
                    store.set("key_onSel",data);
                    return false;
                });



            });






            function BindingCat() {
                var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/GetMediaCat") %>";

                var data = { };
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
                $('#select-form-detail-cat').append(ret);
                $('#sel-update-media-bulk').append(ret);
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


            function generateMediaData(data) {
                var ret = "";
                for (d in data) {
                    var url = data[d].Path + "/" + data[d].FileName;
                    store.set("key_"+data[d].MID, data[d]);
                    //encodeURIComponent(JSON.stringify(data[d]))
                    ret += '<div class="media-block" id="block_' + data[d].MID+'">';
                    ret += '<input type="checkbox" value="' + data[d].MID + '" name="media_checkbox" style = "display:none; id="media_checkbox" />';
                    ret += '<a href= "javascript:void(0)" class="img_data" title="' + data[d].Title + '" >';
                    //style = "display:none;
                    var string = data[d].FileType,
                        expr = /image/;  // no quotes here

                    if (expr.test(string)) {
                        ret += '<img class="img-responsive" src="' + url + '">';
                    } else {
                        ret += '<div class="media-doc" ><i class="fa fa-file"></i>  <span style="font-size:11px;color:#cccccc;">' +  data[d].FileName+'</span></div>';
                    }

                   
                    ret += '</a><button class="icon-check btn btn-info btn-circle" type="button"  onclick="return false;" style="display:none;"><i class="fa fa-check"></i></button > </div >';
                }
                // style="display:none;" <i style="display:none;" class="icon-check fa fa-certificate"></i> 
                return ret;
            }


            function Click_BindingToRightDetail() {



                var chek = $(this).find(':checkbox');
                var a = $(this).find('a.img_data');
                
                $(this).removeClass('media-block-selected');
          
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
                if (data) {
                    $('#block_' + data.MID + ' .icon-check').show();
                }
              


                if (chek.prop("checked")) {
                    $("#media_detail_block").show();
                } else {
                    $(this).find('.icon-check').hide();
                    $("#media_detail_block").hide();
                    store.remove("key_onSel");
                }


                //$(this).find('.icon-check').show();

                if ($('.media-block').find(':checked').length == 0) {
                    $('.media-block .icon-check').hide();
                    store.remove("key_onSel");
                }




                if (data) {

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
                    ft.val(data.Title);
                    fs.html(data.FileSizeFormat);




                    var MediaTax = data.MediaTax;


                    BindingTax(MediaTax);
                }
               
                

              
               


                var allcheck = $('#lightBoxGallery').find('input[name="media_checkbox"]:checked');
                
                if (allcheck.length == 0) {
                    $("#media_detail_block").hide();
                }

                return false;
            }


            function BindingTax(MediaTax, append = false) {
                var taxlist = '';
                for (var i in MediaTax) {
                    taxlist += '<li><a href="javascript:void(0);">' + MediaTax[i].Title + '</a><i onclick="CategoryTaxRemove(this);" data-taxid="' + MediaTax[i].TaxID +'"  class="tax-item-list fa fa-times"></i></li>';
                }
                if (append) {
                    $('#tax_media_list').append(taxlist);
                } else {
                    $('#tax_media_list').html(taxlist);
                }
               

            }

            function BulkUpdate(option) {
                //var option = $('#sel_bulk_update').val();



                
                var data = [];

                $.each($('.media-block').find(':checked'), function () {

                    data.push(store.get("key_" + $(this).val()));
                    
                });  


                if (data.length > 0) {
                    switch (option) {
                        case 1:
                            BulkDelete(data);
                            break;
                        case 2:
                            BulkUpdateCat(data);
                            break;
                    }
                } else {
                    swal({
                        title: "Alerts",
                        text: "ท่านยังไม่ได้ กดเลือก Media ที่จะทำรายการ"
                    });
                }

               

               
            }


            function BulkUpdateCat(data) {

                store.set("data_sel_list", data);

                $('#_update_media_cat_modal').modal('show');

                return false;
            }


            function CategoryTaxRemove(item) {
               

                var tax = $(item).data('taxid');
                    var newv = [];
                    var sd = store.get('key_onSel');
                    if (sd != null) {
                        var t = sd.MediaTax;
                        if (t.length > 0) {


                            newv = t.filter(function (el) {
                                return el.TaxID !== tax;
                            });

                            sd.MediaTax = newv;
                            store.set('key_onSel', sd);

                            BindingTax(newv);
                        }
                    }

                    return false;

                
            }

            function BulkDelete(data) {
                            swal({
                                title: "Are you sure?",
                                text: "You will not be able to recover this record!",
                                type: "warning",
                                showCancelButton: true,
                                confirmButtonColor: "#DD6B55",
                                confirmButtonText: "Yes, delete it!",
                                closeOnConfirm: false
                            }, function () {

                                
                                var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/BulkDelete") %>";
                                var param = JSON.stringify({ parameters: data });
                                AjaxPost(url, param, null, function (data) {
                                    if (data.success) {

                                        toastr.success('Notification', data.msg);

                                        getmediall();

                                        $(".my-input").val("");

                                    }

                                });

                                swal.close();

                                });


                            return false;
            }


            function DeleteMedia() {

                
               
                swal({
                    title: "Are you sure?",
                    text: "You will not be able to recover this record!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    closeOnConfirm: false
                }, function () {


                    var data = store.get("key_onSel");


                    var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/Delete") %>";
                    var param = JSON.stringify({ parameters: data });
                                AjaxPost(url, param, null, function (data) {
                                    if (data.success) {

                                        toastr.success('Notification', data.msg);
                                       
                                        getmediall();
                                       
                                    }

                                });

                                swal.close();

                     });
               
            }


            function save() {
                var data = store.get("key_onSel");



                var url = "<%= ResolveUrl("/Application/ajax/media/ajax_webmethod_media.aspx/UpdateMedia") %>";
                var param = JSON.stringify({ parameters: data });
                AjaxPost(url, param, function () {
                    $('#media-detail').addClass('sk-loading');
                }, function (data) {
                    if (data.success) {

                        toastr.success('Notification', data.msg);

                        $('#media-detail').addClass('sk-loading');

                        //getmediall();
                        setTimeout(function () {
                            $('#media-detail').removeClass('sk-loading');
                        }, 1000);
                        return false;
                    }

                });

                

           
                
                return false;
            }

        </script>
</asp:Content>