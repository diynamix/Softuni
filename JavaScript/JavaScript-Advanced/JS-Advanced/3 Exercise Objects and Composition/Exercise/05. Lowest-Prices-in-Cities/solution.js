function lowestPricesInCities(arr) {
    let res = {};

    for (let el of arr) {
        let [town, product, price] = el.split(' | ');
        price = Number(price);

        if (!res.hasOwnProperty(product)) {
            res[product] = [price, town];
        } else if (res[product][0] > price) {
            res[product] = [price, town];
        }
    }

    for (let [product, value] of Object.entries(res)) {
        let [price, town] = value;
        console.log(`${product} -> ${price} (${town})`);
    }
}
