# Sabatina DotNet Core Rest API
Lives / Talks de asp.net core restful api 

## Exemplo de Processo Seletivo: CopaSeries

### Changelog
2022-04-23 - adição de hot reload
2022-04-23 - gambiarra com eval para um mecanismo de template rudimentar
2022-04-23 - template com interpolação

### Notas e links úteis
- [Tipos de retorno de uma action no asp.net core](https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0)
- [Retornando dados da web api](https://www.macoratti.net/19/06/aspnc_3dwebapi1.htm)
- [Questões sobre testar ou não controllers](https://andrewlock.net/should-you-unit-test-controllers-in-aspnetcore/)
- [Tipos de Action result no aspnet core web api](https://www.c-sharpcorner.com/article/action-result-in-asp-net-core-api/)
- [swagger](https://swagger.io/)
- [Novidades do .net 6](https://devblogs.microsoft.com/dotnet/announcing-net-6/)

> o ajax deve ter contentType: 'application/json' para não precisar fazer parse. O server tem que ter o cabeçalho "content-type": "application/json; charset=utf-8 " pra não precisar setar no ajax


### Problemas comuns de acontecer
- [CORS](https://www.c-sharpcorner.com/article/enable-cors-consume-web-api-by-mvc-in-net-core-4/)
- [Formatar o JSON com letras maiúsculas igual os objetos da aplicação](https://stackoverflow.com/questions/38202039/json-properties-now-lower-case-on-swap-from-asp-net-core-1-0-0-rc2-final-to-1-0)
- [Hot Reload](https://jonathancrozier.com/blog/why-your-asp-net-core-views-are-not-updating-at-runtime)


### Bibliotecas para template com jQuery ou vanillaJS
- [Mustache](https://mustache.github.io/) - mais usado e tem pra todas as linguagens
- [Underscore Template](http://underscorejs.org/#template) - mecanismo de template do Underscore (biblioteca js) que parece muito o formato de template do webforms
- [Handlebars](https://handlebarsjs.com/) - parece mustache, mas com lógica
- [jQuery Template](https://tableless.com.br/templates-e-jquery-parte-1/) - mecanismo de template do jquery