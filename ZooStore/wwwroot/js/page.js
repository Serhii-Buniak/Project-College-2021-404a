window.onload = () => {
    const pageBlocks = document.querySelectorAll(".search__page-block");
    const pages = document.querySelectorAll(".search__page");
    const length = pageBlocks.length;
    const selectPage = document.querySelector(".search__page-selected");
    selectPage.closest(".search__page-block").style.pointerEvents = "none";
    const indexOfSelectPage = getIndexOfSelectPage(selectPage, pages);
    
    pageBlocks.forEach(p => {
        p.style.display = "none"
    });

    if (indexOfSelectPage > 4) {
        pageBlocks[0].style.display = "block";
        pageBlocks[0].style.backgroundColor = "white";

        for (let i = indexOfSelectPage - 4; i < indexOfSelectPage + 3; i++) {
            try {
                pageBlocks[i].style.display = "block";
            } catch { }
        }
    } else {
        for (let i = 0; i < 7; i++) {
            pageBlocks[i].style.display = "block";
        }
    }

    if (length <= 10) {
        pageBlocks.forEach(p => {
            p.style.display = "block"
        });
    }
    else {
        for (let i = length - 2; i < length; i++) {
            pageBlocks[i].style.display = "block"
        }
    }

    if (indexOfSelectPage > (length - 5)) {

        for (let i = (length - 9); i < length; i++) {
            pageBlocks[i].style.display = "block";
        }
    }
    if ((indexOfSelectPage + 5) < length) {
        pageBlocks[length - 3].style.backgroundColor = "white";
        pageBlocks[length - 3].style.display = "block";
        pageBlocks[length - 3].innerHTML = "...";
        pageBlocks[length - 3].style.pointerEvents = "none";
    }

}


function getIndexOfSelectPage(selectPage, pages) {
    for (let i = 0; i < pages.length; i++) {
        if (selectPage == pages[i]) {
            console.log(i);
            return i;
        }
    }
    console.log("select page not found");
    return -1;
}
