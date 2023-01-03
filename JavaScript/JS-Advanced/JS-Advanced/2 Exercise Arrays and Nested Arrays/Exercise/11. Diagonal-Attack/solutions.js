function diagonalAttack(square) {
    square = square.map(row => row.split(' ').map(Number));
    let sum1 = 0;
    let sum2 = 0;

    for (let i = 0; i < square.length; i++) {
        sum1 += square[i][i];
        sum2 += square[i][square.length - 1 - i];
    }

    if (sum1 == sum2) {
        square = square.map((row, i) => row.map((cell, j) => {
            return (j == i || j == square.length - 1 - i) ? cell : sum1
        }));
    }

    square.forEach(row => console.log(row.join(' ')));
}
