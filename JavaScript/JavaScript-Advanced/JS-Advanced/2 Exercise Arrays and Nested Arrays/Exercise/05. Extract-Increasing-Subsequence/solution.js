function extractIncreasingSubsequenceFromArray(input) {
    let max = input[0];
    let result = input.reduce((arr, x) => {
        if (x >= max) {
            arr.push(x);
            max = x;
        }
        return arr;
    }, []);
    return result;
}
