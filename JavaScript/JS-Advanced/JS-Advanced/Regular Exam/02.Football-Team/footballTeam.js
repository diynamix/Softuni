class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        let players = new Set();
        for (let footballPlayer of footballPlayers) {
            let [name, age, playerValue] = footballPlayer.split('/')
            age = Number(age);
            playerValue = Number(playerValue);
            players.add(name);

            let player = this.invitedPlayers.find(p => p.name == name);
            if (!player) {
                player = {
                    name: name,
                    age: age,
                    playerValue: 0,
                };
                this.invitedPlayers.push(player);
            }
            if (playerValue > player.playerValue) {
                player.playerValue = playerValue;
            }
        }
        return `You successfully invite ${Array.from(players).join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let [name, playerOffer] = selectedPlayer.split('/');
        playerOffer = Number(playerOffer);
        let player = this.invitedPlayers.find(p => p.name == name);
        if (!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if (playerOffer < player.playerValue) {
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${player.playerValue - playerOffer} million more are needed to sign the contract!`);
        }

        player.playerValue = 'Bought';

        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age) {
        age = Number(age);
        let player = this.invitedPlayers.find(p => p.name == name);
        if (!player) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if (player.age < age) {
            if (age - player.age < 5) {
                return `${name} will sign a contract for ${age - player.age} years with ${this.clubName} in ${this.country}!`;
            } else {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        }
        return `${name} is above age limit!`;
    }

    transferWindowResult() {
        let output = 'Players list:';
        for (let player of this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))) {
            output += `\nPlayer ${player.name}-${player.playerValue}`
        }
        return output;
    }
}