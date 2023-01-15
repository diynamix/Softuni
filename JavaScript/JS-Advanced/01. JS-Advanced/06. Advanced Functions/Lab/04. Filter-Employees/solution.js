function filterEmployees(employees, criteria) {
    employees = JSON.parse(employees);

    if (criteria !== 'all') {
        let [key, value] = criteria.split('-');
        employees = employees.filter(x => x[key] === value);
    }

    let counter = 0;
    for (let employee of employees) {
        console.log(`${counter++}. ${employee['first_name']} ${employ - ee['last_name']} - ${employee.email}`);
    }
}

// function solve(data, criteria) {
//     let [prefix, value] = criteria.split('-');
//     let counter = 0;

//     JSON.parse(data).forEach(person => selectByCriteria.call(person));

//     function selectByCriteria() {
//         if (this[prefix] === value || criteria === 'all') {
//             return console.log(`${counter++}. ${this.first_name} ${this.last_name} - ${this.email}`);
//         }
//     }
// }
