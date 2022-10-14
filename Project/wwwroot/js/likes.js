$('.like').click(function () {
    let itemId = $(this).data('id');
    if ($(this).data('liked') == "True") {
        fetch(itemId + "/Unlike").then((response) => {
            if (!response.ok) return;
            $(this).data('liked', 'False');
            $(this).children('i').removeClass('icon-liked');
            $(this).children('i').addClass('icon-unliked');
            let likeCount = $(this).children('.like-counter').data('value');
            $(this).children('.like-counter').data('value', likeCount - 1);
            $(this).children('.like-counter').html(likeCount - 1);
        });
    } else {
        fetch(itemId + "/Like").then((response) => {
            if (!response.ok) return;
            $(this).data('liked', 'True');
            $(this).children('i').removeClass('icon-unliked');
            $(this).children('i').addClass('icon-liked');
            let likeCount = $(this).children('.like-counter').data('value');
            $(this).children('.like-counter').data('value', likeCount + 1);
            $(this).children('.like-counter').html(likeCount + 1);
        });
    }
});