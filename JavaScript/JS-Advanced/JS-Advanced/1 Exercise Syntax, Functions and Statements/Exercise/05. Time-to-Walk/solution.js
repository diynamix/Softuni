function timeToWalk(steps, footprintLength, speed) {
    let distance = steps * footprintLength; //meters
    let breakTime = Math.floor(distance / 500) * 60; //seconds
    speed = speed * (1000 / 3600); //m/s

    let time = (distance / speed) + breakTime; //seconds

    let hours = Math.floor(time / 3600);
    hours = hours < 10 ? `0${hours}` : hours;
    let minutes = Math.floor(time / 60);
    minutes = minutes < 10 ? `0${minutes}` : minutes;
    let seconds = Math.round(time % 60);
    seconds = seconds < 10 ? `0${seconds}` : seconds;
    console.log(`${hours}:${minutes}:${seconds}`);
}
