$(document).ready(function () {
    //$("#UserName").autocomplete({
    //    minLength: 1,
    //    source: function (request, response) {
    //        var url = $(this.element).data("url");
    //        $.getJSON(url,
    //                { term: request.term },
    //                function (data) {
    //                    response(data);
    //                });
    //    },
    //appendTo: $("#UserName"),
    //select: function (event, ui) {
    //    $("#UserName").val(ui.item.username);
    //}

    $("#UserName").autocomplete({
        source: function(request, response){
            var url=$(this.element).data("url");
            $.getJSON(url, {term: request.term}, function(data){
                response(data);
            });
        },
        change: function (event, ui) {
            if (!ui.item) {
                $(event.target).val("");
            }
        }

        //appendTo: $("#whatever"),
        //select: function (event, ui) {

        //}
    });
    return false;
});

