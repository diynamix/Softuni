function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
        toString() {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
        toString() {
            const info = super.toString().slice(0, -1);
            return `${info}, subject: ${this.subject})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }
        toString() {
            const info = super.toString();
            return `${info.substring(0, info.length - 1)}, course: ${this.course})`;
        }
    }

    return { Person, Teacher, Student };
}

// let p = new Person('Monkey', 'mm@abv.bg');
// console.log(p.toString());
// let t = new Teacher('Niki', 'nn@abv.bg', 'JS');
// console.log(t.toString());
// let s = new Student('Redi', 'rk@abv.bg', 'PHP');
// console.log(s.toString());