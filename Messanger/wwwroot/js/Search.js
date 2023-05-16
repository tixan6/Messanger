document.querySelector(".btn-search").addEventListener("click", function () {
    let inputValue = document.querySelector(".search-friends-input").value.trim();
    let allItems = document.querySelectorAll('.block-all-off-people');
    if (inputValue != "") {
        allItems.forEach(function (elem) {
            if (elem.innerText.search(inputValue) == -1) {
                elem.classList.add('hide');
            }
            else {
                elem.classList.remove('hide');
            }

        });
    }
    else
    {
        allItems.forEach(function (elem) {
            elem.classList.remove('hide');
        });
    }

})
