function validate() {
    let companyChecker = document.getElementById('company');
    companyChecker.addEventListener('change', () => {
        let companyInfo = document.getElementById('companyInfo');
        companyInfo.style.display = companyChecker.checked ? 'block' : 'none';
    });

    document.getElementById('submit').addEventListener('click', onClick);

    function onClick(event) {
        event.preventDefault();
        let allCorrect = true;

        let username = document.getElementById('username');
        let usernamePattern = /^[a-zA-Z0-9]{3,20}$/g;
        if (usernamePattern.test(username.value)) {
            username.style['border-color'] = '';
        } else {
            username.style['border-color'] = 'red';
            allCorrect = false;
        }

        let email = document.getElementById('email');
        let emailPattern = /^.*@.*\..*$/g;
        if (emailPattern.test(email.value)) {
            email.style['border-color'] = '';
        } else {
            email.style['border-color'] = 'red';
            allCorrect = false;
        }

        let password = document.getElementById('password');
        let passwordPattern = /^[\w]{5,15}$/g;
        let confirmPassword = document.getElementById('confirm-password');
        if (passwordPattern.test(password.value)
            && password.value === confirmPassword.value) {
            password.style['border-color'] = '';
            confirmPassword.style['border-color'] = '';
        } else {
            password.style['border-color'] = 'red';
            confirmPassword.style['border-color'] = 'red';
            allCorrect = false;
        }

        let companyNumber = document.getElementById('companyNumber');
        if (companyChecker.checked) {
            let companyNumberPattern = /^[1-9][0-9]{3}$/g;
            if (companyNumberPattern.test(companyNumber.value)) {
                companyNumber.style['border-color'] = '';
            } else {
                companyNumber.style['border-color'] = 'red';
                allCorrect = false;
            }
        }

        let validDiv = document.getElementById('valid');
        validDiv.style.display = allCorrect ? 'block' : 'none';
    }
}