function spiralMatrix(width, height) {
    let number = 1;
    let matrix = [];

    for (let i = 0; i < height; i++) {
        matrix.push(new Array(width));
    }

    let rowLength = width;
    let colHeight = height - 2;
    let firtsIndex = 0;
    let lastIndex = width - 1;

    while (true) {
        if (number > width * height) break;

        //go left
        for (let l = 0; l < rowLength; l++) {
            if (number > width * height) break;
            matrix[firtsIndex][firtsIndex + l] = (number++);
        }

        //go down
        for (let d = 0; d < colHeight; d++) {
            if (number > width * height) break;
            matrix[firtsIndex + 1 + d][lastIndex] = number++;
        }

        //go right
        for (let r = 0; r < rowLength; r++) {
            if (number > width * height) break;
            matrix[lastIndex][lastIndex - r] = (number++);
        }

        //go up
        for (let d = 0; d < colHeight; d++) {
            if (number > width * height) break;
            matrix[lastIndex - 1 - d][firtsIndex] = number++;
        }

        rowLength -= 2;
        colHeight -= 2;
        firtsIndex++;
        lastIndex--;
    }
    console.log(matrix.map(row => row.join(" ")).join("\n"));
}
