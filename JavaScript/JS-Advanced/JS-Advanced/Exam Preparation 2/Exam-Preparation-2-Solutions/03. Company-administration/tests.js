const { expect } = require('chai');
const { companyAdministration } = require('./companyAdministration.js');

describe("Tests …", function () {
    describe("hiringEmployee", function () {
        it("testing with valid values", function () {
            expect(companyAdministration.hiringEmployee('Diyana', 'Programmer', 3)).to.equal(`Diyana was successfully hired for the position Programmer.`);
            expect(companyAdministration.hiringEmployee(24, 'Programmer', 3)).to.equal(`24 was successfully hired for the position Programmer.`);
        });

        it("testing with invalid values", function () {
            expect(() => companyAdministration.hiringEmployee('Diyana', 'Painter', 4)).to.throw(`We are not looking for workers for this position.`);
            expect(companyAdministration.hiringEmployee('Diyana', 'Programmer', 2)).to.equal(`Diyana is not approved for this position.`);
        });
    });

    describe("calculateSalary", function () {
        it("testing with valid values", function () {
            expect(companyAdministration.calculateSalary(0)).to.equal(0);
            expect(companyAdministration.calculateSalary(1)).to.equal(15);
            expect(companyAdministration.calculateSalary(160)).to.equal(2400);
            expect(companyAdministration.calculateSalary(161)).to.equal(3415);
        });

        it("testing with invalid values", function () {
            expect(() => companyAdministration.calculateSalary('1')).to.throw(`Invalid hours`);
            expect(() => companyAdministration.calculateSalary(-1)).to.throw(`Invalid hours`);
        });
    });

    describe("firedEmployee", function () {
        it("testing with valid values", function () {
            expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 0)).to.equal('Ivan, George');
            expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 1)).to.equal('Petar, George');
            expect(companyAdministration.firedEmployee(["Petar", "Ivan", "George"], 2)).to.equal('Petar, Ivan');
        });

        it("testing with invalid values", function () {
            expect(() => companyAdministration.firedEmployee(['Diyana', 'Tanya'], '0')).to.throw(`Invalid input`);
            expect(() => companyAdministration.firedEmployee(['Diyana', 'Tanya'], -1)).to.throw(`Invalid input`);
            expect(() => companyAdministration.firedEmployee(['Diyana', 'Tanya'], 2)).to.throw(`Invalid input`);
            expect(() => companyAdministration.firedEmployee('Diyana', 0)).to.throw(`Invalid input`);
            expect(() => companyAdministration.firedEmployee(0, 0)).to.throw(`Invalid input`);
            expect(() => companyAdministration.firedEmployee([], 0)).to.throw(`Invalid input`);
        });
    });
});