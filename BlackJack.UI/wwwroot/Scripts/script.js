const gameApi = "api/GameApi";
$(document).ready(() => {
    $("#get-cards-button").click(() => {
        GiveNextCard(true);       
    });
    $("#skip-button").click(() => {
        GiveNextCard(false);
    });
});

$(window).on('load', function () {
    StartRound();
});

function StartRound() {
    $("#next-round-button").attr("disabled", true);
    ShowCards();
    ShowCards();
    ShowScores();
}

function ShowCards(flags) {
    $.ajax({
        url: '/api/GameApi/GetCards',
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ GameId: $("#id-game").html(), Flags: flags }),
        success: cards => {
            ShowScores();
            for (var i = 1; i <= cards.length; i++) {
                if (cards[i - 1] <= 52) {
                    $('#body-' + i).append('<img src="/Images/' + cards[i - 1] + '.png" class="card-img" />');
                }
            }
        }
    });
}

function GetCheckedIsFinishRound(flags) {
    $.ajax({
        url: '/api/GameApi/CheckFinishRound',
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ GameId: $("#id-game").html(), Flags: flags }),
        success: isFinished => {
            if (!isFinished) {
                ShowCards(flags);
            }
            if (isFinished) {
                ShowResults();
            }  
        }
    });
}

function GiveNextCard(choice) {
    $.ajax({
        url: '/api/GameApi/GetFlags',
        cache: false,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ GameId: $("#id-game").html(), Choice: choice }),
        success: flags => {
            GetCheckedIsFinishRound(flags);
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

function ShowResults() {
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
        }
    });
}

function ShowScores() {
    $.ajax({
        url: '/api/GameApi/GetScores/' + $("#id-game").html(),
        cache: false,
        type: 'GET',
        success: scores => {
            $("#get-cards-button").attr("disabled", scores[0]>19);
            for (var i = 1; i <= scores.length; i++) {
                $('#score-' + i).empty().append(scores[i - 1]);
            }
        }
    });
}
