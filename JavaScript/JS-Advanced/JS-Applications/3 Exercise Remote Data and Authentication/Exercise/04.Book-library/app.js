// http://localhost:3030/jsonstore/collections/books

const loadAllBtn = document.getElementById("loadBooks");
const tbody = document.querySelector("tbody");

async function makeRequest(url, info = {}, method = "get") {
    if (method === "get") {
        const res = await fetch(url);
        const data = await res.json();

        return data;
    } else if (method === "post") {
        const res = await fetch(url, {
            method,
            headers: {
                "Content-Type": "application/json",
            },
            body: info.body,
        });
        const data = await res.json();
        return data;
    } else if (method === "delete") {
        await fetch(url, {
            method,
        });
    } else if (method === "put") {
        await fetch(url, {
            method,
            headers: {
                "Content-Type": "application/json",
            },
            body: info.body,
        });
    }
}

loadAllBtn.addEventListener("click", loadAllEntries);

async function loadAllEntries() {
    const data = await makeRequest(
        "http://localhost:3030/jsonstore/collections/books"
    );
    const dataValues = Object.values(data);
    tbody.innerHTML = "";

    if (dataValues.length > 0) {
        for (let val of dataValues) {
            const tr = document.createElement("tr");

            const tdTitle = document.createElement("td");
            tdTitle.textContent = val.title;

            const tdAuthor = document.createElement("td");
            tdAuthor.textContent = val.author;

            const tdActions = document.createElement("td");
            const edit = document.createElement("button");
            edit.dataset.id = val._id;
            edit.textContent = "Edit";
            edit.addEventListener("click", editEntry);

            const deleteBtn = document.createElement("button");
            deleteBtn.dataset.id = val._id;
            deleteBtn.textContent = "Delete";

            deleteBtn.addEventListener("click", deleteEntry);

            tdActions.appendChild(edit);
            tdActions.appendChild(deleteBtn);

            tr.appendChild(tdTitle);
            tr.appendChild(tdAuthor);
            tr.appendChild(tdActions);
            tbody.appendChild(tr);
        }
    }
}

// create book
const form = document.querySelector("form");
form.addEventListener("submit", async function (e) {
    e.preventDefault();
    const { target } = e;

    const formData = new FormData(target);
    const entries = [...formData.entries()];

    const areNotEmpty = entries.map((ent) => ent[1]).every((el) => el !== "");

    if (areNotEmpty) {
        console.log(entries);
        const obj = {
            author: entries[1][1],
            title: entries[0][1],
        };

        if (form.querySelector("h3").textContent === "FORM") {
            const data = await makeRequest(
                "http://localhost:3030/jsonstore/collections/books",
                {
                    body: JSON.stringify(obj),
                },
                "post"
            );

            const tr = document.createElement("tr");

            const tdTitle = document.createElement("td");
            tdTitle.textContent = data.title;

            const tdAuthor = document.createElement("td");
            tdAuthor.textContent = data.author;

            const tdActions = document.createElement("td");
            const edit = document.createElement("button");
            edit.textContent = "Edit";
            edit.dataset.id = data._id;
            edit.addEventListener("click", editEntry);

            const deleteBtn = document.createElement("button");
            deleteBtn.dataset.id = data._id;

            deleteBtn.addEventListener("click", deleteEntry);

            deleteBtn.textContent = "Delete";

            tdActions.appendChild(edit);
            tdActions.appendChild(deleteBtn);

            tr.appendChild(tdTitle);
            tr.appendChild(tdAuthor);
            tr.appendChild(tdActions);
            tbody.appendChild(tr);
        } else {
            await makeRequest(
                `http://localhost:3030/jsonstore/collections/books/${form.querySelector("h3").dataset.id
                }`,
                {
                    body: JSON.stringify({
                        _id: form.querySelector("h3").dataset.id,
                        author: entries[1][1],
                        title: entries[0][1],
                    }),
                },
                "put"
            );

            loadAllEntries();
        }

        document.querySelector('[name="title"]').value = document.querySelector(
            '[name="author"]'
        ).value = "";

        form.querySelector("h3").textContent = "FORM";
        form.querySelector("h3").removeAttribute("data-id");
    }
});

// delete entry

async function deleteEntry(e) {
    const { target } = e;

    if (target.dataset?.id) {
        await makeRequest(
            `http://localhost:3030/jsonstore/collections/books/${target.dataset.id}`,
            {},
            "delete"
        );
    }
}

// edit entry

async function editEntry(e) {
    const { target } = e;

    if (target.dataset?.id) {
        form.querySelector("h3").textContent = "EditFORM";
        form.querySelector("h3").dataset.id = target.dataset.id;
        console.log(target);

        const title =
            target.parentElement.parentElement.querySelector(
                "td:nth-of-type(1)"
            ).textContent;
        const author =
            target.parentElement.parentElement.querySelector(
                "td:nth-of-type(2)"
            ).textContent;

        document.querySelector('[name="title"]').value = title;
        document.querySelector('[name="author"]').value = author;
    }
}