$(document).ready(function () {

   // tinymce.baseURL = "bower_components/tinymce/"
    tinymce.init({
        document_base_url: "bower_components/tinymce/",
        selector: '#mailboxtextarea',
         skin: "lightgray",
         theme: "modern",
         height: "480",
        plugins: [
            "advlist autolink lists link image charmap",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste",
            "textcolor"
        ],
        toolbar: "undo redo | styleselect | bold italic fontsizeselect forecolor backcolor | alignleft aligncenter alignright alignjustify | bullist numlist | link mybutton",
        fontsize_formats: "8pt 9pt 10pt 11pt 12pt 13pt 14pt 15pt 16pt 18pt 24pt 36pt",
        setup: function (i) {
            i.on("init", function () {
                //n = $(t).next("textarea"),
                //    i.setContent(e.value);
            }),
                i.addButton('mybutton', {
                    text: "Add media",
                    onclick: function () {

                        $('#modal_media').show(function () {
                            $('button[id^="btn-custom-add-medias"]').hide();

                            $('#mail-text-block').hide(function () {
                                $('#btn-custom-add-medias-m').show();
                            });

                            $('#btn-custom-add-medias-m').bind('click', function () {
                                var data = store.get("key_onSel");
                                var url = location.origin + data.Path + "/" + data.FileName;
                                i.insertContent('<img style="width:50%" src="' + url + '" />');
                                

                                $('#modal_media').hide(function () {
                                    $('#mail-text-block').show();

                                });


                            });

                            
                            getmediall();
                            BindingCat();
                            $('#sel_type,#sel_cat').on('change', function () {

                                console.log('sss');
                                getmediall();
                            });
                        });


                    }
                })
                , i.on("change", function (ed, o) {
                    

                }),
                i.on('blur', function () {
                
                })
        }
    })

});




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
            switch (data[t].CSID) {
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

            var ss = '<span id="status_title_' + data[t].CID +'" class="status_title_ label ' + l + ' pull-right">' + data[t].CSIDTitle + '</span>';

            ret += ' <tr class="' + r + '">';
            ret += '    <td class="check-mail">';
            ret += '         <input type="checkbox" name="c_check[]" class="i-checks" value="' + data[t].CID + '">';
            ret += '     </td>';
            ret += '        <td class="mail-subject" ><a href="javascript:void(0);" class="item-edit" data-ssid="' + data[t].CSID + '" data-cid="' + data[t].CID + '">' + data[t].Subject + '</a>' + ss + '</td>';
            ret += '        <td class="mail-ontact"><small>Completion with: <span class="percent_process" id="percent_process' + data[t].CID + '">' + parseInt(percent)+'</span>%</small>';
            ret += '        <div class="progress progress-mini">';
            ret += '        <div  id="percent_process_bar' + data[t].CID + '" style="width:' + parseInt(percent)+'%"  class="progress-bar"></div>';
            ret += '        </div></td>';

            ret += '        <td class=""> ' + (data[t].FileMail != "" ? '<i class="fa fa-paperclip"></i>' : '') + '  </td>';
            ret += '         <td class="text-right mail-date">' + a.format("llll") + '</td>';
            ret += ' </tr>';

        }

        var status = "";
        total = data[0].TotalRows;
        scid = data[0].CSID;
        scidtitle = data[0].CSIDTitle;
    } else {
        ret = '<tr><td colspan="5">No record</td></tr>';
        total = 0;
    }

    if (total < store.get('rawdata_mailbox').Size) {
        $('#c_next').attr("disabled", "disabled");
    } else {
        $('#c_next').removeAttr("disabled");
    }


    if (store.get('rawdata_mailbox').Start == 0) {
        $('#c_pre').attr("disabled", "disabled");
    } else {
        $('#c_pre').removeAttr("disabled");
    }

    $('#c-total').html("(" + total + ")");

    $('#data-campaign-list').html(ret);

}


function CloseImageAddPanel () {
   
    $('#modal_media').hide(function () {
        $('#mail-text-block').show();

    });

}



function AddFileCustom () {

    

    $('#modal_media').show(function () {

        $('#mail-text-block').hide(function () {
            $('#btn-custom-add-medias-m').hide();
            $('#btn-custom-add-medias-f').show();
        });
        
        getmediall();

        BindingCat();
        $('#sel_type,#sel_cat').on('change', function () {

            console.log('sss');
            getmediall();
        });
    });

    $('.email-builder-header-actions').hide();
}

function SelectFile() {
    console.log('click');
    var data = store.get("key_onSel");


    var fileat = (store.get('fileat') == null ? [] : store.get('fileat'))
    fileat.push({
        Path: data.Path,
        FileName: data.FileName
    });

    var f = "[" + data.FileName + "] ";
    $('#file_list_m').append(f);

    
    store.set('fileat', fileat);
    
    $('#modal_media').hide(function () {
        $('#mail-text-block').show(function () {

        });
    });
}

function PublishCampaign() {
    console.log($('#mail_address').val());
    console.log($(".select2_demo_2").select2('val'));
    if ($('#mail_address').val() == '' && $(".select2_demo_2").select2('val') == null) {
       
        swal({
            title: "Something Wrong",
            text: "กรุณาเลือก ใส่รายละเอียดให้ครบถ้วน"
        });

        return false;
    } 


    if ($('#campaign_subject').val() == '') {
        swal({
            title: "Something Wrong",
            text: "กรุณาเลือก ใส่รายละเอียดให้ครบถ้วน"
        });

        return false;
    }

     AddnewCampaign();
    
    
}

function AddnewCampaign() {
    var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/InsertNewMailbox";
    var content = tinyMCE.activeEditor.getContent({ format: 'raw' });
    var rawEl = {
        html: content
    };


    store.set('jqueryEmail', rawEl);

    var el = store.get('jqueryEmail');
   

    if (el) {

        var t = store.get('CampaignSel');
        var sj = $('#campaign_subject').val();
        var s = $(".select2_demo_2").select2('val');
        var tt = $('#t-title').val();
        var r = $('input[name="SubscriptAction"]:checked').val();

        var ma = $('#mail_address').val();
       // var tm = $('input[name="Sub_sendNow"]').val();
       // var d = $('#data_1').val();
        //var c = $('.clockpicker input').val();
        
       // var a = moment(d + " " + c, 'MM/DD/YYYY HH:mm', true);

       

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
            Mailaddress :ma,
            //IsSchedule: tm,
            CSID: 1,
            //DateTimePublish: a.format(),
            FileMail: JSON.stringify(store.get('fileat'))
        };

        var param = JSON.stringify({ parameters: data });

        AjaxPost(url, param, function () {
            $('#model_mail_builder_content').addClass('sk-loading');
        }, function (data) {

            if (data.EID) {

                toastr.success('Notification', "Add New Mail Successful!!!");

                store.set('TemplateSel', data);

               

                setTimeout(function () {
                    GetTemplatelist();
                   
                    $('#model_mail_builder_content').removeClass('sk-loading');

                    $('#modal_mail_builder').modal('hide');

                }, 1000);
            }



        });
    }

}
function UpdateTemplate(callback) {
    var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/UpdateCampaign";

    var content = tinyMCE.activeEditor.getContent({ format: 'raw' });
    var rawEl = {
        html: content
    };

    store.set('jqueryEmail', rawEl);
    var el = store.get('jqueryEmail');



    if (el) {

        var t = store.get('ItemSel');
        var sj = $('#campaign_subject').val();
        var s = $(".select2_demo_2").select2('val');
        var tt = $('#t-title').val();
        var r = $('input[name="SubscriptAction"]:checked').val();
        var ma = $('#mail_address').val();
        //var tm = $('input[name="Sub_sendNow"]').val();
        //var d = $('#data_1').val();
        //var c = $('.clockpicker input').val();



       // var a = moment(d + " " + c, 'MM/DD/YYYY HH:mm', true);


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
            Mailaddress: ma,
            SGarr: s,
            Subject: sj,
            Unsub: r,
            //IsSchedule: tm,
            CSID: 1,
            //DateTimePublish: a.format(),
            FileMail: JSON.stringify(store.get('fileat'))
        };

        var param = JSON.stringify({ parameters: data });

        AjaxPost(url, param, function () {
            $('#model_html_builder_content').addClass('sk-loading');
        }, function (data) {

            if (data.EID) {

                toastr.success('Notification', "Mail is updated!!");

                store.set('ItemSel', data);



                setTimeout(function () {
                    GetTemplatelist(callback);

                    $('#model_html_builder_content').removeClass('sk-loading');

                    $('#modal_mail_builder').modal('hide');

                    store.remove('ItemSel');
                }, 1000);
            }
        });
    }

}

function GetSubscriberGroup() {
    var url = "/Application/ajax/subscriber/ajax_webmethod_subscriber.aspx/GetAll";
    
    var data = {};

    var param = JSON.stringify({ parameters: data });

    AjaxPost(url, param, null, function (data) {


        console.log(data);
        ret = '';

        for (var i in data) {
            ret += '<option value="' + data[i].SGID + '">' + data[i].SGName + '</option>';

        }
        
        $('#selec_sup').html(ret);

    });
}



function BindEvent() {

    $('#c_next').on('click', function () {
        var raw = store.get('rawdata_mailbox');
        var p = raw.Start;

        raw['Start'] = p + raw.Size;

        store.set("rawdata_mailbox", raw);

        GetTemplatelist();
    });

    $('#c_pre').on('click', function () {
        var raw = store.get('rawdata_mailbox');
        var p = raw.Start;

        var pp = p - raw.Size;
        raw['Start'] = (pp < 0 ? 0 : pp);

        store.set("rawdata_mailbox", raw);

        GetTemplatelist();
    });


    $('.c_status').on('click', function () {
        var s = $(this).data('sid');
        var raw = store.get('rawdata_mailbox');

        $('#c-status').html($(this).html());
        raw['CSID'] = s;
        store.set("rawdata_mailbox", raw);
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




                var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/Cancel";
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




                var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/Trash";
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

function BindEditmode() {
    var dd = $(document).find('.item-edit')
        .on('click', function () {
            $('#btn-b-update-template').show();
            $('.btn-b-add-template').hide();

            var csid = $(this).data('ssid');
            var id = $(this).data('cid');

            if (csid == "1" || csid == "2" || csid == "4" || csid == "5" || csid == "6") {


                var url = "/Application/ajax/mailbox/ajax_webmethod_mailbox.aspx/GetItemById";
                var data = { CID: id };

                var param = JSON.stringify({ parameters: data });

                AjaxPost(url, param, function () {
                    $('#main-campaign-list').addClass('sk-loading');
                }, function (data) {

                    if (data.CID) {


                        store.set('ItemSel', data);

                        store.set('jqueryEmail', data.EL);

                        

                        setTimeout(function () {

                            $('#main-campaign-list').removeClass('sk-loading');

                            
                            $('#modal_mail_builder').modal({
                                backdrop: 'static',
                                keyboard: false
                            });

                        }, 1000);
                    }
                });




            } else {

                swal({
                    title: "Cannot Edit ",
                    text: "ไม่สามารถทำรายการได้ กรุณาตราวจสอบ สถานะของ รายการอีกครั้ง"
                });
            }
            console.log(csid);



            return false;
        });
}





















function getmediall() {

    var url = "/Application/ajax/media/ajax_webmethod_media.aspx/GetMedia";

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

function BindingCat() {
    var url = "/Application/ajax/media/ajax_webmethod_media.aspx/GetMediaCat";

    var data = {};
    var param = JSON.stringify({ parameters: data });
    AjaxPost(url, param, null, function (data) {
        store.set("Cat_data", data);


        HtmlBinding();

    });
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

function HtmlBinding() {

    var data = store.get("Cat_data");
    var ret = "";
    for (var i in data) {
        ret += '<option value="' + data[i].TaxID + '">' + data[i].Title + '</option>';
    }


    $('#sel_cat').append(ret);
   
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