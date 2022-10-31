var tagInput = $('select[name="tags"]');
tagInput.selectize({
    delimiter: ',',
    options: [],
    create: true,
    persist: false,
    valueField: 'name',
    labelField: 'label',
    searchField: 'name',
    loadThrottle: 600,
    score: function () { return function () { return 1; } },
    load: function (query, callback) {
        if (query.length === 0) return callback();
        fetch('/Search/Tags?searchTerm=' + query).then((response) => {
            if (!response.ok) return callback();
            response.json().then((options) => {
                options = options.map(option => ({ name: option.name, label: option.name }))
                //tagInput[0].selectize.clearOptions();
                callback(options);
            });
        });
    }
});

$('.selectize-input input').attr('maxlength', '25');