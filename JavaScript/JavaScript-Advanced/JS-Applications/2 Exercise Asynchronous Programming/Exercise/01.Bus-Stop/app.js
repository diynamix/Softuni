async function getInfo() {
    // read input value
    // make request to server
    // parse response data
    // display data
    // * error checking for request

    const stopId = document.getElementById('stopId').value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;
    const stopName = document.getElementById('stopName');
    const buses = document.getElementById('buses');

    stopName.textContent = 'Loading...';
    buses.replaceChildren();

    // fetch(url)
    //     .then(res => {
    //         if (res.status != 200) {
    //             throw new Error('Stop ID not found')
    //         }

    //         return res.json();
    //     })
    //     .then(data => {
    //         stopName.textContent = data.name;

    //         Object.entries(data.buses).forEach(([busId, time]) => {
    //             const li = document.createElement('li');
    //             li.textContent = `Bus ${busId} arrives in ${time} minutes`;

    //             buses.appendChild(li);
    //         });
    //     })
    //     .catch(error => {
    //         stopName.textContent = 'Error';
    //     });

    try {
        stopName.textContent = 'Loading...';
        buses.replaceChildren();

        const res = await fetch(url);
        if (res.status != 200) {
            throw new Error('Stop ID not found')
        }

        const data = await res.json();

        stopName.textContent = data.name;

        Object.entries(data.buses).forEach(([busId, time]) => {
            const li = document.createElement('li');
            li.textContent = `Bus ${busId} arrives in ${time} minutes`;

            buses.appendChild(li);
        })

    } catch (error) {
        stopName.textContent = 'Error';
    }
}