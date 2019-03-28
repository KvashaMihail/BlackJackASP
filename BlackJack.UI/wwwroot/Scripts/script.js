const gameApi = "api/GameApi";

$(document).ready(() => {
    $("#start-round-button").click(() => {
        getMixedCards();
        getPlayers();
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

function getPlayers() {
    $.get({
        url: document.location.origin + "/" + gameApi + "/players",
        type: "Get",
        success: players => {
            console.log(players);
        }
    })
}
