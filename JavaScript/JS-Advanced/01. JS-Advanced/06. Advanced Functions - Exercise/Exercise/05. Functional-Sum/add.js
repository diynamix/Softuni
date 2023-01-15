function add(n) {
    const inner = function (a) {
        n += a;
        return inner;
    }
    //inner.valueOf = function () {
    inner.toString = function () {
        return n;
    };

    return inner;
}

//from the web
// let sum = a => b => b ? sum(a + b) : a;
// console.log(sum(10)(20)(3)(4)());