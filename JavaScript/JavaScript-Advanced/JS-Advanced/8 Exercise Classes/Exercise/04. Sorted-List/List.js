class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(num) {
        this.list.push(num);
        this.size++;
        this.sort();
    }

    remove(index) {
        this.checkIndex(index);
        this.list.splice(index, 1);
        this.size--;
    }

    get(index) {
        this.checkIndex(index);
        return this.list[index];
    }

    sort() {
        this.list.sort((a, b) => a - b);
    }

    checkIndex(index) {
        if (this.list[index] === undefined) {
            throw new Error('Invalid index')
        }
    }
}