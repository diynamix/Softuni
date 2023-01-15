function sortTickets(data, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (let line of data) {
        let [destination, price, status] = line.split('|');
        tickets.push(new Ticket(destination, Number(price), status));
    }

    tickets.sort((a, b) => {
        return typeof a[criteria] === 'number'
            ? a[criteria] - b[criteria]
            : a[criteria].localeCompare(b[criteria])
    });

    return tickets;
}