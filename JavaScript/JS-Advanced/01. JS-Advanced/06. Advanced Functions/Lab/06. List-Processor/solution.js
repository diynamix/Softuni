function listProcessor(input) {
    let result = []

    input.map(x => {
        let [cmd, str] = x.split(' ');
        processor(str)[cmd]();
    })

    function processor(str) {
        return {
            add: () => result.push(str),
            remove() {
                while (result.includes(str)) {
                    let index = result.indexOf(str);
                    result.splice(index, 1);
                }
            },
            print: () => console.log(result.join(',')),
        }
    }
}
