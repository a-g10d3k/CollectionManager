$('input[name="darkmode-toggle"]').change(function () {
    if ($('input[name="darkmode-toggle"]:checked').val() == 'true') {
        $('body').addClass('dark');
        localStorage.setItem('darkmode', 'true');
    } else {
        $('body').removeClass('dark');
        localStorage.setItem('darkmode', 'false');
    }
});

if (localStorage.getItem('darkmode') == 'true') {
    $('#darkmode-toggle-dark').prop('checked', true)
} else {
    $('#darkmode-toggle-light').prop('checked', true)
}