window.addEventListener("load", solve);

function solve() {
  // input
  let firstName = document.getElementById('first-name');
  let lastName = document.getElementById('last-name');
  let age = document.getElementById('age');
  let storyTitle = document.getElementById('story-title');
  let genre = document.getElementById('genre');
  let story = document.getElementById('story');
  let publishBtn = document.getElementById('form-btn');
  publishBtn.addEventListener('click', publish);

  // preview
  let preview = document.getElementById('preview-list');

  // div #main
  let divMain = document.getElementById('main');

  function publish(e) {
    e.preventDefault();

    if (!firstName.value || !lastName.value || !age.value || !storyTitle.value || !genre.value || !story.value) {
      return;
    }

    create(firstName.value, lastName.value, age.value, storyTitle.value, genre.value, story.value);
    publishBtn.disabled = true;
    clearInput();
  }

  function create(firstValue, lastValue, ageValue, titleValue, genreValue, storyValue) {
    let li = document.createElement('li');
    li.classList.add('story-info');

    let article = document.createElement('article');
    let h4 = document.createElement('h4');
    h4.textContent = `Name: ${firstValue} ${lastValue}`;
    let pAge = document.createElement('p');
    pAge.textContent = `Age: ${ageValue}`;
    let pTitle = document.createElement('p');
    pTitle.textContent = `Title: ${titleValue}`;
    let pGenre = document.createElement('p');
    pGenre.textContent = `Genre: ${genreValue}`;
    let pStory = document.createElement('p');
    pStory.textContent = `${storyValue}`;
    article.appendChild(h4);
    article.appendChild(pAge);
    article.appendChild(pTitle);
    article.appendChild(pGenre);
    article.appendChild(pStory);

    let saveBtn = document.createElement('button');
    saveBtn.classList.add('save-btn');
    saveBtn.textContent = 'Save Story';
    saveBtn.addEventListener('click', save);

    let editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');
    editBtn.textContent = 'Edit Story';
    editBtn.addEventListener('click', (e) =>
      edit(e, firstValue, lastValue, ageValue, titleValue, genreValue, storyValue));

    let deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete-btn');
    deleteBtn.textContent = 'Delete Story';
    deleteBtn.addEventListener('click', deleteFunc);

    li.appendChild(article);
    li.appendChild(saveBtn);
    li.appendChild(editBtn);
    li.appendChild(deleteBtn);

    preview.appendChild(li);
  }

  function save() {
    divMain.innerHTML = '<h1>Your scary story is saved!</h1>';
  }

  function edit(e, _first, _last, _age, _title, _genre, _story) {
    deleteFunc(e);

    firstName.value = _first;
    lastName.value = _last;
    age.value = _age;
    storyTitle.value = _title;
    genre.value = _genre;
    story.value = _story;
  }

  function deleteFunc(e) {
    e.target.parentNode.remove();
    publishBtn.disabled = false;
  }

  function clearInput() {
    firstName.value = '';
    lastName.value = '';
    age.value = '';
    storyTitle.value = '';
    story.value = '';
  }
}