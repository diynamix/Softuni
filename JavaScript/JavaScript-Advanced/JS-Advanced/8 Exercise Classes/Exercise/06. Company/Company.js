class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        this.checkInfo(name, salary, position, department);

        if (this.departments.hasOwnProperty(department) === false) {
            this.departments[department] = {};
        }

        this.departments[department][name] = {
            salary: Number(salary),
            position,
        };

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let best = Object.entries(this.departments)
            .sort((a, b) => this.avgSalary(b) - this.avgSalary(a))[0];

        let output = `Best Department is: ${best[0]}`;
        output += `\nAverage salary: ${this.avgSalary(best).toFixed(2)}`;

        let employees = Object.entries(best[1])
            .sort((a, b) => b[1].salary - a[1].salary || a[0].localeCompare(b[0]));

        for (let employee of employees) {
            output += `\n${employee[0]} ${employee[1].salary} ${employee[1].position}`;
        }
        return output;
    }

    checkInfo(name, salary, position, department) {
        if (!name || !Number(salary) || !position || !department) {
            throw new Error('Invalid input!');
        }
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
    }

    avgSalary(department) {
        let salaries = Object.values(department[1]).map(person => person.salary);
        return salaries.reduce((a, b) => a + b) / salaries.length;
    }
}