//50/100
function solve() {
  const QAndA = {
    'Question #1: Which event occurs when the user clicks on an HTML element?': 'onclick',
    'Question #2: Which function converting JSON to string?': 'JSON.stringify()',
    'Question #3: What is DOM?': 'A programming API for HTML and XML documents',
  };

  Array.from(document.getElementsByClassName('quiz-answer'))
    .map(answer => answer.addEventListener('click', next));
  let sections = Array.from(document.getElementsByTagName('section'));
  let rightAnswers = 0;

  function next(event) {
    let question = event.currentTarget.parentElement.getElementsByTagName('h2')[0].innerText;
    let answer = event.currentTarget.innerText;
    if (QAndA[question] === answer) {
      rightAnswers++;
    }
    let section = sections.shift();
    section.style.display = 'block';

    section.style.display = 'none';
    if (sections.length > 0) {
      sections[0].style.display = 'block';
    } else {
      showResult();
    }
  }

  function showResult() {
    let result = document.querySelector('#results h1');
    document.getElementById('results').style.display = 'block'

    if (rightAnswers === Object.keys(QAndA).length) {
      result.textContent = 'You are recognized as top JavaScript fan!';
    } else {
      result.textContent = `You have ${rightAnswers} right answers`;
    }
  }
}


//100/100 - from the web
function solve2() {
  let correct = 0
  let inCorrect = 0

  const mapper = {
    'Question #1: Which event occurs when the user clicks on an HTML element?': 'onclick',
    'Question #2: Which function converting JSON to string?': 'JSON.stringify()',
    'Question #3: What is DOM?': 'A programming API for HTML and XML documents'
  }

  const questions = document.querySelectorAll('h2');
  let sectionEl = Array.from(document.querySelectorAll('section'));

  for (let i = 0; i < questions.length; i++) {
    let currentQuestion = questions[i].textContent
    let buttons = sectionEl[i].querySelectorAll('p');
    for (el of buttons) {
      el.addEventListener('click', clickAnswer)
    }

    function clickAnswer(e) {
      if (e.currentTarget.textContent === mapper[currentQuestion]) {
        correct += 1;
        if (i < 2) {
          sectionEl[i].style.display = 'none';
          sectionEl[i + 1].style.display = 'block';

        }
      } else {
        if (i < 2) {
          sectionEl[i].style.display = 'none';
          sectionEl[i + 1].style.display = 'block';
        }
      }

      if (i === 2) {
        if (correct === 3) {
          let result = document.querySelectorAll('.results-inner')[0].children;
          result[0].textContent = 'You are recognized as top JavaScript fan!';
          sectionEl[i].style.display = 'none';
          document.getElementById('results').style.display = 'block';
        } else {
          let result = document.querySelectorAll('.results-inner')[0].children;
          result[0].textContent = `You have ${correct} right answers`;
          sectionEl[i].style.display = 'none';
          document.getElementById('results').style.display = 'block';
        }
      }
    }
  }
}