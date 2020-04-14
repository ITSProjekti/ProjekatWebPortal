$(document).ready(function () {
    $(".customSelect").trigger('change');

    var predmetId = sessionStorage.getItem('predmetId');

    if (predmetId != undefined)
        $("#Materijal_predmetId").val(predmetId);
    else
        $("#Materijal_predmetId").val($('#Materijal_predmetId option').first().val());

    var isUploaded = sessionStorage.getItem('upload');

    if (isUploaded) {
        $('#snackbar').css('display', 'block');
        sessionStorage.removeItem('upload');
    }
    else
        $('#snackbar').css('display', 'none');
});

var forma = $('#postavkaMod');

$('#postavkaMod').validate({
    rules: {
        "Modul.materijalNaslov": {
            required: true
        },
        "Modul.materijalOpis": {
            required: true
        }
    },
    messages: {
        "Modul.materijalNaslov": {
            required: "Polje naslov je obavezno."
        },
        "Modul.materijalOpis": {
            required: "Polje opis je obavezno."
        }
    },
    errorPlacement: function (error, element) {
        if (element.attr("name") == "file") {
            error.insertAfter(element.next());
        }
        else {
            error.insertAfter(element);
        }
    },
    submitHandler: function (forma) {
        $.ajax({
            method: 'POST',
            url: '/Modul/DodajModul',
            data: {
                id: predmetId,
                materijalNaslov: modulNaziv,
                materijalOpis: modulOpis
            },
        });
        sessionStorage.setItem('upload', true);
        forma.submit();
    }
});