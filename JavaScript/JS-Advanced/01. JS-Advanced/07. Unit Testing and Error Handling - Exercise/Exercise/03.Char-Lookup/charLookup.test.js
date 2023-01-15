const { expect } = require('chai');
// const { describe } = require('mocha');
const { lookupChar } = require('./charLookup.js');

describe('Testing char lookup', () => {
    it('works with string and integer', () => {
        expect(lookupChar('abc', 1)).to.equal('b');
    });

    it('returns undefined if first param is not a string', () => {
        expect(lookupChar(0, 1)).to.be.undefined;
    });

    it('returns undefined if second param is not an integer', () => {
        expect(lookupChar('abc', 1.5)).to.be.undefined;
    });

    it('returns "Incorrect index" if index is negative', () => {
        expect(lookupChar('abc', -1)).to.equal('Incorrect index');
    });

    it('returns "Incorrect index" if index is bigger than bounds', () => {
        expect(lookupChar('abc', 3)).to.equal('Incorrect index');
    });
});