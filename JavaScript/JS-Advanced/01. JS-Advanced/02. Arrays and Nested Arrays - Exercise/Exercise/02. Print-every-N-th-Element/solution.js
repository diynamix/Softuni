function printEveryNthElementFromAnArray(arr, step) {
    return arr.filter((x, i) => i % step == 0);
}
