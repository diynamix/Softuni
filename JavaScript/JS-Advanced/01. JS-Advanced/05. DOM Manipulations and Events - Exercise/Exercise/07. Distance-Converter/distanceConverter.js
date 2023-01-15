function attachEventsListeners() {
    let units = {
        0: 1000,
        1: 1,
        2: 0.01,
        3: 0.001,
        4: 1609.34,
        5: 0.9144,
        6: 0.3048,
        7: 0.0254,
    };

    let btn = document.getElementById('convert');
    btn.addEventListener('click', convert);

    function convert() {
        let input = document.getElementById('inputDistance');
        let inputOptionIndex = document.getElementById('inputUnits').selectedIndex;

        let inputValue = Number(input.value);
        let inputValueInMeters = inputValue * units[inputOptionIndex];

        let output = document.getElementById('outputDistance');
        let outputOptionIndex = document.getElementById('outputUnits').selectedIndex;

        let result = inputValueInMeters / units[outputOptionIndex];
        output.value = result;
    }
}