function cars(input) {
    let cars = {}

    let commands = {
        create: (name, inherits, parentName) =>
            (cars[name] = inherits ? Object.create(cars[parentName]) : {}),
        set: (name, key, value) => (cars[name][key] = value),
        print: name => {
            const entry = []
            for (const key in cars[name]) {
                entry.push(`${key}:${cars[name][key]}`)
            }
            console.log(entry.join(','))
        },
    }

    input.forEach(line => {
        let [cmd, name, key, value] = line.split(' ');
        commands[cmd](name, key, value);
    })
}
