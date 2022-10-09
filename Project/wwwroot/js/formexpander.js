
function updateDisableHiddenInputs() {
    let name = $(this).attr("name");
    let disabled = $(this).prop("disabled");
    $(`input[type="hidden"][name="${name}"]`).prop("disabled", disabled);
}

$('.form-expandable').each(function () {
    $(this).children('button.form-expand').click({ parent: this }, function (e) {
        $(e.data.parent).children('.expandable-input').each(function () {
            if (this.hidden) {
                this.hidden = false;
                let inputs = $(this).find('input,textarea');
                inputs.prop("disabled", false);
                inputs.each(updateDisableHiddenInputs);
                return false;
            }
        });
    });

    $(this).children('button.form-collapse').click({ parent: this }, function (e) {
        $($(e.data.parent).children('.expandable-input').get().reverse()).each(function () {
            if (!this.hidden) {
                this.hidden = true;
                let inputs = $(this).find('input,textarea');
                inputs.prop("disabled", true);
                inputs.each(updateDisableHiddenInputs);
                return false;
            }
        });
    });
});

$('input[type="checkbox"]').each(updateDisableHiddenInputs);