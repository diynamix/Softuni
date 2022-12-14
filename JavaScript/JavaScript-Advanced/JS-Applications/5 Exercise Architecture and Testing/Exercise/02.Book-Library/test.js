const { chromium, request } = require('playwright-chromium');
const { expect } = require('chai');

const host = 'http://localhost:5500';

const mockData = {
    "d953e5fb-a585-4d6b-92d3-ee90697398a0": {
        "author": "J.K.Rowling",
        "title": "Harry Potter and the Philosopher's Stone"
    },
    "d953e5fb-a585-4d6b-92d3-ee90697398a1": {
        "title": "C# Fundamentals",
        "author": "Svetlin Nakov"
    }
};

describe('Tests', async function () {
    this.timeout(6000);

    let browser, page;

    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 1000 });
        // browser = await chromium.launch();
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        page.close();
    });

    // it('works', async () => {
    //     await new Promise(r => setTimeout(r, 2000));
    //     expect(1).to.equal(1);
    // });

    it('loads all books', async () => {
        await page.route('**/jsonstore/collections/boks', (route, request) => {
            route.fulfill({
                body: JSON.stringify(mockData),
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Content-type': 'application/json'
                }
            });
        });

        // navigate to page
        await page.goto(host);

        // find and click load button
        await page.click('text=Load all books');
        await page.waitForSelector('text=Harry Potter');
        const rawData = await page.$$eval('tbody tr', rows => rows.map(r => r.textContent));

        // check that book are displayed
        expect(rawData[0]).to.contains('Harry Potter');
        expect(rawData[0]).to.contains('Rowling');
        expect(rawData[1]).to.contains('C# Fundamentals');
        expect(rawData[1]).to.contains('Nakov');
    });

    it.only('creates book', async () => {
        // navigate to page
        await page.goto(host);

        // find form

        // fill input fields
        await page.fill('input[name=title]', 'Title');
        await page.fill('input[name=author]', 'Author');

        // click submit
        const [request] = await Promise.all([
            page.waitForRequest((request) => request.method() == 'POST'),
            page.click('text=Submit')
        ]);

        const data = JSON.parse(request.postData());
        expect(data.title).to.equal('Title');
        expect(data.author).to.equal('Author');
    });
});