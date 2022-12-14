//84/100
function solve() {
    let checkBtn = document.getElementsByTagName('button')[0];
    checkBtn.addEventListener('click', check);

    let clearBtn = document.getElementsByTagName('button')[1];
    clearBtn.addEventListener('click', clear);

    function check() {
        let tRows = document.querySelectorAll('tbody tr');
        let matrix = [];
        let solved = true;

        for (let tr of tRows) {
            let row = Array.from(tr.getElementsByTagName('input')).map(inp => Number(inp.value));
            matrix.push(row);
        }

        let sum = matrix[0].reduce((a, b) => a + b);
        for (let col = 0; col < matrix.length; col++) {
            let rowSum = matrix[col].reduce((a, b) => a + b);
            if (sum !== rowSum) {
                solved = false;
                break;
            }
            let colSum = 0;
            for (let row = 0; row < matrix.length; row++) {
                colSum += matrix[row][col];
            }
            if (sum !== colSum) {
                solved = false;
                break;
            }
        }

        let table = document.getElementsByTagName('table')[0];
        let check = document.querySelector('#check p');
        if (!solved) {
            table.style.border = '2px solid red';
            check.style.color = 'red';
            check.textContent = 'NOP! You are not done yet...';
        } else {
            table.style.border = '2px solid green';
            check.style.color = 'green';
            check.textContent = 'You solve it! Congratulations!';
        }
    }

    function clear() {
        Array.from(document.querySelectorAll('tbody input'))
            .forEach(cell => cell.value = "");

        let table = document.getElementsByTagName('table')[0];
        table.style.border = 'none';

        let check = document.querySelector('#check p');
        check.textContent = '';
    }
}


//100/100 - from the web
function solve2() {
    let inputs = document.querySelectorAll('input');
    const checkBtn = document.querySelectorAll('button')[0];
    const clear = document.querySelectorAll('button')[1];

    const table = document.querySelector('table');
    const checkPar = document.querySelectorAll('#check p')[0];

    checkBtn.style.cursor = 'pointer';
    clear.style.cursor = 'pointer';

    clear.addEventListener('click', reset);
    checkBtn.addEventListener('click', checkResult);

    function reset() {
        [...inputs].forEach(input => (input.value = ''));
        table.style.border = 'none';
        checkPar.textContent = '';
    }

    function checkResult() {
        let matrix = [
            [inputs[0].value, inputs[1].value, inputs[2].value],
            [inputs[3].value, inputs[4].value, inputs[5].value],
            [inputs[6].value, inputs[7].value, inputs[8].value]
        ];
        isSudomu = true;
        for (let i = 1; i < matrix.length; i++) {
            let row = matrix[i];
            let col = matrix.map(row => row[i]);
            if (col.length != [...new Set(col)].length || row.length != [...new Set(row)].length) {
                isSudomu = false;
                break;
            }
        }
        if (isSudomu) {
            table.style.border = '2px solid green';
            checkPar.style.color = 'green';
            checkPar.textContent = 'You solve it! Congratulations!';
        } else {
            table.style.border = '2px solid red';
            checkPar.style.color = 'red';
            checkPar.textContent = 'NOP! You are not done yet...';
        }
    }
}