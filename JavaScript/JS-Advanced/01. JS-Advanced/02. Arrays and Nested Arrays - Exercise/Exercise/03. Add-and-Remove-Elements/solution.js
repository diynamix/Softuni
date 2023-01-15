function addAndRemoveElements(arr) {
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        let command = arr[i];
        if (command == "add") {
            result.push(i + 1)
        } else if (command == "remove") {
            result.pop();
        }
    }
    if (result.length == 0) {
        result = ["Empty"];
    }
    result.forEach(x => console.log(x))
}
