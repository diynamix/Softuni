function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = document.querySelectorAll("tbody > tr");
      let searchField = document.getElementById("searchField");

      for (let row of rows) {
         row.classList.remove("select");
         if (searchField.value.length > 0 && row.innerHTML.includes(searchField.value)) {
            row.classList.add("select");
         }
      }

      searchField.value = "";
   }
}
solve();