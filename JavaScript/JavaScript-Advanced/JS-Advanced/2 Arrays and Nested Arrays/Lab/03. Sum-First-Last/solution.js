function sumFirstLast(arr) {
    let first = arr.shift();
    let last = arr.pop();
    console.log(Number(first) + Number(last));
}
