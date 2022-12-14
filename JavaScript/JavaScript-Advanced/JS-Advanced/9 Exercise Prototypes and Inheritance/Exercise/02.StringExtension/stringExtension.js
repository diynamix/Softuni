(function stringExtension() {
    String.prototype.ensureStart = function (str) {
        return this.startsWith(str) ? this.toString() : str + this.toString();
    }

    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? this.toString() : this.toString() + str;
    }

    String.prototype.isEmpty = function () {
        return this.length == 0;
    }

    String.prototype.truncate = function (n) {
        if (n < 4) {
            return '.'.repeat(n);
        }
        if (this.length <= n) {
            return this.toString();
        }

        let lastIndex = this.toString().substring(0, n - 2).lastIndexOf(" ");
        if (lastIndex != -1) {
            return this.toString().substring(0, lastIndex) + "...";
        } else {
            return this.toString().substring(0, n - 3) + "...";
        }
    }

    String.format = function (string, ...params) {
        for (let match of string.match(/{[0-9]+}/g)) {
            if (params.length > 0) {
                string = string.replace(match.toString(), params.shift());
            }
        }
        return string;
    }
})();

// Sample input
// let str = 'my string';
// str = str.ensureStart('my');      // 'my string'       // 'my' already present
// console.log(str);
// str = str.ensureStart('hello ');  // 'hello my string'
// console.log(str);
// str = str.truncate(16);           // 'hello my string' // length is 15
// console.log(str);
// str = str.truncate(14);           // 'hello my...'     // length is 11
// console.log(str);
// str = str.truncate(8);            // 'hello...'
// console.log(str);
// str = str.truncate(4);            // 'h...'
// console.log(str);
// str = str.truncate(2);            // '..'
// console.log(str);
// str = String.format('The {0} {1} fox', 'quick', 'brown');
// // 'The quick brown fox'
// console.log(str);
// str = String.format('jumps {0} {1}', 'dog');
// // 'jumps dog {1}'   // no parameter at 1
// console.log(str);