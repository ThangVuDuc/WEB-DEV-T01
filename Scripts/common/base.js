class Base {
    constructor() {

    }

    getData() {
        var fakeData = [];
        $.ajax({
            method: 'GET',
            url: '/refs',
            async: false,
            success: function (res) {
                fakeData = res;
            },
            error: function (res) {
                alert("Dịch vụ đang có lỗi. Vui lòng liên hệ MISA");
            }
        });
        return fakeData;
    }

    loadData() {
        var me = this;
        var data = this.getData();
        $('tbody').empty();
        $.each(data, function (index, item) {
            //var demo = me.getData();
            var rowHTML = $('<tr>'
                + '<td></td>'
                + '<td>' + item.refDate + '</td>'
                + '<td class = "refno">' + item.refNo + '</td>'
                + '<td>' + item.refType + '</td>'
                + '<td>' + item.total + '</td>'
                + '<td>' + item.contactName + '</td>'
                + '<td>' + item.reason + '</td>'
                + '</tr > ');
            setTimeout(function () {
                $('tbody').append(rowHTML);
            }, 500)
        })
    }
}