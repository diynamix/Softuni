const { expect } = require('chai');
const { bookSelection } = require('./solution.js');

describe("Tests …", function () {
    describe("isGenreSuitable", function () {
        it("isGenreSuitable with invalid params", function () {
            expect(() => bookSelection.isGenreSuitable("Crime", "twelve").to.throw("Invalid input!"));
            expect(() => bookSelection.isGenreSuitable("11", "12").to.throw("Invalid input!"));
        });

        it("isGenreSuitable with valid params", function () {
            expect(bookSelection.isGenreSuitable('Comedy', 12)).to.equal('Those books are suitable');
            expect(bookSelection.isGenreSuitable('Thriller', 13)).to.equal('Those books are suitable');
            expect(() => bookSelection.isGenreSuitable("Horror", 12).to.throw("Books with Horror genre are not suitable for kids at 12 age"));
        });
    });

    describe("isItAffordable", function () {
        it("isItAffordable with invalid params", function () {
            expect(() => bookSelection.isItAffordable(10, "twelve").to.throw("Invalid input!"));
            expect(() => bookSelection.isItAffordable("11", 12).to.throw("Invalid input!"));
        });

        it("isItAffordable with valid params", function () {
            expect(bookSelection.isItAffordable(10, 9)).to.equal(`You don't have enough money`);
            expect(bookSelection.isItAffordable(10, 10)).to.equal(`Book bought. You have 0$ left`);
            expect(bookSelection.isItAffordable(5, 10)).to.equal(`Book bought. You have 5$ left`);
        });
    });

    describe("suitableTitles", function () {
        it("suitableTitles with invalid params", function () {
            expect(() => bookSelection.suitableTitles(10, "TLOTR").to.throw("Invalid input!"));
            expect(() => bookSelection.suitableTitles([], 12).to.throw("Invalid input!"));
        });

        it("suitableTitles with valid params", function () {
            expect(bookSelection.suitableTitles(
                [
                    { title: 'TLOTR', genre: 'Adventure' },
                    { title: 'Narnia', genre: 'Adventure' },
                    { title: 'The Space Trilogy', genre: 'Fantasy' }
                ],
                'Adventure'
            )).to.deep.equal(['TLOTR', 'Narnia']);
            expect(bookSelection.suitableTitles(
                [
                    { title: 'TLOTR', genre: 'Adventure' },
                    { title: 'Narnia', genre: 'Adventure' },
                    { title: 'The Space Trilogy', genre: 'Fantasy' }
                ],
                'Fantasy'
            )).to.deep.equal(['The Space Trilogy']);
            expect(bookSelection.suitableTitles(
                [
                    { title: 'TLOTR', genre: 'Adventure' },
                    { title: 'Narnia', genre: 'Adventure' },
                    { title: 'The Space Trilogy', genre: 'Fantasy' }
                ],
                'Comedy'
            )).to.deep.equal([]);
        });
    });
});