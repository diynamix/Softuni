function words(str) {
    if (str != undefined) {
        let regex = /\w+/g;
        let matchWords = str.match(regex); //regex.exec(str);
        let toUpper = matchWords.map(x => x.toUpperCase()).join(', ');
        console.log(toUpper);
    }
}
