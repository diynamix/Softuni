function createDeck(cards) {
    let result = [];

    for (let card of cards) {
        let face = card.slice(0, -1);
        let suit = card.slice(-1);

        try {
            const currentCard = createCard(face, suit);
            result.push(currentCard);
        } catch (error) {
            result = ['Invalid card: ' + card];
        }
    }

    console.log(result.join(' '))

    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = { 'S': '\u2660', 'H': '\u2665', 'D': '\u2666', 'C': '\u2663', }

        if (faces.indexOf(face.toString()) === -1) {
            throw new Error('Error');
        }

        if (Object.keys(suits).includes(suit) === false) {
            throw new Error('Error');
        }

        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        }
    }
}