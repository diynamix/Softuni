const { expect } = require('chai');
const { chooseYourCar } = require('./chooseYourCar.js');

describe('Testing chooseYourCar', function () {
    describe('choosingType', function () {
        it('testing with valid input', function () {
            expect(() => chooseYourCar.choosingType('Sedan', 'red', 1899)).to.throw('Invalid Year!');
            expect(() => chooseYourCar.choosingType('Sedan', 'red', 2023)).to.throw('Invalid Year!');
            expect(() => chooseYourCar.choosingType('Mercedes', 'red', 2022)).to.throw('This type of car is not what you are looking for.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 2010)).to.equal('This red Sedan meets the requirements, that you have.');
            expect(chooseYourCar.choosingType('Sedan', 'red', 2022)).to.equal('This red Sedan meets the requirements, that you have.');
            expect(chooseYourCar.choosingType('Sedan', 'green', 1900)).to.equal('This Sedan is too old for you, especially with that green color.');
            expect(chooseYourCar.choosingType('Sedan', 'green', 2009)).to.equal('This Sedan is too old for you, especially with that green color.');
        });
        it('testing with invalid input', function () {
            expect(() => chooseYourCar.choosingType(2022)).to.throw('This type of car is not what you are looking for.');
        });
    });

    describe('brandName', function () {
        it('testing with valid input', function () {
            expect(chooseYourCar.brandName(['Mercedes', 'BMW', 'Peugeot'], 1)).to.equal('Mercedes, Peugeot');
            expect(chooseYourCar.brandName(['Mercedes', 'BMW'], 1)).to.equal('Mercedes');
            expect(chooseYourCar.brandName(['Mercedes'], 0)).to.deep.equal('');
        });
        it('testing with invalid input', function () {
            expect(() => chooseYourCar.brandName('Mercedes', 0)).to.throw('Invalid Information!');
            expect(() => chooseYourCar.brandName(['Mercedes'], '0')).to.throw('Invalid Information!');
            expect(() => chooseYourCar.brandName(['Mercedes'], -1)).to.throw('Invalid Information!');
            expect(() => chooseYourCar.brandName(['Mercedes'], 1)).to.throw('Invalid Information!');
            expect(() => chooseYourCar.brandName([], 0)).to.throw('Invalid Information!');
        });
    });

    describe('carFuelConsumption', function () {
        it('testing with valid input', function () {
            expect(chooseYourCar.carFuelConsumption(100, 7)).to.equal('The car is efficient enough, it burns 7.00 liters/100 km.');
            expect(chooseYourCar.carFuelConsumption(100, 7.1)).to.equal('The car burns too much fuel - 7.10 liters!');
            expect(chooseYourCar.carFuelConsumption(347, 12)).to.equal('The car is efficient enough, it burns 3.46 liters/100 km.');
            expect(chooseYourCar.carFuelConsumption(347, 30)).to.equal('The car burns too much fuel - 8.65 liters!');
        });
        it('testing with invalid input', function () {
            expect(() => chooseYourCar.carFuelConsumption('1', 1)).to.throw('Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(-1, 1)).to.throw('Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(1, '1')).to.throw('Invalid Information!');
            expect(() => chooseYourCar.carFuelConsumption(1, -1)).to.throw('Invalid Information!');
        });
    });
});