
$(document).ready(function () {

    $('#spanDateLoansAmount').MdPersianDateTimePicker({
        targetTextSelector: '#FromDateLoan'

    });
    $('#spanDateLoansAmount2').MdPersianDateTimePicker({
        targetTextSelector: '#ToDateLoan'
    });
    document.getElementById("LoanId").disabled = true;

    $('#addinstallmentbtn').hide();
    $('#totalloans').hide();


});


$("#CustomerId").on("change", function () {

    document.getElementById("LoanId").disabled = false;

    $('#addinstallmentbtn').hide();
    $('#totalloans').hide();
    $('#LoanId').html("");
    var Customerid = $("#CustomerId").val();
$.get('LoanList?Id=' + Customerid, function (data) {
        console.log(data);
        var list2 = '<option></option>';
        $.each(data, function (index, item) {

            list2 += "<option selected value='" + item.id + "'>" + item.loanNumber + "</option>";

        });
        $("#LoanId").html(list2);
    });


});

$("#frm-loan-installment").on('submit', function (e) {
    e.preventDefault();
    $('#addinstallmentbtn').fadeIn();
    $('#totalloans').fadeIn();


    $.ajax({
        type: 'POST',
        url: "/Installment/InstallmentList",
        data: $('#frm-loan-installment').serialize(),
        success: function (response) {

            $("#LoanListTbl").html(response);


        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش لیست تراکنش ها');

        }

    });

    $.ajax({
        type: 'GET',
        url: "/Installment/TotalInstallment",
        data: $('#frm-loan-installment').serialize(),
        success: function (response) {

            $('#totalInstallment').html(response);


        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش');

        }

    });
    $.ajax({
        type: 'GET',
        url: "/Installment/TotalLoan",
        data: $('#frm-loan-installment').serialize(),
        success: function (response) {

            $('#remainingloan').html(response);


        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش');

        }

    });


});


function modal(Id) {

    var select = document.getElementById('LoanId');
    var value = select.options[select.selectedIndex].value;
    $.get("AddInstallmentByLoanId?Id=" + value).done(function (data) {


        $('#ModalInstallmentContent').html(data);

        $('#AddInstallmentModal').modal(options);
        $('#AddInstallmentModal').modal('show');

    }).fail(function () {
        alert("عملیات با شکست مواجه شد !! ");
    });
}
