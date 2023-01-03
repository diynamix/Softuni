function loadRepos() {
	// read input field
	const username = document.getElementById('username').value;
	const list = document.getElementById('repos');

	// send request
	fetch(`https://api.github.com/users/${username}/repos`)
		.then(handleResponse)
		.then(displayRepos)
		.catch(handleError);

	function handleResponse(response) {
		if (response.ok == false) {
			throw new Error(`${response.status} ${response.statusText}`);
		}

		return response.json();
	}

	function handleError(error) {
		list.innerHTML = `${error.message}`
	}

	// display response data
	function displayRepos(data) {
		list.innerHTML = '';
		for (let repo of data) {
			list.innerHTML +=
				`<li>
					<a href="${repo.html_url}" target="_blank">
                		${repo.full_name}
					</a>
				</li>`;
		}
	}
}