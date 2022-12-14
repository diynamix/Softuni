function smallestTwoNumbers(arr) {
    if (arr.length <= 1) {
        console.log(arr.join(' '));
        return;
    }
    let min = Math.min(...arr);
    let smallest = [min];
    arr = arr.filter(x => x > min);
    if (arr.length > 0) {
        min = Math.min(...arr);
    }
    smallest.push(min);
    console.log(smallest.join(" "));
}
