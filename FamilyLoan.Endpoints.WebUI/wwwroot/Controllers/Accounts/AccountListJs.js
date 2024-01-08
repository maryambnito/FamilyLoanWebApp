function Delete(Id) {


    $.get("DeleteAccountById?id=" + Id).done(function (data) {


        $('#myModalAccountContent').html(data);


        $('#DeleleAccountModal').modal();

    }).fail(function () {
        alert("عملیات با شکست مواجه شد !! ");
    });



}




function showModal(Id) {
    $.get("Details/" + Id).done(function (data) {
        $(".modal-body").html(data);
        $("#exampleModal").modal();
    });
}



$(function () {
    const urlParams = new URLSearchParams(window.location.search);
    $("#exampleInputSearch").val(urlParams.get('search'));
});