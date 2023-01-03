function validityChecker(x1, y1, x2, y2) {
    let firstToZero = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
    let isValid = firstToZero % 1 == 0 ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {0, 0} is ${isValid}`);

    let secondToZero = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    isValid = secondToZero % 1 == 0 ? 'valid' : 'invalid';
    console.log(`{${x2}, ${y2}} to {0, 0} is ${isValid}`);

    let firstToSecond = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));
    isValid = firstToSecond % 1 == 0 ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid} `);
}
