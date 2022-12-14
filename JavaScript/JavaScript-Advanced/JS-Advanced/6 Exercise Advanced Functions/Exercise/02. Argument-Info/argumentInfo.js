function argumentInfo(...input) {
    let result = input.reduce((a, b) => {
        let type = typeof b;
        console.log(`${type}: ${b}`);
        if (!a.hasOwnProperty(type)) {
            a[type] = 0;
        }
        a[type]++;
        return a;
    }, {});
    console.log(Object.entries(result).map(pair => pair.join(' = ')).join('\n'));
}