function solve() {
  let sentences = document.getElementById("input").value
    .split(".").filter(x => x).map(x => x.trim());

  let output = document.getElementById("output");

  for (let i = 0; i < sentences.length; i += 3) {
    let paragraph = [];
    for (let y = 0; y < 3; y++) {
      if (sentences[i + y]) {
        paragraph.push(sentences[i + y]);
      }
    }
    output.innerHTML += `<p>${paragraph.join(". ")}.</p>`;
  }
}