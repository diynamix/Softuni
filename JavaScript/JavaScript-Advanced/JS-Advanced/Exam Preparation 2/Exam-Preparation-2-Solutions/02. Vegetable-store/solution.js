class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        const types = new Set();
        for (let veg of vegetables) {
            let [type, quantity, price] = veg.split(' ');
            quantity = Number(quantity);
            price = Number(price);
            types.add(type);

            let product = this.availableProducts.find(p => p.type == type);
            if (product == null) {
                product = { type, quantity: 0, price: 0 };
                this.availableProducts.push(product);
            }
            product.quantity += quantity;
            if (price > product.price) {
                product.price = price;
            }
        }
        return `Successfully added ${Array.from(types).join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;
        for (let productInfo of selectedProducts) {
            let [type, quantity] = productInfo.split(' ');
            quantity = Number(quantity);

            let product = this.availableProducts.find(p => p.type == type);
            if (product == null) {
                throw new Error(`${type} is not available in the store, your current bill is \$${totalPrice.toFixed(2)}.`);
            } else if (quantity > product.quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is \$${totalPrice.toFixed(2)}.`);
            }

            totalPrice += quantity * product.price;
            product.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount \$${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {
        quantity = Number(quantity);

        let product = this.availableProducts.find(p => p.type == type);
        if (product == null) {
            throw new Error(`${type} is not available in the store.`);
        } else if (quantity > product.quantity) {
            product.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        product.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        let output = "Available vegetables:";
        let sorted = this.availableProducts.sort((a, b) => a.price - b.price);
        for (let product of sorted) {
            output += `\n${product.type}-${product.quantity}-\$${product.price}`;
        }
        output += `\nThe owner of the store is ${this.owner}, and the location is ${this.location}.`;
        return output;
    }
}