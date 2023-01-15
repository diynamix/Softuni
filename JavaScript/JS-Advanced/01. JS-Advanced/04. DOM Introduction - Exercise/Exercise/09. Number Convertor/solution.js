function solve() {
    document.getElementsByTagName('button')[0].addEventListener('click', onClick);

    document.getElementById('selectMenuTo').innerHTML += `<option value="binary">Binary</option><option value="hexadecimal">Hexadecimal</option>`;

    function onClick() {
        let num = Number(document.getElementById('input').value);
        let select = document.getElementById('selectMenuTo').value;
        let convertTo = select == 'binary' ? 2 : 16;
        let result = num.toString(convertTo).toUpperCase();
        let output = document.getElementById('result');
        output.value = result;
    }
}

solve();


//Additional
// convert decimal to binary
function convertToBinary(x) {
    let bin = 0;
    let rem, i = 1, step = 1;
    while (x != 0) {
        rem = x % 2; //Remainder
        step++; //Step
        x = parseInt(x / 2); //Quotient
        bin = bin + rem * i;
        i = i * 10;
    }
    return bin;
}

// convert decimal to hexadecimal
//If you need to handle things like bit fields or 32-bit colors, then you need to deal with signed numbers. The JavaScript function toString(16) will return a negative hexadecimal number which is usually not what you want. This function does some crazy addition to make it a positive number.
function decimalToHexString(number) {
    if (number < 0) {
        number = 0xFFFFFFFF + number + 1;
    }
    return number.toString(16).toUpperCase();
}