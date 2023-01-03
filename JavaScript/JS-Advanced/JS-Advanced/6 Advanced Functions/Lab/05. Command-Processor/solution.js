function commandProcessor() {
    let content = '';

    return {
        append: (s) => content += s,
        removeStart: (n) => content = content.substring(n),
        removeEnd: (n) => content = content.substring(0, content.length - n),
        print: () => console.log(content),
    }
}
