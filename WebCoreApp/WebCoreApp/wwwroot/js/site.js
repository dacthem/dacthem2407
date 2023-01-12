$(document).ready(function () {
    $('.my-table').DataTable();
    $('.select-category').select2({
        dropdownParent: $('.modal')
    });
    $("#listcate").change(function () {
        let id = $("#listcate").val ();
        console.log("ID=" + id);
        $("#result").load("/Product/Sort/" + id);
    });
});