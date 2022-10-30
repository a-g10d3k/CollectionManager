$('.confirm').click(function (e) {
    if (!confirm(confirmMessage)) {
        e.preventDefault();
        e.stopPropagation();
    }
});