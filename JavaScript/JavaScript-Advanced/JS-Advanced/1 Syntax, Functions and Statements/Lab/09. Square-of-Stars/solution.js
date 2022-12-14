function drawSquare(num) {
    let square = [];
    if (num == undefined) {
        for (let i = 0; i < 5; i++) {
            square.push('* '.repeat(5));
        }
    } else {
        for (let i = 0; i < num; i++) {
            console.log('* '.repeat(num));
        }
    }
    square.map(x => console.log(x));
}
