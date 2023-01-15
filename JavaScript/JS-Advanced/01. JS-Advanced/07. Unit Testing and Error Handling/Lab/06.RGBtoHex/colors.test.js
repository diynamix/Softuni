const { expect } = require('chai');
const { rgbToHexColor } = require('./colors.js');

describe('RGB Converter', () => {

    describe('Happy path', () => {
        it('converts white', () => {
            expect(rgbToHexColor(255, 255, 255)).to.equals('#FFFFFF');
        })

        it('converts black', () => {
            expect(rgbToHexColor(0, 0, 0)).to.equals('#000000');
        })

        it('converts SoftUni dark blue to #234465', () => {
            expect(rgbToHexColor(35, 68, 101)).to.equals('#234465');
        })
    });

    describe('Invalid parameters', () => {
        it('returns undefined for missing parameters', () => {
            expect(rgbToHexColor(255)).to.be.undefined;
        });

        it('returns undefined for red value out of range (-1, 0, 0)', () => {
            expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
        });

        it('returns undefined for green value out of range (0, -1, 0)', () => {
            expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
        });

        it('returns undefined for blue value out of range (0, 0, -1)', () => {
            expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
        });

        it('returns undefined for value out of range (256)', () => {
            expect(rgbToHexColor(256, 255, 255)).to.be.undefined;
            expect(rgbToHexColor(255, 256, 255)).to.be.undefined;
            expect(rgbToHexColor(255, 255, 256)).to.be.undefined;
        });

        it('returns undefined for red invalid parameter type', () => {
            expect(rgbToHexColor('0', 0, 0)).to.be.undefined;
        });

        it('returns undefined for green invalid parameter type', () => {
            expect(rgbToHexColor(0, '0', 0)).to.be.undefined;
        });

        it('returns undefined for blue invalid parameter type', () => {
            expect(rgbToHexColor(0, 0, '0')).to.be.undefined;
        });
    });

});