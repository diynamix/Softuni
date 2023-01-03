function pieceOfPie(pies, firstPie, secondPie) {
    let indexOfFirstPie = pies.indexOf(firstPie);
    let indexOfSecondPie = pies.indexOf(secondPie)
    return pies.slice(indexOfFirstPie, indexOfSecondPie + 1);
}
