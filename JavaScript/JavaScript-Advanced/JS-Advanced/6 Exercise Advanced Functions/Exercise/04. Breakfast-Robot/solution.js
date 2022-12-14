function solution() {
    let recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    }

    let products = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    };

    return function (order) {
        let [cmd, element, quantity] = order.split(' ');
        if (quantity) quantity = Number(quantity);

        if (cmd == 'restock') {
            products[element] += quantity;
            return 'Success';
        } else if (cmd == 'prepare') {
            let neededProducts = Object.entries(recipes[element])
                .map(x => { x[1] *= quantity; return x; });
            for (let [p, q] of neededProducts) {
                if (products[p] < q) {
                    return `Error: not enough ${p} in stock`;
                } else {
                    products[p] -= q;
                }
            }
            return 'Success';
        } else if (cmd == 'report') {
            return `protein=${products.protein} carbohydrate=${products.carbohydrate} fat=${products.fat} flavour=${products.flavour}`;
        }
    }
}