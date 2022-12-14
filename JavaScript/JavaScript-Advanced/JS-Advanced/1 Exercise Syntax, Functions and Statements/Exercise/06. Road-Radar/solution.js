function roadRadar(speed, area) {
    let speedLimit = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20,
    };

    if (speed <= speedLimit[area]) {
        console.log(`Driving ${speed} km/h in a ${speedLimit[area]} zone`);
    } else {
        let difference = speed - speedLimit[area];
        let status = difference <= 20 ? 'speeding'
            : difference <= 40 ? 'excessive speeding'
                : 'reckless driving';
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit[area]} - ${status}`);
    }
}
