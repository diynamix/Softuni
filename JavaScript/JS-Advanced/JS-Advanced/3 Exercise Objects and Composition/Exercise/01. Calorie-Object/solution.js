function calorieObject(input) {
    let calories = input.reduce((cal, curr, i) => {
        if (i % 2 == 0) {
            cal[curr] = Number(input[i + 1]);
        }
        return cal;
    }, {});
    console.log(calories);
}
