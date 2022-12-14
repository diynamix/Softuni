function jansNotation(input) {
    let operands = {
        '+': (num1, num2) => num1 + num2,
        '-': (num1, num2) => num1 - num2,
        '*': (num1, num2) => num1 * num2,
        '/': (num1, num2) => num1 / num2,
    }

    let nums = [];

    for (let el of input) {
        if (typeof el == 'number') {
            nums.push(el);
        } else if (nums.length >= 2) {
            nums[nums.length - 2] = operands[el](nums[nums.length - 2], nums.pop());
        } else {
            console.log("Error: not enough operands!");
            return;
        }
    }

    if (nums.length > 1) {
        console.log("Error: too many operands!");
        return;
    }

    console.log(nums[0]);
}
