// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#btGames").click(function () {
        $.ajax({
            method: "GET",
            //url: "https://localhost:5001/GameAwards/",
            url: "https://l3-processoseletivo.azurewebsites.net/api/Competidores?copa=games",
        }).done(function (resp) {
            let template = `                
                <div class="card col-sm-4">
                    <div class="card-body">
                        Selecionar: <input class="opcoes" type="checkbox" data-titulo="{dtitulo}" data-url="{durl}" data-nota="{dnota}" data-ano="{dano}" /><br />
                        Nome: <span >{nome}</span><br />
                        Nota: <span >{nota}</span><br />
                        Ano: <span >{ano}</span><br />
                        <img src="{img}" style="width:100px; height:auto" />
                    </div>
                </div>`;

            let result = JSON.parse(resp);
            for (i = 0; i < result.length; i++) {
                var elem = template
                    .replace("{nome}", result[i].titulo)
                    .replace("{ano}", result[i].ano)
                    .replace("{nota}", result[i].nota)
                    .replace("{img}", result[i].urlImagem)

                    .replace("{dtitulo}", result[i].titulo)
                    .replace("{durl}", result[i].urlImagem)
                    .replace("{dnota}", result[i].nota)
                    .replace("{dano}", result[i].ano)
                $("#corpo").append($(elem));
            }
        });
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
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        });
    });
});