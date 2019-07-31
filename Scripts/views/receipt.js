$(document).ready(function () {

});

class Ref extends Base {
    constructor() {
        super();
        this.loadData();
        this.InitEvents();
    }

    InitEvents() {
        $('tbody').on('click', 'tr', {
            'jsObject': this,
            'name': 'Vũ Đức Thắng'
        }, this.RowOnClick);
        //$(document).on('click', 'button.delete', { 'jsObject': this }, this.ClickButton);
        $(document).on('click', 'button.delete', this.ClickButton.bind(this));
        $(document).on('click', '.uncheck', this.TickRow);

        $(document).on('click', '.dialog-edit #save', { "jsObject": "PUT" }, this.SaveRef.bind(this));
        $(document).on('click', '.dialog-add #save', { "jsObject": "POST" }, this.SaveRef.bind(this));

        $(document).on('click', 'button.add-new', this.ShowDialogAdd.bind(this));
        $(document).on('click', 'button.edit', this.ShowDialogEdit.bind(this));
        $(document).on('click', 'button.view', this.ShowDialogView.bind(this));
        $(document).on('click', 'button.duplicate', this.ShowDialogDuplicate.bind(this));

        $(document).on('input', '#dialog input[property="total"]', this.FomartCurrency)
    }
    /**
     * Hàm thực hiện mở dialog nhân bản phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 29/07/2019
     * */
    ShowDialogDuplicate() {
        var me = this;
        me.OpenDialog("dialog-add", "Thêm phiếu thu");
        me.BindingDataDialog();
        $('#dialog input').prop("disabled", false);
        $('#dialog #save').removeClass('hide-button');
    }
    /**
     * Hàm thực hiện mở dialog xem phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 29/07/2019
     * */
    ShowDialogView() {
        var me = this;
        me.OpenDialog("dialog-view", "Xem phiếu thu");
        me.BindingDataDialog();
        $('#dialog #save').addClass('hide-button');
        $('#dialog input').prop("disabled", true);
    }

    /**
     * Hàm thực hiện mở dialog sửa phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 29/07/2019
     * */
    ShowDialogEdit() {
        var me = this;
        me.OpenDialog("dialog-edit", "Sửa phiếu thu");
        me.BindingDataDialog();
        $('#dialog input').prop("disabled", false);
        $('#dialog #save').removeClass('hide-button');
    }

    /**
     * Hàm thực hiện mở dialog thêm mới phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 29/07/2019
     * */
    ShowDialogAdd() {
        var me = this;
        me.OpenDialog("dialog-add", "Thêm mới phiếu thu");
        $('#dialog input').prop("disabled", false);
        $('#dialog input').val("");
        $('#dialog #save').removeClass('hide-button');
    }

    /**
     * Hàm thực hiện bind dữ liệu tương ứng vào các ô nhập liệu trong dialog
     * Người tạo: VDThang
     * Ngày tạo: 29/07/2019
     * */
    BindingDataDialog() {
        var id = this.GetRowID();
        $.ajax({
            method: 'Get',
            url: '/refs/' + id,
            success: function (res) {
                var fields = $('#dialog input[property]');
                $.each(fields, function (index, item) {
                    var propertyName = item.getAttribute('property');
                    $(this).val(res[propertyName]);
                });
            },
            error: function () {
                alert("Hệ thống đang lỗi! Vui lòng liên hệ MISA");
            }
        });
    }

    /**
     * Hàm thực hiện lấy id của 1 bản ghi phiếu thu
     * Người tạo: VDThang
     * Ngày tạo: 29/07/2019
     * */

    GetRowID() {
        var id = $('.select,tick[recordid]').data('recordid');
        return id;
    }

    /**
     * Hàm thực hiện mở dialog
     * Người tạo: VDTHANG
     * Ngày tạo: 24/07/2019
     * */
    OpenDialog() {
        var cls = arguments[0];
        var title = arguments[1];
        $("#dialog").dialog({
            modal: true,
            height: 500,
            width: 300,
            resizable: false,
            dialogClass: cls,
            title: title,
            //close: function () {
            //    alert(1);
            //}
        });
    }

    /**
     * Hàm thực thêm mới phiếu hóa đơn
     * Người tạo: VDTHANG
     * Ngày tạo: 24/07/2019
     * */

    SaveRef(event) {
        var method = event.data["jsObject"];
        var me = this;
        var inputs = $('#dialog input');
        var object = {};
        $.each(inputs, function (index, item) {
            var propertyName = item.getAttribute('property');
            var propertyValue = $(this).val();
            object[propertyName] = propertyValue;
        });
        if (method === "PUT") {
            object["refID"] = me.GetRowID();
        }
        $.ajax({
            method: method,
            url: '/refs',
            data: JSON.stringify(object),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                $('#dialog').dialog('close');
                me.loadData();
            },
            error: function () {
                alert("Hệ thống đang bị lỗi! Vui lòng liên hệ MISA!");
            }
        })
    }

    /**
     * Hàm thực hiện tick vào cột chọn dữ liệu đầu tiên
     * Người tạo VDThang
     * Ngày tạo: 24/07/2019
     * */

    TickRow() {
        $(this).parent().addClass('tick');
    }

    /**
     * Hàm thực hiện thông báo khi click vào 1 hàng
     * Người tạo: VDTHANG
     * Ngày tạo: 18/07/2019
     * Người sửa: NVMANH
     * Ngày sửa: 22/07/2019
     * Nội dung sửa: sửa lại nội dung thông báo
     * */

    RowOnClick(event) {
        var me = event.data['jsObject'];
        var name = event.data['name'];
        $('button.delete').removeAttr('disabled');
        $('button.duplicate').removeAttr('disabled');
        $('button.edit').removeAttr('disabled');
        $('button.view').removeAttr('disabled');
        $('.main-table tbody tr').removeClass('select');
        $(this).addClass('select');
        me.LoadDetailTable();
    }

    /**
     * Hàm thực hiện call service lấy các bản ghi chi tiết tương ứng
     * Người tạo: VDThang
     * Ngày tạo: 31/07/2019
     */
    LoadDetailTable() {
        var me = this;
        var refid = me.GetRowID();
        $.ajax({
            method: 'GET',
            url: '/refdetails/' + refid,
            success: function (res) {
                if (res.Success) {
                    debugger
                    var fields = $('.detail-table th[fieldName]');
                    $('.detail-table tbody').empty();
                    $.each(res.Data, function (index, item) {
                        var rowHTML = $('<tr></tr>').data("recordid", item["RefDetailID"]);
                        $.each(fields, function (fieldIndex, fieldItem) {
                            var fieldName = fieldItem.getAttribute('fieldName');
                            var fieldValue = item[fieldName];
                            var cls = 'text-left';
                            var type = $.type(fieldValue);
                            switch (type) {
                                case "number":
                                    fieldValue = fieldValue.formatMoney();
                                    cls = 'text-right';
                                    break;
                                case "date":
                                    fieldValue = fieldValue.formatddMMyyyy();
                                    cls = 'text-center';
                                    break;
                            }
                            if (fieldName) {
                                rowHTML.append('<td class = "{1}">{0}</td>'.format(fieldValue, cls));
                            } else {
                                rowHTML.append('<td class = "{0}"></td>'.format("uncheck"));
                            }
                        });
                        $('.detail-table tbody').append(rowHTML);
                    });
                } else {
                    alert(res.Message);
                }
            }
        })
    }

    /**
     * Hàm thực hiện xóa hàng dữ liệu được chọn
     * Người tạo: VDThang
     * Ngày tạo: 24/07/2019
     * @param {any} event
     */

    ClickButton(event) {
        //var me = event.data['jsObject'];
        var me = this;
        //me.DemoParam(1234456, "NVManh");
        var listRow = $('.select,.tick');
        debugger
        var listID = [];
        $.each(listRow, function (index, item) {
            listID.push($(item).data('recordid'));
        });
        debugger
        $.ajax({
            method: 'DELETE',
            url: '/refs',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(listID),
            success: function (res) {
                me.loadData();
            },
            error: function (res) {
                alert("Hệ thống đang bị lỗi! Vui lòng liên hệ MISA!");
            }
        });
    }

    DemoParam() {
        var code = arguments[0];
        var name = arguments[1];
        debugger
    }

}

var refJS = new Ref();

