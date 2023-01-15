class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = Number(innerLength);
    }

    increase(num) {
        this.innerLength += Number(num);
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    decrease(num) {
        this.innerLength -= Number(num);
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let print = this.innerString.slice(0, this.innerLength);
        return (print !== this.innerString) ? `${print}...` : print;
    }
}