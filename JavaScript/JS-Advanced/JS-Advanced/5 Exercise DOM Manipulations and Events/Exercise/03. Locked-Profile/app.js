function lockedProfile() {
    let profiles = document.querySelectorAll('div.profile');

    for (let profile of profiles) {
        let lock = profile.querySelector('input[value="lock"]');
        lock.addEventListener('click', function () { btn.disabled = true; });

        let unlock = profile.querySelector('input[value="unlock"]');
        unlock.addEventListener('click', function () { btn.disabled = false; });

        let btn = profile.getElementsByTagName('button')[0];
        console.log(btn.disabled);

        let hidden = profile.querySelector('div:last-of-type');
        console.log(hidden);

        btn.addEventListener('click', function () {
            if (btn.textContent == 'Show more') {
                btn.textContent = 'Hide it';
                hidden.style.display = 'block';
            } else if (btn.textContent == 'Hide it') {
                btn.textContent = 'Show more';
                hidden.style.display = 'none';
            }
        });

        if (lock.checked) {
            btn.disabled = true;
        } else {
            btn.disabled = false;
        }
    }
}