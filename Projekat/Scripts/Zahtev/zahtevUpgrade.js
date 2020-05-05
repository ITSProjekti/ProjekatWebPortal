function validate() {
    var value = $('#zahtevOpis').val();

    if (value.length < 5 || value.length > 250) {
        $('#poruka').text("Opis mora imati između 5 i 250 karaktera.");
        return false;
    }
    else {
        
        $('#poruka').empty();
        return true;
    }
};
$('.upgrade').click(function () {
    event.preventDefault();
    var id = $(this).closest('.kartica').attr('id');
    $("#hiddenMaterijalId").val(id);
    $('#poruka').empty();
    $('#zahtevOpis').empty();
    $("#zahtevModal").modal('show');
    
})
$('#zahtevOpis').keyup(function () {
    validate();
});

$("#upgradeConfirm").on("click", function () {
    var id = $("#hiddenMaterijalId").val();
    var opis = $("#zahtevOpis").val();
    if (validate()) {
        $.ajax({
            url: "/Zahtev/UpgradeMaterijal",
            method: "POST",
            data: {
                Id: id,
                opis: opis
            },
            success: function (result) {
                $("#zahtevModal").modal('hide');
                if (result) {
                    
                    alert("Uspesno podnet zahtev za postavljanje globalnog materijala");

                }
                else {
                   
                    alert("Vec postoji podnet zahtev za dati materijal.");
                }
                $("#zahtevOpis").val("");
            }
        });
    }
    
})