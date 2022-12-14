// from the web
class Textbox {
    constructor(selector, regex) {
        this._elements = document.querySelectorAll(selector)
        this._invalidSymbols = regex
        Array.from(this.elements)
            .forEach(el => el.addEventListener('change', function () {
                this.value = el.value;
            }));
    }

    get value() {
        return this.elements[0].value;
    }

    set value(val) {
        Array.from(this._elements).forEach(el => el.value = val);
    }

    get elements() {
        return this._elements;
    }

    isValid() {
        return !this._invalidSymbols.test(this.elements[0].value);
    }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

inputs.addEventListener('click', function () { console.log(textbox.value); });