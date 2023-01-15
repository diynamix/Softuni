function encodeAndDecodeMessages() {
    let input = document.getElementsByTagName('textarea')[0];
    let encodeBtn = document.getElementsByTagName('button')[0];

    let output = document.getElementsByTagName('textarea')[1];
    let decodeBtn = document.getElementsByTagName('button')[1];

    encodeBtn.addEventListener('click', function () {
        let msg = input.value.split('')
            .map(ch => String.fromCharCode(ch.charCodeAt(0) + 1))
            .join('');
        output.value = msg;
        input.value = "";
    });

    decodeBtn.addEventListener('click', function () {
        let msg = output.value.split('')
            .map(ch => String.fromCharCode(ch.charCodeAt(0) - 1))
            .join('');
        output.value = msg;
    });
}