$(document).ready(function () {
    $('.select2').select2();
    $('#spanDateFromLoan').MdPersianDateTimePicker({
        targetTextSelector: '#FromDate'

    });
    $('#spanDateToLoan').MdPersianDateTimePicker({
        targetTextSelector: '#ToDate'
    });



});
$("#frmLoanReport").on('submit', function (e) {
    e.preventDefault();
    $("#LoanListTbl").html("");
    var state = $("#Loanstate").val();


    $.ajax({
        type: "POST",
        url: "/Report/LoanListFilter",
        data: $('#frmLoanReport').serialize(),
        success: function (data) {


            $("#LoanListTbl").html(data);


        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش لیست تراکنش ها');

        }

    });

    $.get("TotalLoansAmount?loanState=" + state, function (data) {
        $('#totalAmount').html(data);

    });


});

