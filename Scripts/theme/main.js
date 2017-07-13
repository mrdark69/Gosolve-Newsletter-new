function AjaxPost(url, data, fnbeforeSend, fnsuccess, fncompleted){
    //var post = $("#extra_bed_insertform").find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize();
    //var _c = 'application/json; charset=utf-8';
    //if (!contentType) {
    //    _c = false;

    //}
    $.ajax({
        type: 'POST',
        url: url,
        data: data,
        contentType: 'application/json; charset=utf-8',
        processData: true,
        //dataType: 'json',

        beforeSend: fnbeforeSend,
        success: fnsuccess,
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);

            return false;
        },
        complete: fncompleted

    });
}

//window.paceOptions = {
//    ajax: {
//        trackMethods: ['GET', 'POST', 'PUT', 'DELETE', 'REMOVE']
//    }
//};

toastr.options = {
    "closeButton": true,
    "debug": false,
    "progressBar": true,
    "preventDuplicates": false,
    "positionClass": "toast-top-right",
    "onclick": null,
    "showDuration": "400",
    "hideDuration": "1000",
    "timeOut": "7000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

function qToJson(search) {
    //var search = location.search.substring(1);
    return search ? JSON.parse('{"' + search.replace(/&/g, '","').replace(/=/g, '":"') + '"}',
        function (key, value) { return key === "" ? value : decodeURIComponent(value) }) : {}


   // JSON.parse('{"' + decodeURI("abc=foo&def=%5Basf%5D&xyz=5".replace(/&/g, "\",\"").replace(/=/g, "\":\"")) + '"}')
}


function updateDataTableSelectAllCtrl(table) {
    var $table = table.table().node();
    var $chkbox_all = $('tbody input[type="checkbox"]', $table);
    var $chkbox_checked = $('tbody input[type="checkbox"]:checked', $table);
    var chkbox_select_all = $('thead input[name="select_all"]', $table).get(0);

    // If none of the checkboxes are checked
    if ($chkbox_checked.length === 0) {
        chkbox_select_all.checked = false;
        if ('indeterminate' in chkbox_select_all) {
            chkbox_select_all.indeterminate = false;
           
        }

        // If all of the checkboxes are checked
    } else if ($chkbox_checked.length === $chkbox_all.length) {
        chkbox_select_all.checked = true;
        if ('indeterminate' in chkbox_select_all) {
            chkbox_select_all.indeterminate = false;
            
        }

        // If some of the checkboxes are checked
    } else {
        chkbox_select_all.checked = true;
        if ('indeterminate' in chkbox_select_all) {
            chkbox_select_all.indeterminate = true;
           
        }
    }
}



//function UpdateButtonmode(table,ischeck) {
//    var buttons = table.buttons(['.main-btn-delete','.main-btn-edit']);
//    if (ischeck) {
//        buttons.enable();
//    } else {
//        buttons.disable();
//    }
   
//}