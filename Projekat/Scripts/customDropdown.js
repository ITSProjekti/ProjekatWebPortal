﻿$(document).ready(function () {

    brojKlikovaNaLupu = 0;

    $(".customDropdown").each(function () {
        var customSelect = '<div class="customSelect" id="trenutnoPravim"> <div class="izabraniUselectu"> <span>' +
            $(this).find("option:selected").text() + '</span> <div class="trougao"></div> </div> <ul class="customLista"></ul> </div>';

        $(this).after(customSelect);

        var arrayLijeva = $(this).find($('option')).toArray();

        $.each(arrayLijeva, function (index, value) {
            $('#trenutnoPravim ul.customLista').append(($("<li id='" + arrayLijeva[index].getAttribute('id') + "'></li>").text($(this).text())));
        });

        var lista = $('.customLista li');

        $('#trenutnoPravim').removeAttr('id');
    });

    var formati;
    $('.select2formati').select2({
        width: "auto",
        //placeholder: "Format materijala",
    });

    var materijali;
    $('.select2materijali').select2({
        width: "auto",
        //placeholder: "Tip materijala",
    });

    var datum;
    $('.select2_datum').select2({
        width: "auto",
        minimumResultsForSearch: Infinity,

    });

    //POCETAK TEST
    function selECT2LbeliResize(ovo) {

        if ($(this).val() !== null) {
            console.log("nije prazan input");
            $(this).prev().css("transform", "scale(6) translate(8px, -4.7px)");
            $(this).next().find("span.select2-selection--multiple").css("height", "50px");
            $(this).next().css("margin-top", "0px");
            $(this).next().find(".select2-selection__rendered").css({ "margin-top": "7px", "height": "43px", "margin-bottom": "0" });
            $(this).next().find(".select2-search__field").css({ "margin-top": "7px", "height": "30px", "margin-bottom": "3px" });
        }
        else {
            console.log("prazan je input");
            $(this).prev().css("transform", "scale(8) translate(8px, -0.5px)");
            $(this).next().find("span.select2-selection--multiple").css("height", "20px");
            $(this).next().css("margin-top", "9px");
            $(this).next().find(".select2-selection__rendered").css({ "margin-top": "0", "height": "30px", "margin-bottom": "5px" });
            $(this).next().find(".select2-search__field").css({ "margin-top": "22px", "height": "30px", "margin-bottom": "0" });
        }
    };

    $('.select2-hidden-accessible').on('load change', selECT2LbeliResize);
    //$('.select2-search__field').on('load keyup', selECT2LbeliResize($(this).closest(".select2-container").prev(".select2-hidden-accessible")));//ovo ne radi, moraces odvojenu funkciju

    //KRAJ TEST
    

    $("#lupaPretragaToggle").click(function () {

        $('.select2-hidden-accessible').trigger("change");

        if (brojKlikovaNaLupu < 1) {
            $(".customLista").each(function () {
                var sirinaListe = parseFloat($(this).css('width'));

                console.log(sirinaListe + " ovo je sirinaListe");

                $(this).css("width", sirinaListe + 32 + "px");
                $(this).parent().css("width", $(this).css("width"));
            });
        }
        brojKlikovaNaLupu = 2;
    });


    $(".customSelect").click(function () {
        $(this).find($('.customLista')).slideToggle(200);
        $(this).find($(".izabraniUselectu .trougao")).toggleClass("rotate");
        $(this).toggleClass("customSelectHighlightovan");
        $(this).find($(".izabraniUselectu")).toggleClass("izabraniUselectuHighlightovan");
    });


    $(".customSelect li").click(function () {
        var kliknutiTekst = $(this).text();
        $(this).parent().siblings("div").find('span').text($(this).text());
        $(this).parent().parent().prev().find($("option").filter(function () {
            return $(this).text() === kliknutiTekst;
        }).prop('selected', true));

    });

    $('.select2materijali').on('select2:unselect', function () {
        $(this).delay(800).select2("close");
    });

    /*$('.select2-hidden-accessible').on('load change', function() {
    //$('.select2-hidden-accessible').change(function () {
        if($(this).val()!==null){
            //$(this).prev().css({ "font-size": "14px", "transform": "translate(106%, -24px)" });
            $(this).prev().css("transform", "scale(6) translate(8px, -4.7px)");
            //$(this).next().css("margin-top", "6px");
            $(this).next().find("span.select2-selection--multiple").css("height", "50px");
            $(this).next().css("margin-top", "0px");
            $(this).next().find(".select2-selection__rendered").css({ "margin-top": "7px", "height": "43px", "margin-bottom": "0" });
            //$(this).next().find(".select2-search__field").css({ "margin-top": "0", "height": "30px", "margin-bottom": "22px" });

            $(this).next().find(".select2-search__field").css({ "margin-top": "7px", "height": "30px", "margin-bottom": "3px" });
            //console.log("pun");
            //console.log($(this).val());
        }
        else {
            $(this).prev().css("transform", "scale(8) translate(8px, -0.5px)");
            //$(this).next().css("margin-top", "0");
            //$(this).next().filter("span.select2-selection--multiple").css("height", "20px");
            //console.log($(this).next().filter("span.select2-selection--multiple"));
            $(this).next().find("span.select2-selection--multiple").css("height", "20px");
            $(this).next().css("margin-top", "9px");
            $(this).next().find(".select2-selection__rendered").css({ "margin-top": "0", "height": "30px", "margin-bottom": "5px" });

            $(this).next().find(".select2-search__field").css({ "margin-top": "22px", "height": "30px", "margin-bottom": "0" });

            //console.log("prazan");
            //console.log($(this).val());

        }

    });*/
});