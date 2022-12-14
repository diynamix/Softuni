function biggerHalf(input) {
    let result = input.sort((a, b) => a - b).slice(input.length / 2);
    return result;
}
