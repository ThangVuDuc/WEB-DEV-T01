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
            'jsObject': 123456,
            'name': 'Vũ Đức Thắng'
        }, this.RowOnClick);
        //$(document).on('click', 'button.delete', { 'jsObject': this }, this.ClickButton);
        $(document).on('click', 'button.delete', this.ClickButton.bind(this));
        $(document).on('click', 'button.add-new', this.ShowDialogAdd);
        $(document).on('click', '.uncheck', this.TickRow);
        $(document).on('click', '#save', this.SaveRef.bind(this));
    }

    /**
     * Hàm thực hiện mở dialog thêm mới
     * Người tạo: VDTHANG
     * Ngày tạo: 24/07/2019
     * Người sửa: NVMANH
     * Ngày sửa: 22/07/2019
     * Nội dung sửa: sửa lại nội dung thông báo
     * */
    ShowDialogAdd() {
        $("#dialog").dialog({
            modal: true,
            height: 500,
            width: 300,
            resizable: false,
            dialogClass: "dialog-add",
        });
    }

    /**
     * Hàm thực thêm mới phiếu hóa đơn
     * Người tạo: VDTHANG
     * Ngày tạo: 24/07/2019
     * */
    SaveRef() {
        var me = this;
        var inputs = $('#dialog input');
        var object = {};
        $.each(inputs, function (index, item) {
            var propertyName = item.getAttribute('property');
            var propertyValue = $(this).val();
            object[propertyName] = propertyValue;
        });
        $.ajax({
            method: 'POST',
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
        var jsObject = event.data['jsObject'];
        var name = event.data['name'];
        $('button.delete').removeAttr('disabled');
        $('.main-table tbody tr').removeClass('select');
        $(this).addClass('select');
    }

    ClickButton(event) {
        //var me = event.data['jsObject'];
        var me = this;
        //me.DemoParam(1234456, "NVManh");
        var listRow = $('.select,.tick[recordid]');
        var listID = [];
        $.each(listRow, function (index, item) {
            listID.push(item.getAttribute('recordid'));
        });
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

