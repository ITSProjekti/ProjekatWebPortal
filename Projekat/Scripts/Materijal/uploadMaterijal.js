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

var forma = $('#postavkaMat');
var modulId = $('#modulId').find($("option:selected")).val();
$('#modulId').on('change', function () {
    modulId = $('#modulId').find($("option:selected")).val();
}

$('#postavkaMat').validate({
    rules: {
        "Materijal.materijalNaslov": {
            required: true
        },
        "Materijal.materijalOpis": {
            required: true
        },
        file: {
            required: true,

            extension: "jpeg|png|jpg|pdf|mp4|rtf|txt|text|gif|rar|zip"
            ,
            maxFileSize: {
                "unit": "KB",
                "size": 5000
            },
            minFileSize: {
                "unit": "KB",
                "size": "1"
            }
        }
    },
    messages: {
        "Materijal.materijalNaslov": {
            required: "Polje naslov je obavezno."
        },
        "Materijal.materijalOpis": {
            required: "Polje opis je obavezno."
        },
        file: {
            required: "Morate odabrati fajl.",
            extension: "Pogrešan format fajla.",
            maxFileSize: "Fajl ne sme biti veći od 5MB",
            minFileSize: "Fajl ne sme biti manji od 1KB"
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
            url: '/Materijal/UplaodMaterijal',
            data: {
                id: predmetId,
                modulId: modulId,
                sort: sort,
                tipovi: tipovi,
                formati: formati
            },
        });
        sessionStorage.setItem('upload', true);
        forma.submit();
    }
});