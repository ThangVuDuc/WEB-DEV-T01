class Base {
    constructor() {

    }

    getData() {
        var fakeData = [];
        var pageIndex = $('.page-index').val();
        var pageSize = $('.page-size').val();
        $.ajax({
            method: 'GET',
            url: '/refs/{0}/{1}'.format(pageIndex, pageSize),
            dataType: 'json',
            async: false,
            success: function (res) {
                if (res.Success) {
                    fakeData = res.Data;
                } else {
                    alert(res.Message);
                }
            }
        });
        return fakeData;
    }

    loadData() {
        var me = this;
        var data = this.getData();
        var fields = $('.main-table th[fieldName]');
        var target = '.main-table tbody';
        var id = 'RefID';
        me.bindingTableData(fields, data, target, id);
        //Hàm delay con quay load data
        $("#loadData").hide();
    }

    //Thực hiện format lại định dạng tiền khi người dùng nhập liệu vào ô input "Số tiền"
    //Người tạo VDThang29/07/2019
    FomartCurrency() {
        $(this).attr('maxlength', '14');
        $(this).val(formatCurrency(this.value.replace(/[.]/g, '')));
        var valueInput = $(this).val();
        //Nếu đầu chuỗi là số 0 thì thực hiện loại bỏ
        if (valueInput.length >= 2 && valueInput[0] == "0" && valueInput[1] != "0" && valueInput[1] != ".") {
            $(this).val(this.value.substring(1, this.value.length));
        }
        //Không cho người dùng nhập ký tự khác ký tự số
        $(this).keypress(function (e) {
            if (!$.isNumeric(String.fromCharCode(e.which))) {
                $(this).val(this.value.substring(0, this.value.length));
                e.preventDefault();
            }
        }).on('paste', function (e) {
            //Không cho người dùng paste các giá trị khác kiểu số
            var cb = e.originalEvent.clipboardData || window.clipboardData;
            if (!$.isNumeric(cb.getData('text'))) e.preventDefault();
        });
        //Nếu người dùng xóa hết thì để giá trị mặc định là 0
        if (valueInput == "") {
            $(this).val("0");
        }
    }

    //Thực hiện ghi dữ liệu ra bảng
    //Người tạo VDThang 05/08/2019
    bindingTableData(fields, data, target, id) {
        $(target).empty();
        $.each(data, function (index, item) {
            var rowHTML = $('<tr></tr>').data("recordid", item[id]);
            $.each(fields, function (fieldIndex, fieldItem) {
                var fieldName = fieldItem.getAttribute('fieldName');
                var fieldValue = item[fieldName];
                var cls = 'text-left';
                if (fieldName == "refDate") {
                    fieldValue = new Date(fieldValue);
                }
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
            $(target).append(rowHTML);
        });
    }
}