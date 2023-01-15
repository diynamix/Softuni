function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector("#inputs > textarea").value);

      let restaurants = {};

      for (let line of input) {
         let [restaurant, workers] = line.split(" - ");
         if (!restaurants[restaurant]) {
            restaurants[restaurant] = {};
         }
         workers = workers.split(", ").forEach(x => {
            let [name, salary] = x.split(" ");
            restaurants[restaurant][name] = Number(salary);
         });
      }

      let bestRest = Object.entries(restaurants).sort((a, b) => avg(b) - avg(a))[0];
      let bestAvg = avg(bestRest);
      let bestSalary = Object.values(bestRest[1]).sort((a, b) => b - a)[0];

      let bestOutput = `Name: ${bestRest[0]} Average Salary: ${bestAvg.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;
      document.querySelector("#bestRestaurant > p").textContent = bestOutput;

      let sorted = Object.entries(bestRest[1]).sort(([, a], [, b]) => b - a);
      let workers = [];
      for (let [name, salary] of sorted) {
         workers.push(`Name: ${name} With Salary: ${salary}`);
      }

      document.querySelector("#workers > p").textContent = workers.join(" ");

      function avg(x) {
         let salaries = Object.values(x[1]);
         return salaries.reduce((a, b) => a + b) / salaries.length;
      }
   }
}