function areaAndVolumeCalculator(area, vol, input) {
    input = JSON.parse(input);

    let result = [];

    for (let entry of input) {
        let calculatedArea = area.call(entry);
        let calculatedVolume = vol.call(entry);

        result.push({
            area: calculatedArea,
            volume: calculatedVolume,
        })
    }

    return result;
}
