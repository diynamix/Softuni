const { expect } = require('chai');
const { PaymentPackage } = require('./PaymentPackage.js');

describe('Payment package testing', () => {
    // Happy path
    it('constructor', () => {
        let test = new PaymentPackage('abc', 0);
        expect(test.name).to.equal('abc');
        expect(test.value).to.equal(0);
        expect(test.VAT).to.equal(20);
        expect(test.active).to.be.true;
    });

    it('works with valid name', () => {
        expect(() => new PaymentPackage('abc', 0)).not.to.throw('Name must be a non-empty string');
    });

    it('works with valid value', () => {
        expect(() => new PaymentPackage('abc', 0)).not.to.throw('Value must be a non-negative number');
    });

    it('works with valid VAT', () => {
        let testVat = new PaymentPackage('abc', 0);
        expect(() => testVat.VAT = 0).not.to.throw('VAT must be a non-negative number');
    });

    it('works with valid active', () => {
        let testActive = new PaymentPackage('abc', 0);
        expect(() => testActive.active = true).not.to.throw('Active status must be a boolean');
    });

    // toString()
    it('works for toString()', () => {
        let testToString = new PaymentPackage('abc', 100);
        const output = [
            'Package: abc',
            '- Value (excl. VAT): 100',
            '- Value (VAT 20%): 120'
        ];
        expect(testToString.toString()).to.equal(output.join('\n'));
    });

    it('works for toString() with false active', () => {
        let testToString = new PaymentPackage('abc', 100);
        testToString.active = false;
        const output = [
            'Package: abc (inactive)',
            '- Value (excl. VAT): 100',
            '- Value (VAT 20%): 120'
        ];
        expect(testToString.toString()).to.equal(output.join('\n'));
    });

    it('works for toString() with 30% VAT', () => {
        let testToString = new PaymentPackage('abc', 100);
        testToString.VAT = 30;
        const output = [
            'Package: abc',
            '- Value (excl. VAT): 100',
            '- Value (VAT 30%): 130'
        ];
        expect(testToString.toString()).to.equal(output.join('\n'));
    });


    // name
    it('throws error for empty string name', () => {
        expect(() => new PaymentPackage('', 0)).to.throw('Name must be a non-empty string');
    });

    it('throws error for non-string name', () => {
        expect(() => new PaymentPackage(true, 0)).to.throw('Name must be a non-empty string');
    });


    // value
    it('throws error for non-number value', () => {
        expect(() => new PaymentPackage('abc', [1])).to.throw('Value must be a non-negative number');
    });

    it('throws error for negative number value', () => {
        expect(() => new PaymentPackage('abc', -1)).to.throw('Value must be a non-negative number');
    });


    // VAT
    it('throws error for non-number VAT', () => {
        expect(() => new PaymentPackage('abc', 0).VAT = 'abc').to.throw('VAT must be a non-negative number');
    });

    it('throws error for negative number VAT', () => {
        expect(() => new PaymentPackage('abc', 0).VAT = -1).to.throw('VAT must be a non-negative number');
    });


    // active
    it('throws error for non-boolean active param', () => {
        expect(() => new PaymentPackage('abc', 0).active = null).to.throw('Active status must be a boolean');
    });
});