$(document).ready(function() {
    $('.tip').tooltip({
        track: true,
        delay: 0,
        showURL: false,
        showBody: " - ",
        fade: 250
    });
    $(".TakvimGoster").datepicker({ changeMonth: true,
        changeYear: true,
        clearText: 'Temizle',
        closeText: 'Kapat',
        prevText: '&#x3c;Geri',
        nextText: 'İleri&#x3e;',
        currentText: 'Bugün',
        monthNames: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'],
        monthNamesShort: ['Oca', 'Şub', 'Mar', 'Nis', 'May', 'Haz', 'Tem', 'Ağu', 'Eyl', 'Eki', 'Kas', 'Ara'],
        dayNames: ['Pazar', 'Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi'],
        dayNamesShort: ['Pz', 'Pt', 'Sa', 'Ça', 'Pe', 'Cu', 'Ct'],
        dayNamesMin: ['Pz', 'Pt', 'Sa', 'Ça', 'Pe', 'Cu', 'Ct'],
        dateFormat: 'dd.mm.yy', firstDay: 1,
        isRTL: false
    });
    if ($('#dialog').length) {
        var titles = Array("", "Bilgi", "Uyarı", "Hata Oluştu", "İşlem Başarılı");
        var title = '<img src="' + '/images/' + $('#dialog').attr("class") + '.png"> ' + titles[$('#dialog').attr("title")];

        $('#dialog').dialog({
            autoOpen: true,
            width: 400,
            title: title,
            modal: false,
            buttons: {
                "Tamam": function() {
                    $(this).dialog("close");
                }
            }
        });
    }
});