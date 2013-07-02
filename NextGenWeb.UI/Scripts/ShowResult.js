var ResultViewModel = {
    items: ko.observableArray([])
};

function ItemModel(title, url, content) {
    this.title = ko.observable(title);
    this.url = ko.observable(url);
    this.content = ko.observable(content);
}
$(document).ready(function () {

    var chat = $.connection.searchResultHub;
    $.connection.hub.qs = "provider=" + getUrlParam("provider");

    chat.client.showResult = function (result) {
        ResultViewModel.items.removeAll();
        $.each(result.Items, function (i, itm) {
            ResultViewModel.items.push(new ItemModel(itm.Title, itm.Url, itm.Content));
        });
    };

    $.connection.hub.start();
    ko.applyBindings(ResultViewModel);
});

function getUrlParam(name) {
    var pageUrl = window.location.search.substring(1);
    var urlParams = pageUrl.split('&');

    for (var i = 0; i < urlParams.length; i++) {
        var paramName = urlParams[i].split('=');

        if (paramName[0] == name) {
            return paramName[1];
        }
    }
}
