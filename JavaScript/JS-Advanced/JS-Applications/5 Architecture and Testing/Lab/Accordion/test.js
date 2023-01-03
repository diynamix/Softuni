const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page; // Declare reusable variables

describe('E2E tests', function () {
    this.timeout(5000);

    // before(async () => { browser = await chromium.launch({ headless: false, slowMo: 500 }); });
    before(async () => { browser = await chromium.launch(); });
    after(async () => { await browser.close(); });
    beforeEach(async () => { page = await browser.newPage(); });
    afterEach(async () => { await page.close(); });

    it('loads article titles', async () => {
        await page.goto('http://localhost:5500');
        // await page.screenshot({ path: 'page.png' });

        // await page.waitForTimeout(300);
        await page.waitForSelector('.accordion div.head>span');
        const contenet = await page.textContent('#main');

        expect(contenet).to.contain('Scalable Vector Graphics');
        expect(contenet).to.contain('Open standard');
        expect(contenet).to.contain('Unix');
        expect(contenet).to.contain('ALGOL');
    });

    it('has working More button', async () => {
        await page.goto('http://localhost:5500');

        await page.click('text=More');

        await page.waitForSelector('.extra p');

        const text = await page.textContent('.extra p');
        const visible = await page.isVisible('.extra p');

        expect(text).to.contain('Scalable Vector Graphics (SVG) is an Extensible Markup Language (XML)');
        expect(visible).to.be.true;
    });

    it('has working Less button', async () => {
        await page.goto('http://localhost:5500');

        await page.click('text=More');

        await page.waitForSelector('.extra p');

        let visible = await page.isVisible('.extra p');
        expect(visible).to.be.true;

        await page.click('text=Less');
        visible = await page.isVisible('.extra p');
        expect(visible).to.be.false;
    });
});
