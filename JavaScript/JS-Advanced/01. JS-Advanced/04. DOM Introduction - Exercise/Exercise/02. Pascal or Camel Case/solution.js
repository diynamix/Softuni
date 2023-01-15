function solve() {
  let result = document.getElementById("text").value
    .toLowerCase()
    .split(" ")
    .map(x => x.charAt(0).toUpperCase() + x.substr(1))
    .join('');

  let casing = document.getElementById("naming-convention").value;

  if (casing == "Camel Case") {
    result = result.charAt(0).toLowerCase() + result.substr(1);
  } else if (casing != "Pascal Case") {
    result = "Error!";
  }
  document.getElementById("result").innerHTML = result;
}
solve();