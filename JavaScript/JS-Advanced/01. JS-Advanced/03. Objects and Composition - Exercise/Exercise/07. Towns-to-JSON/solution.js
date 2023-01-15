function townsToJSON(arr) {
    let headings = arr.shift().split(/ *\| */g).filter(x => x);
    let towns = [];

    for (let line of arr) {
        let info = line.split(/ *\| */g).filter(x => x);
        towns.push({
            [headings[0]]: info[0],
            [headings[1]]: Number(Number(info[1]).toFixed(2)),
            [headings[2]]: Number(Number(info[2]).toFixed(2)),
        });
    }

    console.log(JSON.stringify(towns));
}
