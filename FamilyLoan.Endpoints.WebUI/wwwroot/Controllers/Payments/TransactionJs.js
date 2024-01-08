
$(document).ready(function () {
    $('.select2').select2();
    $('#spanDateAccountAmount').MdPersianDateTimePicker({
        targetTextSelector: '#FromDate'

    });
    $('#spanDateAccountAmount2').MdPersianDateTimePicker({
        targetTextSelector: '#ToDate'
    });
    document.getElementById("AccountId").disabled = true;
   
    $('#addbtn').hide();
    $('#totalDivs').hide();




    $('#spanDateLoansAmount').MdPersianDateTimePicker({
        targetTextSelector: '#FromDateLoan'

    });
    $('#spanDateLoansAmount2').MdPersianDateTimePicker({
        targetTextSelector: '#ToDateLoan'
    });
    document.getElementById("LoanId").disabled = true;

    $('#addinstallmentbtn').hide();
    $('#searchLoan').hide();
    $('#totalloans').hide();
});





$("#CustomerId").on("change", function () {
    document.getElementById("AccountId").disabled = false;

    document.getElementById("LoanId").disabled = false;

    $('#addbtn').hide();
    $('#totalAmount').html("");
    $("#PaymentAccountListTbl").html("");

    $('#addinstallmentbtn').hide();
    $('#totalloans').hide();

  

    $('#AccountId').html("");
    $('#LoanId').html("");

    var Customerid = $("#CustomerId").val();
    $.get('AccountList?Id=' + Customerid, function (data) {
        
        var list = '<option></option>';
        $.each(data, function (index, item) {

            list += "<option selected value='" + item.id + "'>" + item.accountNO + "</option>";

        });
        $("#AccountId").html(list);
    });


    $.get('LoanList?Id=' + Customerid, function (data) {
 
        var list2 = '<option></option>';
        $.each(data, function (index, item) {

            list2 += "<option selected value='" + item.id + "'>" + item.loanNumber + "</option>";

        });
        $("#LoanId").html(list2);
    });


});




$("#frm-add-transaction").on('submit', function (e) {
    e.preventDefault();
    $('#addbtn').fadeIn();
    $('#totalDivs').fadeIn();


    $.ajax({
        type: 'POST',
        url: "/Payment/PaymentAccountList",
        data: $('#frm-add-transaction').serialize(),
        success: function (response) {

            $("#PaymentAccountListTbl").html(response);
        

        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش لیست تراکنش ها');

        }

    });



    $.ajax({
        type: 'GET',
        url: "/Payment/TotalAmount",
        data: $('#frm-add-transaction').serialize(),
        success: function (data) {

            $("#totalAmount").html(data);


        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش');

        }
    });
    //let select = document.getElementById('AccountId');
    //let value = select.options[select.selectedIndex].value;
    //$.get("TotalAmount?AccountId=" + value).done(function (data) {
    //    $('#totalAmount').html(data);

    //});


});


function showModal(Id) {

    var select = document.getElementById('AccountId');
    var value = select.options[select.selectedIndex].value;
    $.get("AddPaymentByAccountId?Id=" + value).done(function (data) {


        $('#ModalContent').html(data);

        $('#AddAccountModal').modal(options);
        $('#AddAccountModal').modal('show');

    }).fail(function () {
        alert("عملیات با شکست مواجه شد !! ");
    });
}




$("#frm-loan-installment").on('submit', function (e) {
    e.preventDefault();
    $('#addinstallmentbtn').fadeIn();
    $('#totalloans').fadeIn();


    $.ajax({
        type: 'POST',
        url: "/Payment/InstallmentList",
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
        url: "/Payment/TotalInstallment",
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
        url: "/Payment/TotalLoan",
        data: $('#frm-loan-installment').serialize(),
        success: function (response) {

            $('#remainingloan').html(response);
            if (response == "0") {
                $('#addinstallmentbtn').hide();
            }

        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش');

        }

    });


});

$("#LoanId").on("change", function () {
    $('#searchLoan').show();
    $('#addinstallmentbtn').hide();
    $("#LoanListTbl").html("");
    $("#totalInstallment").html("");
    $("#remainingloan").html("");
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
