

// currently active list
let listActive;
// datalist handler events
document.body.addEventListener('focusin', listShow);

// datalist control focused?
function listShow(e) {
    console.log(e);
    const input = target(e);
    if (!input) return;

    if (input.list) {
        console.log(input.list);
        // setup of datalist control
        const dl = input.list;
        console.log("dl");
        console.log(dl);
        input.datalist = dl;
        input.removeAttribute('list');

        dl.input = input;
        dl.setAttribute('tabindex', -1);

        // event handlers
        input.addEventListener('input', listLimit);
        input.addEventListener('keydown', listControl);
        dl.addEventListener('keydown', listKey);
        dl.addEventListener('click', listSet);

    }

    // show datalist
    const dl = input.datalist;
    console.log(input.datalist);
    if (dl && !dl.shown) {
        console.log(dl);
        listHide(listActive);

        dl.shown = true;
        listLimit(e);
        dl.style.width = input.offsetWidth + 'px';
        dl.style.left = input.offsetLeft + 'px';
        dl.style.display = 'block';
        listActive = dl;

    }

}


// hide datalist
function listHide(dl) {
    console.log(dl);
    if (dl && dl.shown) {
        console.log(dl.shown);
        dl.style.display = 'none';
        dl.shown = false;

    }

}


// enable valid and disable invalid options
function listLimit(e) {

    const input = target(e);
    if (!input || !input.datalist) return;

    const v = input.value.trim().toLowerCase();
    Array.from(input.datalist.getElementsByTagName('option')).forEach(opt => {
        opt.setAttribute('tabindex', 0);
        opt.style.display = !v || opt.value.toLowerCase().includes(v) ? 'block' : 'none';
    });

}


// key event on input
function listControl(e) {

    const input = target(e);
    if (!input || !input.datalist) return;
    console.log(e);
    switch (e.keyCode) {

        case 40: {
            // arrow down
            let opt = input.datalist.firstElementChild;
            if (!opt.offsetHeight) opt = visibleSibling(opt, 1);
            opt && opt.focus();
            break;
        }

        case 9:   // tab
            listHide(input.datalist);
            break;

        case 13:  // enter
        case 32:  // space
            console.log(e);
            listSet(e);
            break;

    }

}


// key event on datalist
const keymap = {
    33: -12,
    34: 12,
    38: -1,
    40: 1
};

function listKey(e) {

    const t = target(e);
    if (!t) return;

    const
        kc = e.keyCode,
        dir = keymap[kc],
        dl = t.parentElement;

    if (dir) {

        // move through list
        let opt = visibleSibling(t, dir);
        opt && opt.focus();
        e.preventDefault();

    }
    else if (kc === 9 || kc === 13 || kc === 32) {

        // tab, enter, space: use value
        listSet(e);

    }
    else if (kc === 8) {

        // backspace: return to input
        dl.input.focus();

    }
    else if (kc === 27) {

        // esc: hide list
        listHide(dl);

    }

}


// get previous/next visible sibling
function visibleSibling(opt, dir) {

    let newOpt = opt;

    do {

        if (dir < 0) {
            newOpt = newOpt.previousElementSibling;
        }
        else if (dir > 0) {
            newOpt = newOpt.nextElementSibling;
        }

        if (newOpt && newOpt.offsetHeight) {
            opt = newOpt;
            dir -= Math.sign(dir);
        }

    } while (newOpt && dir);

    return opt;

}


// set datalist option to input value
function listSet(e) {


    const t = target(e),
        dl = t && t.parentElement;

    if (!dl || !dl.input) return;

    dl.input.value = (t && t.value) || '';
    listHide(dl);

}


// fetch target node
function target(t) {
    return t && t.target;
}

window.addEventListener("DOMContentLoaded", () => {
    const datalist = document.querySelector("datalist");
    const options = datalist.querySelectorAll("option");
    makeItemsUnvisible(options);
    makeItemsVisible(options);
    console.log("WOWOW");
});

// const imgBtn = document.querySelector(".home__main3_1");
// imgBtn.addEventListener("click", () => {
//     const input = document.querySelector(".d1");
//     const datalist = document.querySelector("datalist");
//     const temp = getCssProperty(input, "width");
//     console.log(temp);
//     datalist.style.width = temp;



//     console.log("BTN");
// });

function getCssProperty(element, property) {
    return window.getComputedStyle(element, null).getPropertyValue(property);
}
window.addEventListener("resize", function (event) {
    const datalist = document.querySelector("datalist");
    const input = document.querySelector("#search")
  
    datalist.shown = false;
    datalist.shown = true;
   
    datalist.style.width = input.offsetWidth + 'px';
    datalist.style.left = input.offsetLeft + 'px';
   


});


document.addEventListener("click", function (event) {
    const datalist = document.querySelector("datalist");
    const options = datalist.querySelectorAll("option");
    const searchBox = document.querySelector(".d1");
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
    const datalist = document.querySelector("datalist");
    const options = datalist.querySelectorAll("option");

    resetOptions(options, 5);
});

function getBlockDisplayOptions(options) {
    const blockOptions = [];
    options.forEach((op) => {
        if (op.style.display === "block") {
            blockOptions.push(op)
        }
    });

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




