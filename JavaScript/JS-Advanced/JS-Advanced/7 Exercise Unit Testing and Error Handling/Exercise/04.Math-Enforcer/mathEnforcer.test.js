const { expect } = require('chai');
const { mathEnforcer } = require('./mathEnforcer.js');

describe('Testing math enforcer', function () {
    describe('addFive', function () {
        it('should return correct result with a non-number parameter', function () {
            expect(mathEnforcer.addFive('1')).to.be.undefined;
            expect(mathEnforcer.addFive(undefined)).to.be.undefined;
        });

        it('should return correct result with integer parameter', function () {
            expect(mathEnforcer.addFive(0)).to.be.closeTo(5, 0.01);
        });

        it('should return correct result with floating-point parameter', function () {
            expect(mathEnforcer.addFive(0.01)).to.be.closeTo(5.01, 0.01);
        });

        it('should return correct result with negative parameter', function () {
            expect(mathEnforcer.addFive(-7.04)).to.be.closeTo(-2.04, 0.01);
        });
    });

    describe('subtractTen', function () {
        it('should return correct result with a non-number parameter', function () {
            expect(mathEnforcer.subtractTen('1')).to.be.undefined;
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined;
        });

        it('should return correct result with integer parameter', function () {
            expect(mathEnforcer.subtractTen(0)).to.be.closeTo(-10, 0.01);
        });

        it('should return correct result with floating-point parameter', function () {
            expect(mathEnforcer.subtractTen(11.01)).to.be.closeTo(1.01, 0.01);
        });

        it('should return correct result with negative parameter', function () {
            expect(mathEnforcer.subtractTen(-1.01)).to.be.closeTo(-11.01, 0.01);
        });
    });

    describe('sum', function () {
        it('should return correct result with a non-number first parameter', function () {
            expect(mathEnforcer.sum('1', 2)).to.be.undefined;
            expect(mathEnforcer.sum(undefined, 2)).to.be.undefined;
        });

        it('should return correct result with a non-number secont parameter', function () {
            expect(mathEnforcer.sum(1, '2')).to.be.undefined;
            expect(mathEnforcer.sum(1, false)).to.be.undefined;
        });

        it('should return correct result with floating-point negative parameter', function () {
            expect(mathEnforcer.sum(-4.5, -1.01)).to.be.closeTo(-5.51, 0.01);
        });

        it('should return correct result with floating-point positive parameter', function () {
            expect(mathEnforcer.sum(2, 1.1)).to.be.closeTo(3.1, 0.01);
        });
    });
});