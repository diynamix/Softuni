function weekDays(day) {
    let days = {
        'Monday': 1,
        'Tuesday': 2,
        'Wednesday': 3,
        'Thursday': 4,
        'Friday': 5,
        'Saturday': 6,
        'Sunday': 7,
    }
    let print = days[day] != undefined ? days[day] : 'error';
    console.log(print);
}
