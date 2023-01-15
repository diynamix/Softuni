function constructionCrew(worker) {
    if (worker.dizziness == true) {
        worker.getHydrated = function () {
            this.levelOfHydrated += this.weight * this.experience * 0.1;
            this.dizziness = false;
        }
        worker.getHydrated()
        delete worker.getHydrated;
    }
    return worker;
}

// function constructionCrew(worker) {
//     if (worker.dizziness == true) {
//         worker.levelOfHydrated += worker.weight * worker.experience * 0.1;
//         worker.dizziness = false;
//     }
//     return worker;
// }
