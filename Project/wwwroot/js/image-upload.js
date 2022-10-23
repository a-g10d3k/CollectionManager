FilePond.registerPlugin(FilePondPluginImagePreview);

FilePond.create(
    $('input[name="collectionImage"]')[0],
    {
        imagePreviewHeight: 300,
        storeAsFile: true
    }
)