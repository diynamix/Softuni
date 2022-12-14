function attachGradientEvents() {
    let gradient = document.getElementById("gradient");

    gradient.addEventListener("mousemove", function (event) {
        let position = event.offsetX;
        let gradientWidth = event.target.clientWidth - 1;
        let result = Math.trunc(position / gradientWidth * 100);
        document.getElementById("result").textContent = result + "%";
    });

    gradient.addEventListener("mouseout", function () {
        document.getElementById("result").textContent = "";
    });
}