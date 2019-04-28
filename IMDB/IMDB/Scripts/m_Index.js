function dialog(id) {    
    if (confirm('Confirm Delete?')) {
        $.ajax
        ({
            method: "post",
            url: '/Movies/Delete',
            data: { id: id },
            success: function () {
                window.location.reload();
            },
            error: function () {

            }
        });
    }
}