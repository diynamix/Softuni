function getFibonator() {
    let fibonacci = [0];

    return function () {
        let currentNumber = 1;

        if (fibonacci.length > 1) {
            currentNumber = fibonacci.slice(-2).reduce((a, b) => a + b);
        }

        fibonacci.push(currentNumber);

        return (currentNumber);
    }
}


// from the lesson
// function getFibonator() {
//     return (function () {
//         const temp = this.curr + this.next;
//         this.curr = this.next;
//         this.next = temp;

//         return this.curr;
//     }).bind({
//         curr: 0,
//         next: 1
//     });
// }