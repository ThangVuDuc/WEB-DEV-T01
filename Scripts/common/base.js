class Base {
    constructor() {

    }

    getData() {
        var fakeData = [];
        $.ajax({
            method: 'GET',
            url: '/refs',
            dataType: 'json',
            async: false,
            success: function (res) {
                fakeData = res;
            },
            error: function () {
                alert("Hệ thống đang bị lỗi! Vui lòng liên hệ MISA!");
            }
        });
        return fakeData;
    }

    loadData() {
        var me = this;
        var data = this.getData();
        var fields = $('.main-table th[fieldName]');
        $('.main-table tbody').empty();
        $.each(data, function (index, item) {
            var rowHTML = $('<tr recordid ="{0}"></tr>'.format(item["refID"]));
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
            $('.main-table tbody').append(rowHTML);
        });

    }
}