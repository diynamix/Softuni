function sum(array, startIndex, endIndex) {
    if (!Array.isArray(array)) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex >= array.length - 1) {
        endIndex = array.length - 1;
    }

    let result = 0;

    for (let i = startIndex; i <= endIndex; i++) {
        if (typeof array[i] !== 'number') {
            return NaN
        }
        result += array[i];
    }

    return result;
}