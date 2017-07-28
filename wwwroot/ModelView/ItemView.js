
var ExportView = (function () {
    var save_method; //for save method string
    var table;

    var reload_table = function () {
        table.ajax.reload(null, false); //reload datatable ajax  
    }
    var triggerControls = function () {
        $('#btnCreate').click(function () { ExportView.voidAdd(); }); // onClick to load addNew items
        $('#btnRefreshTable').click(function () { ExportView.refreshTable(); }); // onClick to load refresh datatable
        $('#btnSave').click(function () { ExportView.voidSave(); }); // onClick to load for save database
    }
        toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "2000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
        }
    
    return {

        displayClientSide: function () {
            table = $("#dataTable").DataTable({
                processing: false,
                serverSide: false,
                fixedHeader: true,
                dom: '<"html5buttons"B>lTfgitp',
                ajax: {
                    "url": "/Item/getAll/",
                    "type": "GET",
                    "dataSrc": ""

                },
                columns: [
                    { "data": "itemID" },
                    { "data": "title" },                                        
                    { "data": "detail" },
                    { "data": "src" },
                    { "data": "postedBy" },
                     { "data": "rating" },
                    { "data": "view" },
                    { "data": "modifiedDate" },
                    {
                        "data": null,
                        "mRender": function (data, type, full) {
                            return "<button type='button' class='btn btn-rounded btn-outline btn-info' href='javascript:void(0)' title='Edit' onclick='ExportView.voidEdit(" + '"' + data.itemID + '"' + ")'><i class='fa fa-pencil'></i></button>"
                                + "<button type='button' class='btn btn-rounded btn-outline btn-danger' href='javascript:void(0)' title='Delete' onclick='ExportView.voidRemoveById(" + '"' + data.itemID + '"' + ")'><i class='fa fa-trash'></i></button>";
                        }
                    }
                ],
                buttons: [{
                    extend: "copy"                  
                }, {
                    extend: "excel"
                  
                }, {
                    extend: "pdf"                                   
                }, {
                    extend: "print",                   
                    customize: function (win) {
                            $(win.document.body).addClass('white-bg');
                            $(win.document.body).css('font-size', '10px');

                            $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', 'inherit');
                        }
                }],
                //Set column definition initialisation properties.
                "columnDefs": [
                    {
                        "width": "5%",
                        "targets": [0], //last column
                        "orderable": 2, //set not orderable
                    }, {
                        "className": "text-center custom-middle-align",
                        "targets": [0, 1, 2, 3]
                    }
                ],
                responsive: 0,
                keys: true,

            })
            var handleDataTableButtons = function () {
                "use strict";
                0 !== $("#tableData").length && table
            },
                TableManageButtons = function () {
                    "use strict";
                    return {
                        init: function () {
                            handleDataTableButtons()
                        }
                    }
                }();
            TableManageButtons.init();

        },
        displayServerSide: function () {
            table = $("#tableData").DataTable({
                processing: true,
                serverSide: true,
                fixedHeader: true,
                dom: "Bflrtip",
                ajax: {
                    "url": "/Item/getDataServerSide/",
                    "type": "POST",
                    "dataType": "JSON",
                    "contentType": 'application/json; charset=utf-8',
                    'data': function (data) { return data = JSON.stringify(data); }
                },
                columns: [
                    { "data": "itemID" },
                    { "data": "title" },                                        
                    { "data": "detail" },
                    { "data": "src" },
                    { "data": "postedBy" },
                    { "data": "rating" },
                    { "data": "view" },
                    { "data": "modifiedDate" },
                    {
                        "data": null,
                        "mRender": function (data, type, full) {
                            return "<button type='button' class='btn btn-rounded btn-outline btn-info' href='javascript:void(0)' title='Edit' onclick='ExportView.voidEdit(" + '"' + data.itemID + '"' + ")'><i class='fa fa-pencil'></i></button>"
                                + "<button type='button' class='btn btn-rounded btn-outline btn-danger' href='javascript:void(0)' title='Delete' onclick='ExportView.voidRemoveById(" + '"' + data.itemID + '"' + ")'><i class='fa fa-trash'></i></button>";
                        }
                    }
                ],
                buttons: [{
                    extend: "copy",
                    className: "btn-sm"
                }, {
                    extend: "excel",
                    className: "btn-sm",
                    text: "Xuất Excel"
                }, {
                    extend: "pdf",
                    className: "btn-sm",
                    text: "Xuất PDF"
                }, {
                    extend: "print",
                    className: "btn-sm",
                    text: "In ấn",
                    message: 'Province!'
                }],
                //Set column definition initialisation properties.
                "columnDefs": [
                    { "width": "5%", "targets": [0] },
                    { "className": "text-center custom-middle-align", "targets": [0, 1, 2, 3] },
                ],
                "language":
                {
                    "processing": "<div class='overlay custom-loader-background'> Đang xử lý...<i class='fa fa-cog fa-spin custom-loader-color'></i></div>"
                },
                responsive: 0,
                keys: true,

            })
            var handleDataTableButtons = function () {
                "use strict";
                0 !== $("#tableData").length && table
            },
                TableManageButtons = function () {
                    "use strict";
                    return {
                        init: function () {
                            handleDataTableButtons()
                        }
                    }
                }();
            TableManageButtons.init();

        },
        voidAdd: function () {
            save_method = 'add';
            $('#form')[0].reset(); // reset form on modals
            $('.form-group').removeClass('has-error'); // clear error class
            $('.help-block').empty(); // clear error string
            // $('#modal_form').modal('show'); // show bootstrap modal
            // $('.modal-title').text('Thêm Mới'); // Set Title to Bootstrap modal title  
        },
        voidSave: function () {
            var obj = $('#form').serialize();
            $('#btnSave').text('Saving...'); //change button text
           // $('#btnSave').attr('disabled', true); //set button disable 
            var url;
            if (save_method === 'add') {
                url = "/Item/addEntity/";
            } else {
                url = "/Item/updateEntity/";
            }
            // ajax adding data to database
            $.ajax({
                url: url,
                type: "POST",
                data: obj,
                dataType: "JSON",
                success: function (data) {
                    if (data.statusCode === 200) //if success close modal and reload ajax table
                    {
                              toastr.success(data.status,"Thông báo!");                      
                           
                    }
                    else
                        if (data.statusCode === 400) {                            
                           toastr.warning(data.status,"Error");
                        }
                    $('#btnSave').text('Save Changes'); //change button text
                    $('#btnSave').attr('disabled', false); //set button enable 
                  //  $('#modal_form').modal('hide'); // show bootstrap modal     
                    reload_table();
                },
                complete: function(){
                    $('#form')[0].reset();
                    if(save_method === "update"){
                        $("#myModal").modal('hide');
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    toastr.error('Error adding / update data ' + textStatus);
                    $('#btnSave').text('Save Changes'); //change button text
                    $('#btnSave').attr('disabled', false); //set button enable 

                }
            });
        },      
        voidEdit: function (id) {
            save_method = 'update';
            $('#form')[0].reset(); // reset form on modals
            $('.form-group').removeClass('has-error'); // clear error class
            $('.help-block').empty(); // clear error string

            //Ajax Load data from ajax
            $.ajax({
                url: "/Item/getById/" + id,
                type: "GET",
                dataType: "JSON",
                success: function (data) {
                    $('[name="ItemID"]').val(data.itemID);
                    $('[name="ItemName"]').val(data.itemName);
                    
                    $('#myModal').modal('show'); // show bootstrap modal when complete loaded
                    $('.modal-title').text('Update information'); // Set title to Bootstrap modal title
                    
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    toastr.error('Lỗi khi nhận dữ liệu từ ajax ' + textStatus);
                   
                }
            });
        },
        voidRemoveById: function (id) {
            var a = confirm('Bạn có chắc muốn xóa '+ id +" không ?");
            if(a){
                // ajax delete data to database
                $.ajax({
                        url: "/Item/removeEntity/" + id,
                        type: "POST",
                        dataType: "JSON",
                        success: function (data) {
                            //if success reload ajax table      
                            if (data.statusCode === 200) //if success close modal and reload ajax table
                                {
                                    toastr.success(data.status,"Thông báo!");                       
                      
                                }
                            else
                                if (data.statusCode === 400) {                            
                                    toastr.warning(data.status,"Error");
                                }
                            reload_table();
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            toastr.error(textStatus,'Error deleting data');
                        }
                    });
            }            
           
        },
        refreshTable : function () {
            reload_table();
        },
        WindowLoad: function () {
            $(document).ready(function () {
                //trigger all controls load
                triggerControls();
               // ExportView.displayServerSide();
                ExportView.displayClientSide();
            })
        }
    }
})();

ExportView.WindowLoad();
