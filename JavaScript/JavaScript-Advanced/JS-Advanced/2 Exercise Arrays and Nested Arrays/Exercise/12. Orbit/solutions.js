function orbit(arr) {
    let width = arr[0];
    let height = arr[1];
    let row = arr[2];
    let col = arr[3];

    let canopy = [];
    for (let i = 0; i < height; i++) {
        canopy.push([]);
        for (let j = 0; j < width; j++) {
            canopy[i][j] = Math.max(Math.abs(i - row), Math.abs(j - col)) + 1;
        }
    }
    console.log(canopy.map(x => x.join(' ')).join('\n'));
}
