// window.addEventListener("DOMContentLoaded", () => {
//     const options = document.querySelectorAll("option");
//     makeItemsVisible(options);
//     makeItemsUnvisible(options);
//     console.log("WOWOW");
// });


document.onload = () => {
    const datalist = document.querySelector("datalist");
    const options = datalist.querySelectorAll("option");;
    makeItemsUnvisible(options)
    makeItemsVisible(options, 5)
}

document.addEventListener("click", function (event) {
    const datalist = document.querySelector("datalist");
    const options = datalist.querySelectorAll("option");
    const searchBox = document.querySelector(".d1");
    console.log("options.length", options.length);
    //console.log(options);
    //console.log(event.target);
    const isOption = findTarget(options, event.target);

    if (datalist.contains(event.target) || searchBox.contains(event.target)) {
        datalist.style.display = "block";
        // console.log("block");
    } else {
        datalist.style.display = "none";
        // console.log("none");
    }

    if (isOption) {
        datalist.style.display = "none";
    }
    resetOptions(options, 5);
});

function findTarget(options, target) {
    for (let index = 0; index < options.length; index++) {
        if (options[index] == target) {
            return true;
        };
    }
    return false
}

document.querySelector("#search").addEventListener("input", () => {
    console.log("input");
    const datalist = document.querySelector("datalist");
    const options = datalist.querySelectorAll("option");

    console.log("options.length" + options.length);

    resetOptions(options, 5);
});

function getBlockDisplayOptions(options) {
    console.log(options);
    const blockOptions = [];
    options.forEach((op) => {
        if (op.style.display === "block") {
            blockOptions.push(op)
        }
    });
    console.log("blockOptions.length" + blockOptions.length);
    return blockOptions;
}

function changeVisibility(item, іsVisible) {
    item.classList.remove("option-visible");
    item.classList.remove("option-unvisible");

    if (іsVisible) {
        item.classList.add("option-visible");
    } else {
        item.classList.add("option-unvisible");
    }
}

function resetOptions(options, quantity) {
    const blockOptins = getBlockDisplayOptions(options);

    makeItemsUnvisible(options)
    makeItemsVisible(blockOptins, quantity)
}

function makeItemsUnvisible(items) {

    items.forEach(i => {
        changeVisibility(i, false);
    });
}

function makeItemsVisible(items, quantity) {
    let index = 0;
    items.forEach((i) => {
        if (index < quantity) {
            changeVisibility(i, true);
            index++;
        }
    });
}