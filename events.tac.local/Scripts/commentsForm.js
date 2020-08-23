function createCommentItem(form, path) {
    var service = new ItemService({ url: '/sitecore/api/ssc/item' });
    var obj = {
        ItemName: 'comment - ' + form.name.value,
        TemplateID: '{D0DC0CAF-B777-442D-99EB-79A69DC6766C}',
        Name: form.name.value,
        Comment: form.comment.value
    };
    service.create(obj)
        .path(path)
        .execute()
        .then(function (item) {
            form.name.value = form.comment.value = '';
            window.alert("Thanks. Your message will appear on the site shortly");
        })
        .fail(function (err) { window.alert(err); });
    event.preventDefault();
    return false;
}