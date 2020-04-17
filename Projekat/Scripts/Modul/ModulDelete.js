$('.delete').click(function () {
    var id = $(this).closest('.kartica-predmet').attr('id');
    console.log(id);
    $.ajax({
        url: "/Modul/Delete",
        method: "POST",
        data: {
            Id: id
        }
    });
})