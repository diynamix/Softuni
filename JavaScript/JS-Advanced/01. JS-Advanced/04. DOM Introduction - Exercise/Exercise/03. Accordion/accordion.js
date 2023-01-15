function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let moreInfo = document.getElementById("extra");

    if (button.textContent == "More") {
        button.innerHTML = "Less";
        moreInfo.style.display = "block";
    } else if (button.textContent == "Less") {
        button.innerHTML = "More";
        moreInfo.style.display = "none";
    }
}