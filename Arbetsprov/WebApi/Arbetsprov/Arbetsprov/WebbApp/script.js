$("#btnSearch").on("click", function () {
    var title = $('#inputSearch').val()
    getBook(title);
});



function getBook(title) {
    $.ajax({
        url: "localhost:51555/api/books/ruby",
        dataType: "JSON"
    }).done(function (data) {
        var search = data;
        var movies = "Movie: ";
        console.log(data);
        
    }).fail(function (data) {
        console.log(data);
    });
}