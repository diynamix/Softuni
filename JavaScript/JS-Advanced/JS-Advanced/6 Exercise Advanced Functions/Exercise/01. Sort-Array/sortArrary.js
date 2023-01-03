function sortArray(arr, arg) {
    if (arg == 'asc') {
        arr = arr.sort((a, b) => a - b);
    } else if (arg == 'desc') {
        arr = arr.sort((a, b) => b - a);
    }

    return arr;
}