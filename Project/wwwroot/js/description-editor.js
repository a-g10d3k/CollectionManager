const descriptionTextArea = $('#description-textarea')[0];
const stackedit = new Stackedit();

$('#edit-description').click(function () {
    stackedit.openFile({
        content: {
            text: descriptionTextArea.value
        }
    });
});

stackedit.on('fileChange', function (file) {
    descriptionTextArea.value = file.content.text;
    $('#description')[0].innerHTML = file.content.html;
})