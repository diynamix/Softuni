function create(words) {
   let content = document.getElementById("content");

   for (let word of words) {
      let div = document.createElement("div");

      let p = document.createElement("p");
      p.style.display = "none";
      p.textContent = word;

      div.appendChild(p);

      div.addEventListener("click", function () {
         p.style.display = "block";
      });

      content.appendChild(div);
   }
}