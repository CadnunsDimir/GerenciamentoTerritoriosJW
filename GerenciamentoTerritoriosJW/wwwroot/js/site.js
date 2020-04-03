// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
app = (function () {
    var inner = {}
    inner.directionScreen = function () {
        var btnCreate;
        if (btnCreate = document.getElementById('createNewDirection')) {
            $(btnCreate).click(() => {
                $('#modalCreate').modal('show');
            });
        }
    }

    return inner;
})();

$(document).ready(() => {
    app.directionScreen();
});

