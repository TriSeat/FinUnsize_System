const header = document.querySelector('.header');
let isFixed = false;

window.onscroll = function () {
    let scrollY = window.scrollY || window.pageYOffset;

    if (scrollY > 50 && !isFixed) {
        header.style.position = "fixed";
        isFixed = true;
    } else if (scrollY <= 50 && isFixed) {
        header.style.position = "relative";
        isFixed = false;
    }
}