function townPopulation(input) {
    let townData = input.map(x => {
        let data = x.split(' <-> ');
        return {
            name: data[0],
            population: Number(data[1]),
        };
    });

    let registry = {};

    for (let town of townData) {
        if (registry[town.name] === undefined) {
            registry[town.name] = 0;
        }
        registry[town.name] += town.population;
    }

    for (let town in registry) {
        console.log(town + ' : ' + registry[town]);
    }
}


// function townPopulation(input) {
//     let registry = input
//         .map(x => {
//             let data = x.split(' <-> ');
//             return {
//                 name: data[0],
//                 population: Number(data[1]),
//             };
//         })
//         .reduce((result, town) => {
//             if (result[town.name] === undefined) {
//                 result[town.name] = 0;
//             }
//             result[town.name] += town.population;

//             return result;
//         }, {});

//     for (let town in registry) {
//         console.log(town + ' : ' + registry[town]);
//     }
// }
