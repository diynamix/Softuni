const enumIcon = {
    'Sunny': '&#x2600',
    'Partly sunny': '&#x26C5',
    'Overcast': '&#x2601',
    'Rain': '&#x2614',
    'Degrees': '&#176',
}

function attachEvents() {
    document.getElementById('submit').addEventListener('click', getForecast);
}

attachEvents();

async function getForecast() {
    const forecastContainer = document.getElementById('forecast');
    try {
        const townName = document.getElementById('location');
        const code = await getLocationCode(townName.value);

        const [current, upcoming] = await Promise.all([
            getCurrent(code),
            getUpcoming(code)
        ]);

        forecastContainer.style.display = 'block';

        const todayHTMLTemp = createToday(current);
        document.getElementById('current').appendChild(todayHTMLTemp);

        const upcomingHTMLTemp = createUpcoming(upcoming);
        document.getElementById('upcoming').appendChild(upcomingHTMLTemp);
    } catch (error) {
        forecastContainer.style.display = 'block';
        forecastContainer.textContent = 'Error';
    }
}

function createToday(data) {
    const [condition, high, low] = Object.values(data.forecast);

    const weatherContainer = createElement('div', 'forecasts');

    const iconSpan = createElement('span', 'condition', 'symbol');
    iconSpan.innerHTML = enumIcon[condition];

    const weatherSpan = createElement('span', 'condition');

    const nameSpan = createElement('span', 'forecast-data');
    nameSpan.textContent = data.name;

    const tempSpan = createElement('span', 'forecast-data');
    tempSpan.innerHTML = `${low}${enumIcon['Degrees']}/${high}${enumIcon['Degrees']}`;

    const conditionSpan = createElement('span', 'forecast-data');
    conditionSpan.textContent = condition;

    weatherSpan.appendChild(nameSpan);
    weatherSpan.appendChild(tempSpan);
    weatherSpan.appendChild(conditionSpan);
    weatherContainer.appendChild(iconSpan);
    weatherContainer.appendChild(weatherSpan);
    return weatherContainer;
}

function createUpcoming(data) {
    const weatherInfo = createElement('div', 'forecast-info');

    for (let day of Object.values(data.forecast)) {
        const [condition, high, low] = Object.values(day);

        const weatherContainer = createElement('div', 'upcoming');

        const iconSpan = createElement('span', 'symbol');
        iconSpan.innerHTML = enumIcon[condition];

        const tempSpan = createElement('span', 'forecast-data');
        tempSpan.innerHTML = `${low}${enumIcon['Degrees']}/${high}${enumIcon['Degrees']}`;

        const conditionSpan = createElement('span', 'forecast-data');
        conditionSpan.textContent = condition;

        weatherContainer.appendChild(iconSpan);
        weatherContainer.appendChild(tempSpan);
        weatherContainer.appendChild(conditionSpan);
        weatherInfo.appendChild(weatherContainer);
    }

    return weatherInfo;
}

function createElement(tag, ...classes) {
    const element = document.createElement(tag);
    element.classList.add(...classes);
    return element;
}

async function getLocationCode(name) {
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';

    const res = await fetch(url);
    const data = await res.json();

    const location = data.find(l => l.name == name);

    return location.code;
}

async function getCurrent(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;

    const res = await fetch(url);
    const data = await res.json();

    return data;
}

async function getUpcoming(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;

    const res = await fetch(url);
    const data = await res.json();

    return data;
}