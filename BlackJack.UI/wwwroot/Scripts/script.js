const gameApi = "api/GameApi";

$(document).ready(() => {
    $("#get-cards-button").click(() => {
        GetCards();
    });
});

//$(document).load(function() {

//})
$(window).on('load', function () {
    GetCards();
    GetCards();
    GetScores();
});

function GetCards() {
    $.ajax({
        url: '/api/GameApi/GetCards',
        type: 'GET',
        dataType: 'json',
        data: "gameId=" + $("#id-game").html(),
        success: cards => {
            ShowCards(cards);
            GetScores();
        }
    });
}

function GetScores() {
    $.ajax({
        url: '/api/GameApi/GetScores',
        type: 'GET',
        dataType: 'json',
        data: "gameId=" + $("#id-game").html(),
        success: scores => {
            ShowScores(scores);
        }
    });
}

function ShowScores(scores) {
    for (var i = 1; i <= scores.length; i++) {
        $('#score-' + i).empty().append(scores[i-1]);
    }
}

function ShowCards(cards) {
    for (var i = 1; i <= cards.length; i++) {
        $('#body-' + i).append('<img src="/Images/' + cards[i - 1] + '.png" class="card-img" />');
    }
}
