// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
app = (function () {
    var inner = {}
    inner.directionScreen = function () {
        var btnCreate;
        function fetchCard(cardNumber) {
            $.get("/api/directions/" + cardNumber, function (data) {
                console.log(data);
                $('#direcionList').html('');
                data.directions.forEach(x => {
                    var li = $('<li class="list-group-item">' + x.streetName + ',' + x.houseNumber + '</li>');
                    $('#direcionList').append(li);
                    li.data('direction-id', x.directionId);
                    li.click(el => {
                        console.log($(el.target).data('direction-id'));
                    });
                });
            });
        }
        function fetchCardList(loadFirstCard) {
            $.get("/api/directions", function (data) {
                console.log(data);
                var select = $("#cardList");
                select.html('');
                if (data.cardsNumbers) {
                    debugger;
                    data.cardsNumbers.forEach(x => select.append('<option>' + x + '</option>'));
                    if (loadFirstCard && (data.cardsNumbers.length > 0)) {
                        fetchCard(data.cardsNumbers[0]);
                    }
                }
            });
        }
        function initEvents() {
            $("#cardList").change(x => fetchCard($("#cardList").val()));
            $(btnCreate).click(() => {
                $('#modalCreate').modal('show');
            });
        }

        if (btnCreate = document.getElementById('createNewDirection')) {
            fetchCardList(true);
            initEvents();
        }
    }
    return inner;
})();

$(document).ready(() => {
    app.directionScreen();
});

