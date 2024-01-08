function Delete(Id) {


    $.get("DeleteLoanById?id=" + Id).done(function (data) {


        $('#myModalLoanContent').html(data);


        $('#DeleleLoanModal').modal();

    }).fail(function () {
        alert("عملیات با شکست مواجه شد !! ");
    });



}

function showModal(Id) {
    $.get("Details?id=" + Id).done(function (data) {
        $(".modal-body").html(data);
        $("#exampleModal").modal();
    });
}

$(function () {
    const urlParams = new URLSearchParams(window.location.search);
    $("#exampleInputSearch").val(urlParams.get('search'));
});