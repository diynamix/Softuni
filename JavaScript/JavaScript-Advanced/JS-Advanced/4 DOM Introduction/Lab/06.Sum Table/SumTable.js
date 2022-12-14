function sumTable() {
    let tableRows = document.querySelectorAll('table tr');

    let sum = 0;
    for (let i = 1; i < tableRows.length - 1; i++) {
        let columns = tableRows[i].children;
        sum += Number(columns[1].textContent);
    }

    document.getElementById('sum').innerText = sum;
}