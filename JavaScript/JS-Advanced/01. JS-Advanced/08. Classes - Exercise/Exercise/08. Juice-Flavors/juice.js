function creatingBottles(input) {
    let juice = {};
    let bottles = {};

    for (let line of input) {
        let [flavour, quantity] = line.split(' => ');
        quantity = Number(quantity);

        if (!juice.hasOwnProperty(flavour)) {
            juice[flavour] = 0;
        }
        juice[flavour] += quantity;

        if (juice[flavour] >= 1000) {
            if (!bottles.hasOwnProperty(flavour)) {
                bottles[flavour] = 0;
            }

            bottles[flavour] += Math.floor(juice[flavour] / 1000);
            juice[flavour] %= 1000;
        }
    }

    for (let [juice, quantity] of Object.entries(bottles)) {
        console.log(`${juice} => ${quantity}`);
    }
}