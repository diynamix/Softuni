function validate() {
    let validatorPattern = /^[a-z]+@[a-z]+.[a-z]+$/g;
    let input = document.getElementById('email');

    input.addEventListener('change', function (event) {
        if (validatorPattern.test(event.target.value)) {
            event.target.removeAttribute('class');
            return;
        }
        event.target.className = 'error';
    });
}