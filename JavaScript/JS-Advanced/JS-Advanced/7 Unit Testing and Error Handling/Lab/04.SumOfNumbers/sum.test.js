const { expect } = require('chai');
const { sum } = require('./sum.js');

describe('Testing Summing Function', () => {
    it('return NaN if one element of array is not a number', () => {
        expect(isNaN(sum([1, 'a']))).to.equal(true);
    });

    it('calculates 1 element array', () => {
        expect(sum([1])).to.equal(1);
    });

    it('calculates 2 element array', () => {
        expect(sum([4, 5])).to.equal(9);
    });
});