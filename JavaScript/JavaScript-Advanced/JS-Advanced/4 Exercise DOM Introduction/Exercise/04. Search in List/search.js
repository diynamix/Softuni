function search() {
   let cities = document.querySelectorAll('ul li');
   let searched = document.getElementById('searchText').value;
   let counter = 0;
   for (let city of cities) {
      if (searched != "" && city.innerHTML.includes(searched)) {
         city.style.textDecoration = "underline";
         city.style.fontWeight = "bold";
         counter++;
      } else {
         city.style.textDecoration = "none";
         city.style.fontWeight = "normal";
      }
   }
   if (searched != "")
      document.getElementById("result").innerHTML = `${counter} matches found`;
   else {
      document.getElementById("result").innerHTML = "";
   }
}