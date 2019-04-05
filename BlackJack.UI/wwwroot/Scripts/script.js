const gameApi = "api/GameApi";

$(document).ready(() => {

    $("#get-cards-button").click(() => {
        GiveCards();  
    });

    $("#skip-button").click(() => {
        GiveLastCards();
    });

    $('#next-round-button').click(() => {
        ClearOldRound();
        StartRound();
    });
});

$(window).on('load', function () {
    $("#next-round-button").attr("disabled", true);
    GiveStartCards();
});

function StartRound() {
    $.ajax({
        url: '/api/GameApi/StartNextRound/' + $("#id-game").html(),
        cache: false,
        type: 'POST',
        success: ()=>{
            GiveStartCards();
        }
    });
}

function GiveStartCards() {
    $.ajax({
        url: '/api/GameApi/GetStartCards/' + $("#id-game").html(),
        cache: false,
        type: 'GET',
        success: getViewModel => {
            ShowCards(getViewModel.cards);
            ShowScores(getViewModel.scores);
            var idDealer = getViewModel.cards[0].length;
            $('#body-' + idDealer).find("img").eq(1).css('display', 'none');
            $('#body-' + idDealer).append('<img id="" src="/Images/0.png" class="card-img" />');
            $('#score-' + idDealer).css('display', 'none');
        }
    });
}

function ShowCards(cards) {
    for (var i = 0; i < cards.length; i++) {
        for (var j = 1; j <= cards[i].length; j++) {
            if (cards[i][j - 1] <= 52) {
                $('#body-' + j).append('<img id="" src="/Images/' + cards[i][j - 1] + '.png" class="card-img" />');
            }
        }
    }   
}

function GiveCards() {
    $.ajax({
        url: '/api/GameApi/GetCards/' + $("#id-game").html(),
        cache: false,
        type: 'GET',
        success: getViewModel => {            
            ShowCards(getViewModel.cards);
            ShowScores(getViewModel.scores);  
            if (getViewModel.isFinishRound) {
                FinishRound(getViewModel.cards[0].length);
            }
            var scorePlayer = getViewModel.scores[0];
            if (scorePlayer > 20) {
                GiveLastCards();
            }
        }
    });
}

function GiveLastCards() {
    $.ajax({
        url: '/api/GameApi/GetLastCards/' + $("#id-game").html(),
        cache: false,
        type: 'GET',
        success: getViewModel => {
            ShowCards(getViewModel.cards);
            ShowScores(getViewModel.scores);
            FinishRound(getViewModel.cards[0].length);
        }
    });
}

function CardSetLose(i) {
    $('#result-' + i).append("Lose!");
    $('#footer-' + i).removeClass("alert-success").addClass("alert-danger");
    $('#card-'+i).css("border-color", "red")
}

function CardSetWin(i) {
    $('#result-' + i).append("Win!");
    $('#footer-' + i).removeClass("alert-secondary").addClass("alert-success");
    $('#card-' + i).css("border-color", "green")
}

function FinishRound(id) {
    isFinishRound = true;
    $.ajax({
        url: '/api/GameApi/GetFlagsIsWin/' + $("#id-game").html(),
        cache: false,
        type: 'GET',
        success: flags => {
            $("#next-round-button").attr("disabled", false);
            $("#skip-button").attr("disabled", true);
            $("#get-cards-button").attr("disabled", true);
            for (var i = 1; i <= flags.length; i++) {
                if (flags[i-1]) {
                    CardSetWin(i);
                }
                if (!flags[i-1]) {
                    CardSetLose(i);
                }               
            }
            $('#body-' + id).find("img").eq(1).css('display', 'block');
            $('#body-' + id).find("img").eq(2).css('display', 'none');
            $('#score-' + id).css('display', 'block');
        }
    });
}

function ShowScores(scores) {
    for (var i = 1; i <= scores.length; i++) {
        $('#score-' + i).empty().append(scores[i - 1]);
    }
}

function ClearOldRound() {
    $("#next-round-button").attr("disabled", true); 
    $("#skip-button").attr("disabled", false);
    $("#get-cards-button").attr("disabled", false);
    $(".card-body, .card-font-large").empty();
    $(".card-score").append("0");
    $(".card-footer").removeClass("alert-success alert-danger").addClass("alert-secondary");
    $(".card").css("border-color", "#808080");
}
