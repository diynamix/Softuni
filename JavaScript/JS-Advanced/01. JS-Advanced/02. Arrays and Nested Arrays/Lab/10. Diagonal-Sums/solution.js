function diagonalSums(input) {
    let firstIndex = 0;
    let secondIndex = input[0].length - 1;

    let firstSum = 0;
    let secondSum = 0;

    for (let row = 0; row < input.length; row++) {
        firstSum += input[row][firstIndex];
        secondSum += input[row][secondIndex];

        firstIndex++;
        secondIndex--;
    }

    console.log(`${firstSum} ${secondSum}`);
}
