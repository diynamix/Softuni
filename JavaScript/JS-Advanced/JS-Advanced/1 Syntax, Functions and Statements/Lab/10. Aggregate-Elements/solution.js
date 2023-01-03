function aggregate(arr) {
    let sum = arr.reduce((a, b) => a + b, 0);
    console.log(sum);

    let inverseSum = 0;
    arr.map(num => inverseSum += 1 / num);
    console.log(inverseSum);

    let concat = arr.join('');
    console.log(concat);
}