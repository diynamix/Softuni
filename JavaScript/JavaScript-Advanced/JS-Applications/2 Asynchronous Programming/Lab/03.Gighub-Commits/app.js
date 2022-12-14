async function loadCommits() {
    // read input fields
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const list = document.getElementById('commits');

    try {
        // send request
        const response = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`)

        // check for errors
        if (response.ok == false) {
            throw new Error(`${response.status} ${response.statusText}`);
        }

        // display result
        const data = await response.json();

        list.innerHTML = '';

        for (let { commit } of data) {
            list.innerHTML += `<li>${commit.author.name}: ${commit.message}</li>`;
        }

        // handle errors
    } catch (err) {
        list.innerHTML = `Error: ${err.message}`;
    }
}