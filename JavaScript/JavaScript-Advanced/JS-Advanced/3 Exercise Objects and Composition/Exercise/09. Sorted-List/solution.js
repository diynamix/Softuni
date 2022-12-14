function createSortedList() {
    return {
        obj: [],
        size: 0,
        add: function (num) {
            this.size++;
            this.obj.push(num);
            this.obj.sort((a, b) => a - b);
        },
        remove: function (i) {
            if (i >= 0 && i < this.obj.length) {
                this.size--;
                this.obj.splice(i, 1);
            } else {
                throw new Error('Index otside boundary');
            }
        },
        get: function (i) { return this.obj[i]; },
    };
}
