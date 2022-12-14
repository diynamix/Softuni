function solution() {
    const Tasks = {
        'Junior': ['is working on a simple task.'],
        'Senior': [
            'is working on a complicated task.',
            'is taking time off work.',
            'is supervising junior workers.'
        ],
        'Manager': [
            'scheduled a meeting.',
            'is preparing a quarterly report.'
        ]
    };

    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = Tasks[this.constructor.name];
            this.count = 0;
        }

        work() {
            console.log(`${this.name} ${this.tasks[this.count++]}`);
            if (this.count == this.tasks.length) {
                this.count = 0;
            }
        }

        collectSalary() {
            let salary = this.salary + (this.dividend ? this.dividend : 0);
            console.log(`${this.name} received ${salary} this month.`)
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
        }
    }

    return { Employee, Junior, Senior, Manager };
}

// const classes = solution();
// const junior = new classes.Junior('Ivan', 25);

// junior.work();
// junior.work();

// junior.salary = 5811;
// junior.collectSalary();

// const sinior = new classes.Senior('Alex', 31);

// sinior.work();
// sinior.work();
// sinior.work();
// sinior.work();

// sinior.salary = 12050;
// sinior.collectSalary();

// const manager = new classes.Manager('Tom', 55);

// manager.salary = 15000;
// manager.collectSalary();
// manager.dividend = 2500;
// manager.collectSalary();