$('input[name="darkmode-toggle"]').change(function () {
    if ($('input[name="darkmode-toggle"]:checked').val() == 'true') {
        $('body').addClass('dark');
    } else {
        $('body').removeClass('dark');
    }
});