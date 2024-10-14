const inputs = document.querySelectorAll(".image-input");
inputs.forEach((x) => {
    x.addEventListener("change", (event) => {
        const reader = new FileReader();
        reader.readAsDataURL(event.target.files[0]);
        reader.addEventListener("load", () => {
            x.nextElementSibling.src = reader.result;
        });
    });
});

document.querySelectorAll(".delete-btns").forEach(x => {
    x.addEventListener("click", function () {
         document.querySelector(".delete-btn").href = `/Admin/DeleteBook/${x.getAttribute("bId")}`
    })
})

document.querySelectorAll(".edit-btns").forEach(x => {
    x.addEventListener("click", function () {
        updname.value = x.parentElement.parentElement.children[1].innerText
        updprice.value = x.parentElement.parentElement.children[2].firstElementChild.innerText
        document.querySelector(".upd-image").src = x.parentElement.parentElement.children[3].children[0].getAttribute("data-book-url");
        let selectedGenreId = x.getAttribute("gId");
        let selectedAuthorId = x.getAttribute("aId");
        document.querySelectorAll("#genreSelect option,#authorSelect option").forEach(s => {
            if (selectedGenreId) {
                document.querySelector(`#genreSelect option[value='${selectedGenreId}']`).selected = true;
            }
            if (selectedAuthorId) {
                document.querySelector(`#authorSelect option[value='${selectedAuthorId}']`).selected = true;
            }
        })
        document.querySelector("#updateModal form").action = `/Admin/UpdateBook/${x.getAttribute("bId")}`
    })
})

document.querySelectorAll(".img-btns").forEach(x => {
    x.addEventListener("click", function () {
        document.querySelector(".modal-img").src = x.getAttribute("data-book-url");
    })
})
