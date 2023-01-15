function cooking(num, op1, op2, op3, op4, op5) {
    let commands = { chop, dice, spice, bake, fillet, }

    num = Number(num);
    let operations = [op1, op2, op3, op4, op5];
    operations.forEach(op => {
        num = commands[op](num);
        console.log(num);
    })

    function chop(num) {
        return num / 2;
    }

    function dice(num) {
        return Math.sqrt(num);
    }

    function spice(num) {
        return num + 1;
    }

    function bake(num) {
        return num * 3;
    }

    function fillet(num) {
        return num * 0.8;
    }
}
