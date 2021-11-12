const groupsBlock = document.querySelector(".home__catalog");
const groupsElements = document.querySelectorAll(".home__catalog_box");

groupsElements.forEach(e => e.addEventListener("click", selectGroup));


const categoriesBlock = document.querySelector(".home__catalog2");
const categoriesElements = document.querySelectorAll(".home__subcategory");
const list = document.querySelectorAll(".home_catalog2_menu");

categoriesElements.forEach(e => e.addEventListener("click", changeSelectedGroup));


function selectGroup() {
    groupsBlock.style.display = "none";
    categoriesBlock.style.display = "block";
    let currentIndex;
    for (let index = 0; index < groupsElements.length; index++) {
        if (this === groupsElements[index]) {
            currentIndex = index;
        }   
    }
    list[currentIndex].style.display = "block";
    categoriesElements[currentIndex].classList.add("home__subcategory-selected");
}



function changeSelectedGroup() {
    let currentIndex;
    for (let index = 0; index < categoriesElements.length; index++) {

        categoriesElements[index].classList.remove("home__subcategory-selected");
        list[index].style.display = "none";
        if (this === categoriesElements[index]) {
            currentIndex = index;
        }
    }
    list[currentIndex].style.display = "block";
    this.classList.add("home__subcategory-selected");
}

