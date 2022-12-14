const { expect } = require('chai');
const { isOddOrEven } = require('./evenOdd.js');

describe('Testing even or odd', () => {
    it('works with odd length', () => {
        expect(isOddOrEven('one')).to.equal('odd');
    });

    it('works with even length', () => {
        expect(isOddOrEven('')).to.equal('even');
    });

    it('works with empty strings', () => {
        expect(isOddOrEven('')).to.equal('even');
    });

    it('returns undefined when parameter is of a non-string type (number)', () => {
        expect(isOddOrEven(2)).to.be.undefined;
    });

    it('returns undefined when parameter is of a non-string type (bool)', () => {
        expect(isOddOrEven(true)).to.be.undefined;
    });
});