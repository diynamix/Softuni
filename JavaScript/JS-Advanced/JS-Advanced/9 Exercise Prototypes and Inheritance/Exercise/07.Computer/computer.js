function createComputerHierarchy() {
    class Manufacturer {
        constructor(manufacturer) {
            if (new.target == Manufacturer) {
                throw new Error;
            }
            this.manufacturer = manufacturer;
        }
    }

    class Keyboard extends Manufacturer {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = Number(responseTime);
        }
    }

    class Monitor extends Manufacturer {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = Number(width);
            this.height = Number(height);
        }
    }

    class Battery extends Manufacturer {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = Number(expectedLife);
        }
    }

    class Computer extends Manufacturer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            if (new.target == Computer) {
                throw new Error;
            }
            super(manufacturer);
            this.processorSpeed = Number(processorSpeed);
            this.ram = Number(ram);
            this.hardDiskSpace = Number(hardDiskSpace);
        }
    }

    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        get battery() {
            return this._battery;
        }

        set battery(value) {
            if (value instanceof Battery == false) {
                throw new TypeError;
            }

            this._battery = value;
        }
    }

    class Desktop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.keyboard = keyboard;
            this.monitor = monitor;
        }

        get keyboard() {
            return this._keyboard;
        }

        set keyboard(value) {
            if (value instanceof Keyboard == false) {
                throw new TypeError;
            }

            this._keyboard = value;
        }

        get monitor() {
            return this._monitor;
        }

        set monitor(value) {
            if (value instanceof Monitor == false) {
                throw new TypeError;
            }

            this._monitor = value;
        }
    }

    return {
        Keyboard,
        Monitor,
        Battery,
        Computer,
        Laptop,
        Desktop
    }
}

// let classes = createComputerHierarchy();
// let Computer = classes.Computer;
// let Laptop = classes.Laptop;
// let Desktop = classes.Desktop;
// let Monitor = classes.Monitor;
// let Battery = classes.Battery;
// let Keyboard = classes.Keyboard;

// let battery = new Battery('Energy', 3);
// console.log(battery);
// let laptop = new Laptop("Hewlett Packard", 2.4, 4, 0.5, 3.12, "Silver", battery);
// console.log(laptop);