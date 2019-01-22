document.addEventListener("DOMContentLoaded", main);

function main(ev) {

    const navBar = document.getElementById('side-nav');
    const navControl = document.getElementById('nav-control');
    const mainContent = document.getElementById('main');

    let navbarOpen = false;

    navControl.addEventListener("click", (ev) => {
        ev.preventDefault();
        const navBarWidth = navBar.clientWidth;
        navBar.classList.toggle('active-nav');
        navbarOpen = !navbarOpen;
        mainContent.style.marginLeft = "0px";
        if (navbarOpen) {
            navControl.textContent = '<';
            mainContent.style.marginLeft = navBarWidth + 'px';
        } else {
            navControl.textContent = '>';
        }
    });

}