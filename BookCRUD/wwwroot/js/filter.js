//document.querySelectorAll(".genre-list,.author-list").forEach(x => {
//    x.addEventListener("click", function () {
//        if (x.className.includes('genre-list')) {
//            document.querySelectorAll(".genre-list").forEach(y => {
//                    y.classList.remove("active")
//            })
//        } else if (x.className.includes('author-list')) {
//            document.querySelectorAll(".author-list").forEach(y => {
//                y.classList.remove("active")
//            })
//        }
//        x.classList.add("active")
//        let genreId = document.querySelector(".genre-list.active")?.getAttribute("gId");
//        let authorId = document.querySelector(".author-list.active")?.getAttribute("aId");

//        $.ajax({
//            type: "get",
//            url: "/Home/FilterBooks",
//            data: {
//                BookAuthorId: authorId,
//                BookGenreId: genrreId
//            },
//            success: function (res) {
//                console.log(res)
//            },
//            error: function (e) {
//                console.log(e)
//            }
//        })
//       // filterBooks(genreId, authorId);
//    })
//})


//function filterBooks(genreId, authorId) {
//    var bookCards = document.querySelectorAll(".book-card");
//    bookCards.forEach(card => {
//        var cardGenreId = card.getAttribute("data-genreId");
//        var cardAuthorId = card.getAttribute("data-authorId");
//        if ((genreId == "0" || cardGenreId == genreId) && (authorId == "0" || cardAuthorId == authorId)) {
//            card.style.display = "block";
//        } else {
//            card.style.display = "none";
//        }
//    });
//}