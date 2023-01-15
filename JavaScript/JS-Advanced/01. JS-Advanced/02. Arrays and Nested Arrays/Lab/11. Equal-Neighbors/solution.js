function equalNeighbors(input) {
    let counter = 0;
    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[0].length; col++) {
            if ((row < input.length - 1)
                && (input[row][col] == input[row + 1][col])) {
                counter++;
            }
            if ((col < input[0].length - 1)
                && (input[row][col] == input[row][col + 1])) {
                counter++;
            }
        }
    }
    return counter;
}
