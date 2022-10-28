function deleteComment() {
    let commentId = $(this).data('comment-id');
    fetch('/Collections/DeleteComment/' + commentId)
        .then((response) => {
            if (!response.ok) return;
            $(`.comment[data-comment-id="${commentId}"]`).remove();
        });
}

$('.delete-comment').click(deleteComment);

$('form.add-comment').submit(function (e) {
    e.preventDefault();
    let itemId = $(this).data('item-id');
    fetch(itemId + '/AddComment', {
        method: 'POST',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify({ commentText: $(this.elements['commentText']).val() })
    }).then((response) => {
        if (!response.ok) alert('There was an issue processing the request: ' + response.status);
        $('form.add-comment textarea[name="commentText"]').val('');
    });
});

var signalrConnection = new signalR.HubConnectionBuilder().withUrl("/CommentHub").build();

signalrConnection.on('ReceiveComment', comment => {
    let template = $('#comment-template')[0].innerHTML;
    let rendered = Mustache.render(template, { isAdmin: isAdmin, ...comment });
    $('#comments').prepend(rendered);
    $('.delete-comment').click(deleteComment);
});

signalrConnection.start().then(() => {
    signalrConnection.invoke("Connect", itemId.toString()).catch(error => console.error(error));
});