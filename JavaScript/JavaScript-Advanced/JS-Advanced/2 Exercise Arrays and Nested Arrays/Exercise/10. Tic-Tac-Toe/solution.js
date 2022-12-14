function ticTacToe(moves) {
    let board = [[], [], []];
    board.map(row => { row.length = 3; row.fill(false) });

    let counter = 0;
    let won = false;
    let mark;

    while (moves.length > 0) {
        let move = moves.shift().split(" ").map(Number);

        if (board[move[0]][move[1]] != false) {
            console.log("This place is already taken. Please choose anoth-er!");
            counter--;
        } else {
            board[move[0]][move[1]] = counter % 2 == 0 ? 'X' : 'O';
        }
        counter++;

        let diagolal1 = [board[0][0], board[1][1], board[2][2]];
        if (diagolal1.every(mark => mark == diagolal1[0] && mark != false)) {
            mark = diagolal1[0];
            won = true;
            break;
        }

        let diagonal2 = [board[0][2], board[1][1], board[2][0]];
        if (diagonal2.every(mark => mark == diagonal2[0] && mark != false)) {
            mark = diagonal2[0];
            won = true;
            break;
        }

        for (let row = 0; row < 3; row++) {
            if (board[row].every(mark => mark == board[row][0] && mark != false)) {
                mark = board[row][0];
                won = true;
                break;
            }
            let column = [];
            for (let col = 0; col < 3; col++) {
                column.push(board[col][row]);
            }
            if (column.every(mark => mark == column[0] && mark != false)) {
                mark = column[0];
                won = true;
                break;
            }
        }
        if (won) break;
        if (board.every(row => row.every(col => col != false))) break;
    }

    if (won) {
        console.log(`Player ${mark} wins!`);
    } else {
        console.log("The game ended! Nobody wins :(");
    }
    board.map(x => console.log(x.join("\t")))
}
