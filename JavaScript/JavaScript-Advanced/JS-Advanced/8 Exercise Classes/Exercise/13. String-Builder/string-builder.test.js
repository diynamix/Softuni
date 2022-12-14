const { expect } = require('chai');
const { StringBuilder } = require('./string-builder.js');

describe('Testing String Builder', () => {
    // constructor
    describe('constructor', () => {
        it('works with string', () => {
            let str = new StringBuilder('abc');
            expect(Object.values(str)[0][1]).to.equal('b');
        });

        it('works with no param', () => {
            expect(() => new StringBuilder()).not.to.throw('Argument must be a string');
        });

        it('throws error for non-string type (number)', () => {
            expect(() => new StringBuilder(0)).to.throw('Argument must be a string')
        });

        it('throws error for non-string type (array)', () => {
            expect(() => new StringBuilder([1])).to.throw('Argument must be a string')
        });
    });

    // append
    describe('append', () => {
        it('works with string', () => {
            let str = new StringBuilder('abc');
            expect(() => str.append('def')).not.to.throw('Argument must be a string');
            expect(Object.values(str)[0][3]).to.equal('d');
        });

        it('works with empty string', () => {
            let str = new StringBuilder('abc');
            expect(() => str.append("")).not.to.throw('Argument must be a string')
        });

        it('throws error for no parameter', () => {
            let str = new StringBuilder('abc');
            expect(() => str.append()).to.throw('Argument must be a string')
        });

        it('throws error for non-string type (number)', () => {
            let str = new StringBuilder('abc');
            expect(() => str.append(0)).to.throw('Argument must be a string')
        });

        it('throws error for non-string type (array)', () => {
            let str = new StringBuilder('abc');
            expect(() => str.append([1])).to.throw('Argument must be a string')
        });
    });


    // prepend
    describe('prepend', () => {
        it('works with string', () => {
            let str = new StringBuilder('abc');
            expect(() => str.prepend('def')).not.to.throw('Argument must be a string');
            expect(Object.values(str)[0][0]).to.equal('d');
        });

        it('works with empty string', () => {
            let str = new StringBuilder('abc');
            expect(() => str.prepend("")).not.to.throw('Argument must be a string')
        });

        it('throws error for no parameter', () => {
            let str = new StringBuilder('abc');
            expect(() => str.prepend()).to.throw('Argument must be a string')
        });

        it('throws error for non-string type (number)', () => {
            let str = new StringBuilder('abc');
            expect(() => str.prepend(0)).to.throw('Argument must be a string')
        });

        it('throws error for non-string type (array)', () => {
            let str = new StringBuilder('abc');
            expect(() => str.prepend([1])).to.throw('Argument must be a string')
        });
    });

    // insertAt
    describe('insertAt', () => {
        it('works with string', () => {
            let str = new StringBuilder('abc');
            expect(() => str.insertAt('def', 1)).not.to.throw('Argument must be a string');
            expect(Object.values(str)[0][1]).to.equal('d');
            expect(Object.values(str)[0][2]).to.equal('e');
        });

        it('works with empty string', () => {
            let str = new StringBuilder('abc');
            expect(() => str.insertAt("", 1)).not.to.throw('Argument must be a string')
        });

        it('throws error for non-string type (number)', () => {
            let str = new StringBuilder('abc');
            expect(() => str.insertAt(0, 1)).to.throw('Argument must be a string')
        });

        it('throws error for non-string type (array)', () => {
            let str = new StringBuilder('abc');
            expect(() => str.insertAt([1], 1)).to.throw('Argument must be a string')
        });
    });

    // remove
    describe('remove', () => {
        it('removes correctly', () => {
            let str = new StringBuilder('abcdef');
            str.remove(1, 2);
            expect(Object.values(str)[0][1]).to.equal('d');
            expect(Object.values(str)[0][2]).to.equal('e');
        });
    });

    // toString
    describe('toString', () => {
        it('returns correct string', () => {
            let str = new StringBuilder('abcdef');
            str.append('ghi');
            str.prepend('jkl');
            str.insertAt('mno', 3);
            str.remove(5, 4);
            expect(str.toString()).to.equal('jklmndefghi');
        });
    });
});