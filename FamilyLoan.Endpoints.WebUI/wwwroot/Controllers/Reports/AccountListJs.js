$("#totalall").on("click", function () {
    $.get("TotalAmount").done(function (data) {
        $('#totalAmount').html(data);

    });
})