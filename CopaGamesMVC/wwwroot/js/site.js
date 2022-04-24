// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

bootstrap_alert = function () { }
bootstrap_alert.warning = function (message) {
    $('#alert_placeholder').html('<div class="alert alert-warning"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')
}

$(function () {
    $.ajax({
        method: "GET",
        //url: "https://localhost:5001/GameAwards/",
        url: "https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games",
    }).done(function (resp) {
        const item = ({ titulo, nota, ano, urlImagem }) => `
                        <div class="card col-sm-4">
                            <div class="card-body">
                                Selecionar: <input class="opcoes" type="checkbox" data-titulo="${titulo}" data-url="${urlImagem}" data-nota="${nota}" data-ano="${ano}" /><br />
                                Nome: <span>${titulo}</span><br />
                                Nota: <span>${nota}</span><br />
                                Ano: <span>${ano}</span><br />
                                <img src="${urlImagem}" style="width:100px; height:auto" />
                            </div>
                        </div>`;
        const games = JSON.parse(resp);
        const listao = games.map(item).join('');
        $("#corpo").append($(listao));

    });


    $("#btEnviar").click(function () {

        let dados = [];

        $(".opcoes:checked").each(function (idx, elm) {
            dados.push({
                titulo: $(elm).data("titulo"),
                urlImagem: $(elm).data("url"),
                nota: $(elm).data("nota"),
                ano: $(elm).data("ano"),
            });
        });

        console.log(dados);

        $.ajax({
            method: "POST",
            url: "https://localhost:44306/GameAwards/",
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(dados),

        }).done(function (resp) {
            $("#campeaoNome").text(resp.campeao.titulo);
            $("#viceNome").text(resp.vice.titulo);
            $("#terceiroNome").text(resp.terceiroLugar.titulo);
            $("#quartoNome").text(resp.quartoLugar.titulo);

            $("#participantes").hide();
            $("#result").show();
        }).fail(function (jqXHR, textStatus, errorThrown) {
            bootstrap_alert.warning(jqXHR.responseText);

            $("#participantes").show();
            $("#result").hide();
        });
    });
});