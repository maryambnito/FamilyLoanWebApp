$(document).ready(function () {
    $('.select2').select2();
    $('#spanFromDate').MdPersianDateTimePicker({
        targetTextSelector: '#FromDate'

    });
    $('#spanToDate').MdPersianDateTimePicker({
        targetTextSelector: '#ToDate'
    });


    $('#addbenefitbtn').hide();
    $('#totalDivs').hide();
});
$("#frm-benefit-transaction").on('submit', function (e) {
    e.preventDefault();
    $('#addbenefitbtn').fadeIn();
    $('#totalDivs').fadeIn();


    $.ajax({
        type: 'POST',
        url: "/Benefit/BenefitList",
        data: $('#frm-benefit-transaction').serialize(),
        success: function (response) {

            $("#BenefitListTbl").html(response);

        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش لیست تراکنش ها');

        }

    });
   


    $.ajax({
        type: 'GET',
        url: "/Benefit/TotalAmount",
        data: $('#frm-benefit-transaction').serialize(),
        success: function (data) {

            $("#totalBenefitAmount").html(data);

        },

        error: function (xhr, status, error) {
            console.log('خطا در نمایش ');

        }

    });


});



function showbenefitModal(Id) {

    var select = document.getElementById('BenefitId');
    var value = select.options[select.selectedIndex].value;
    $.get("AddPaymentByBenefitId?Id=" + value).done(function (data) {


        $('#ModalContent').html(data);

        $('#AddBenefitModal').modal(options);
        $('#AddBenefitModal').modal('show');

    }).fail(function () {
        alert("عملیات با شکست مواجه شد !! ");
    });
}
