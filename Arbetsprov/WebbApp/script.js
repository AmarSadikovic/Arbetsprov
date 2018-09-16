$("#btnSearch").on("click", function () {
    var title = $('#inputSearch').val()
    getBook(title);
});

function getBook(title) {
    $(".search-result").not(':first').remove();
    $.ajax({
        type: "GET",
        url: "http://localhost:51555/api/books/" + "" + title,
        dataType: "JSON"
    }).done(function (data) {
        if ($.trim(data)) {
            for (book in data) {
                var cloned = $(".search-result:first").clone();
                cloned.appendTo(".search").find('h3').text(data[book].book.title);
                cloned.appendTo(".search").find('.author').text("Author: " + data[book].book.author);
                cloned.appendTo(".search").find('.genre').text("Genre: " + data[book].book.genre);
                cloned.appendTo(".search").find('.price').text("€" + data[book].book.price);
                cloned.appendTo(".search").find('.publish_date').text("Publish Date: " + data[book].book.publish_date);
                cloned.appendTo(".search").find('.description').text("Description: " + data[book].book.description);
            }

        } else {
            var cloned = $(".search-result:first").clone();
            cloned.appendTo(".search").find('h3').text("No such book found");
            cloned.appendTo(".search").find('p').text("");
            console.log("No such book");
        }
        if ($(".search-result").length > 1) {
            $(".search-result:first").remove();
        }
        $(".search").show();
    }).fail(function (data) {
        console.log("error" + data);
    });
}

