function sortingNumbers(arr) {
    arr.sort((a, b) => a - b);
    let result = [];
    for (let i = 0; i < arr.length / 2; i++) {
        result.push(arr[i], arr[arr.length - i - 1])
    }
    if (arr.length % 2 != 0) {
        result.pop()
    }
    return result;
}
