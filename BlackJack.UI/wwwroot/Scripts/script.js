const gameApi = "api/GameApi";

$(document).ready(() => {
    $("#start-round-button").click(() => {
        getMixedCards();
    });
});

function getMixedCards() {
    $.get({
        url: document.location.origin + "/" + gameApi,
        type: "Get",
        cache: false,
        success: card => {
            console.log(card);
        }
    })
}

function startRound() {

}

