function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', function () {
        let emailPattern = /^[a-z]+@[a-z]+\.[a-z]+$/g;
        let email = input.value;
        if (emailPattern.test(email)) {
            input.classList.remove('error')
        } else {
            input.classList.add('error')
        }
    });
}