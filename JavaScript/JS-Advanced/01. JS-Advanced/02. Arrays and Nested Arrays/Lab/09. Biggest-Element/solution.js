function biggestElement(arr) {
    let max = Number.MIN_SAFE_INTEGER;
    arr.forEach(x => x.forEach(y => max = y > max ? y : max));
    return max;
}
