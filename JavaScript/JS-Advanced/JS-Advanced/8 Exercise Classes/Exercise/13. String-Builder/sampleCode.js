const { StringBuilder } = require('./string-builder.js');

let str = new StringBuilder('hello');
str.append(', there');
str.prepend('User, ');
str.insertAt('woop', 5);
console.log(str.toString());
str.remove(6, 3);
console.log(str.toString());