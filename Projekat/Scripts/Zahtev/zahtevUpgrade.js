$('.upgrade').click(function () {
    event.preventDefault();
    var id = $(this).closest('.kartica').attr('id');
    $("#hiddenMaterijalId").val(id);
    $("#zahtevModal").modal('show');
})

$("#upgradeConfirm").on("click", function () {
    var id = $("#hiddenMaterijalId").val();
    var opis = $("#zahtevOpis").val();

    $.ajax({
        url: "/Zahtev/UpgradeMaterijal",
        method: "POST",
        data: {
            Id: id,
            opis: opis
        },
        success: function (result) {
            if (result) {
                alert("Uspesno podnet zahtev za postavljanje globalnog materijala");
            }
            else {
                alert("Vec postoji podnet zahtev za dati materijal.");
            }
            $("#zahtevOpis").val("");
        }
    });
})