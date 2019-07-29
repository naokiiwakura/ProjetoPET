let map;
let service;
let infowindow;

function initAutocomplete() {
    map = new google.maps.Map(document.getElementById('map_canvas'), {
        center: { lat: -20.44278, lng: - 54.64639 },
        zoom: 15,
        mapTypeId: 'roadmap'
    });

    infowindow = new google.maps.InfoWindow();
}

function pinar(elemento) {
    var request = {
        query: elemento,
        fields: ['name', 'geometry'],
    };

    service = new google.maps.places.PlacesService(map);

    service.findPlaceFromQuery(request, function (results, status) {
        if (status === google.maps.places.PlacesServiceStatus.OK) {
            for (var i = 0; i < results.length; i++) {
                createMarker(results[i]);
            }
            map.setCenter(results[0].geometry.location);
        }
    });



    $("#ExemploModalCentralizado").modal();
    $('.modal-backdrop').removeClass("modal-backdrop");
}

function createMarker(place) {
    var marker = new google.maps.Marker({
        map: map,
        position: place.geometry.location,


    });

    google.maps.event.addListener(marker, 'click', function () {
        infowindow.setContent(place.name);
        infowindow.open(map, this);
    });
}

$(document).ready(function () {
    $('.custom-file-input').on("change", function () {
        var filename = $(this).val().split("\\").pop();
        $(this).next('.custom-file-label').html(filename)
    });
});
$(document).ready(function () {
    $('.data').mask('00/00/0000');
    $('.tempo').mask('00:00:00');
    $('.data_tempo').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000');
    $('.tel').mask('00000-0000');
    $('.ddd_tel').mask('(00) 0000-0000');
    $('.cpf').mask('000.000.000-00');
    $('.cnpj').mask('00.000.000/0000-00');
    $('.dinheiro').mask('000.000.000.000.000,00', { reverse: true });
    $('.dinheiro2').mask("#.##0,00", { reverse: true });
});

$("#EstadoId").on("change", function () {
    $list = $("#CidadeId");
    $.ajax({
        url: "GetCidades/" + $("#EstadoId").val(),
        type: "GET",
        success: function (result) {

            $list.empty();
            result.forEach((item) => {
                $list.append('<option value="' + item.id + '"> ' + item.nome + ' </option>');
            });
        },
        error: function () {
            alert("Erro ocorreu no processamento");
        }
    });

});

function Checkfiles() {
    var fup = document.getElementById('filename');
    var fileName = fup.value;
    var ext = fileName.substring(fileName.lastIndexOf('.') + 1);

    if (ext == "jpeg" || ext == "png") {
        return true;
    }
    else {
        return false;
    }
}