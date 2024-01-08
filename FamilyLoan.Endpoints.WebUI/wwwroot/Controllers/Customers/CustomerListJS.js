
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