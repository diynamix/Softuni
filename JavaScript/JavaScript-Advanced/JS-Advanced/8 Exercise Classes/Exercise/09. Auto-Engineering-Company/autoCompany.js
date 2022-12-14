function produceCars(input) {
    let carBrands = {};

    for (let line of input) {
        let [brand, model, producedCars] = line.split(' | ');

        if (!carBrands.hasOwnProperty(brand)) {
            carBrands[brand] = {};
        }

        if (!carBrands[brand].hasOwnProperty(model)) {
            carBrands[brand][model] = 0;
        }

        carBrands[brand][model] += Number(producedCars);
    }

    for (let [brand, models] of Object.entries(carBrands)) {
        console.log(brand);
        for (let [model, quantity] of Object.entries(models)) {
            console.log(`###${model} -> ${quantity}`);
        }
    }
}