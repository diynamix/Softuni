function sameNums(nums) {
    nums = nums.toString().split('').map(Number);

    //let isEqual = !!nums.reduce(function (a, b) { return (a === b) ? a : NaN; }); //83/100 Judge
    let isEqual = nums.every(x => x === nums[0]);
    console.log(isEqual);

    let sum = nums.reduce((a, b) => a + b, 0);
    console.log(sum);
}
