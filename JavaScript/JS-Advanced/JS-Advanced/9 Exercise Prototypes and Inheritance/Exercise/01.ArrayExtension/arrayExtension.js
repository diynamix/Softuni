(function arrayExtension() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        return this.slice(n);
    }

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b);
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})();

let arr = [1, 2, 3, 4, 5, 6, 7, 8, 9];

console.log(arr.last());
console.log(arr.skip(3));
console.log(arr.take(4));
console.log(arr.sum());
console.log(arr.average());