document.querySelector(".btn-search").addEventListener("click", function () {
    let inputValue = document.querySelector(".search-friends-input").value.trim();
    let allItems = document.querySelectorAll('.block-all-off-people');
    var count = 0;
    var countItems = 0;
    allItems.forEach(function (CountItems) {
        if (CountItems) {
            countItems++;
        }
    })
    if (inputValue != "") {
        allItems.forEach(function (elem) {       
            if (elem.innerText.search(inputValue) == -1) {
                elem.classList.add('hide');

                if (document.querySelector(".block-all-off-people").classList.contains("hide")) {
                    count++;
                    if (count == countItems) {
                        Swal.fire('Пользователь не найден');
                    }
                }
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
