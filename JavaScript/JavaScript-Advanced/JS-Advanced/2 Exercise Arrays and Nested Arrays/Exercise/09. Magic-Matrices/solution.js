function magicMatrices(arr) {
    let sum = arr[0].reduce((a, b) => a + b);
    let rowSum = 0;
    let colSum = 0;
    for (let col = 0; col < arr[0].length; col++) {
        for (let row = 0; row < arr.length; row++) {
            rowSum = arr[row].reduce((a, b) => a + b);
            if (rowSum != sum) {
                console.log(false);
                return
            }
            rowSum = 0;
            colSum += arr[col][row];
        }
        if (colSum != sum) {
            console.log(false);
            return
        }
        colSum = 0;
    }
    console.log(true);
}
