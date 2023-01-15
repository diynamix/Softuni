function heroicInventory(arr) {
    let result = arr.map(hero => {
        let [name, level, items] = hero.split(' / ');
        return {
            name,
            level: Number(level),
            items: items ? items.split(', ') : [],
        };
    });

    let json = JSON.stringify(result);
    console.log(json);
}
