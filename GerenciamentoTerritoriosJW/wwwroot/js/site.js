// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$.postJSON = function (url, data, callback) {
    function logdata(data) {
        console.log(data);
    }

    return jQuery.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'type': 'POST',
        'url': url,
        'data': JSON.stringify(data),
        'dataType': 'json',
        success: logdata,
        error: logdata,
        complete: callback
    });
};

app = (function () {
    var inner = {}
    inner.directionScreen = function () {
        var btnCreate;
        function fetchCard(cardNumber) {
            $.get("/api/directions/" + cardNumber, function (data) {
                console.log(data);
                $('#direcionList').html('');
                data.directions.forEach(x => {
                    //var li = $('<li class="list-group-item">' + x.streetName + ',' + x.houseNumber + '</li>');
                    var li = $(node('li', x.streetName + ',' + x.houseNumber, 'list-group-item'));
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
                    data.cardsNumbers.forEach(x => select.append('<option>' + x + '</option>'));
                    if (loadFirstCard && (data.cardsNumbers.length > 0)) {
                        fetchCard(data.cardsNumbers[0]);
                    }
                }
            });
        }
        function formSubmit(event) {
            event.preventDefault();
            var newDirection = {};
            $("#createDirectionForm").serializeArray().forEach(x => newDirection[x.name] = x.value);

            $.postJSON('/api/directions', newDirection, data => {
                if (data.status == 200) {
                    $('#createDirectionForm').each(function () {
                        this.reset();
                    });
                    $('#modalCreate').modal('hide');
                } else {
                    // show error
                }
                
            });
        }
        function initEvents() {
            $("#cardList").change(() => fetchCard($("#cardList").val()));
            $(btnCreate).click(() => {
                $('#modalCreate').modal('show');
                $('#cardNumber').val($("#cardList").val());
            });
            estados_brasileiros.forEach(estado => $("#state").append(node('option', estado.uf)));
            $("#createDirectionForm").submit(formSubmit);
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

function node(tagName, content, classValue) {
    var tag = document.createElement(tagName);
    tag.innerHTML = content;
    tag.setAttribute('class', classValue);
    return tag;
}

var estados_brasileiros = [
    { uf: 'AC', nome: 'Acre' },
    { uf: 'AL', nome: 'Alagoas' },
    { uf: 'AP', nome: 'Amapá' },
    { uf: 'AM', nome: 'Amazonas' },
    { uf: 'BA', nome: 'Bahia' },
    { uf: 'CE', nome: 'Ceará' },
    { uf: 'DF', nome: 'Distrito Federal' },
    { uf: 'ES', nome: 'Espirito Santo' },
    { uf: 'GO', nome: 'Goiás' },
    { uf: 'MA', nome: 'Maranhão' },
    { uf: 'MS', nome: 'Mato Grosso do Sul' },
    { uf: 'MT', nome: 'Mato Grosso' },
    { uf: 'MG', nome: 'Minas Gerais' },
    { uf: 'PA', nome: 'Pará' },
    { uf: 'PB', nome: 'Paraíba' },
    { uf: 'PR', nome: 'Paraná' },
    { uf: 'PE', nome: 'Pernambuco' },
    { uf: 'PI', nome: 'Piauí' },
    { uf: 'RJ', nome: 'Rio de Janeiro' },
    { uf: 'RN', nome: 'Rio Grande do Norte' },
    { uf: 'RS', nome: 'Rio Grande do Sul' },
    { uf: 'RO', nome: 'Rondônia' },
    { uf: 'RR', nome: 'Roraima' },
    { uf: 'SC', nome: 'Santa Catarina' },
    { uf: 'SP', nome: 'São Paulo' },
    { uf: 'SE', nome: 'Sergipe' },
    { uf: 'TO', nome: 'Tocantins' }
];

