class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = Number(spaceAvailable);
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {
        spaceRequired = Number(spaceRequired);
        if (this.spaceAvailable >= spaceRequired) {
            this.spaceAvailable -= spaceRequired;
            this.plants.push({
                plantName,
                spaceRequired: spaceRequired,
                ripe: false,
                quantity: 0,
            });
            return `The ${plantName} has been successfully planted in the garden.`;
        } else {
            throw new Error("Not enough space in the garden.");
        }
    }

    ripenPlant(plantName, quantity) {
        quantity = Number(quantity);
        const plant = this.plants.find(p => p.plantName == plantName);
        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        } else if (plant.ripe == true) {
            throw new Error(`The ${plantName} is already ripe.`);
        } else if (quantity <= 0) {
            throw new Error("The quantity cannot be zero or negative.");
        } else {
            plant.ripe = true;
            plant.quantity += quantity;
            return `${quantity} ${plantName}${quantity == 1 ? ' has' : 's have'} successfully ripened.`;
        }
    }

    harvestPlant(plantName) {
        const plant = this.plants.find(p => p.plantName == plantName);
        if (!plant) {
            throw new Error(`There is no ${plantName} in the garden.`);
        } else if (plant.ripe == false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        } else {
            this.spaceAvailable += plant.spaceRequired;
            this.storage.push({
                plantName: plant.plantName,
                quantity: plant.quantity,
            });
            this.plants.splice(this.plants.indexOf(plant), 1);
            return `The ${plantName} has been successfully harvested.`;
        }
    }

    generateReport() {
        let output = `The garden has ${this.spaceAvailable} free space left.`;
        let garden = this.plants.map(p => p.plantName).sort().join(', ')
        output += `\nPlants in the garden: ${garden}`;
        output += `\nPlants in storage: ${this.storage.length == 0 ? 'The storage is empty.'
            : this.storage.map(p => `${p.plantName} (${p.quantity})`).join(', ')}`;
        return output;
    }
}