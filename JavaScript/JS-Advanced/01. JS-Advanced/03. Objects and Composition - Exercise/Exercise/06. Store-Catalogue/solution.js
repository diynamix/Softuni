function storeCatalogue(products) {
    let catalogue = products.sort().reduce((obj, el, i) => {
        let [product, price] = el.split(' : ');
        let startLetter = product[0]
        if (!obj.hasOwnProperty(startLetter)) {
            obj[startLetter] = {};
        }
        obj[startLetter][product] = Number(price);
        return obj;
    }, {});

    for (let [letter, info] of Object.entries(catalogue)) {
        console.log(letter);
        for (let [product, price] of Object.entries(info)) {
            console.log(`  ${product}: ${price}`);
        }
    }
}
