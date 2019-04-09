$(window).on('load', function () {
    var heightMain = $(document).height() - $("#nav-id").outerHeight();
    $("#main-container").css("height", heightMain + 'px');
    console.log(heightMain);
});
$(document).ready(() => {

    $('#games-id > button').on('click', function () {
        Clear();
        $(this).prop(({
            disabled: true
        }));        
        $(this).addClass("active");

        GetRounds($(this).attr("id"));
    });

});

function GetRounds(id) {
    $.ajax({
        url: '/api/Game/GetRounds/' + id,
        cache: false,
        type: 'GET',
        success: roundsViewModel => {
            ShowRounds(roundsViewModel);
            console.log(roundsViewModel);
        }
    });
}

function Clear() {
    $('#games-id > button.active').prop({ disabled: false }).removeClass("active");
    $('#rounds-id').empty();
}

function ShowRounds(roundsViewModel) {
    for (var i = 0; i < roundsViewModel.length; i++) {
        let itemClass = "list-group-item-primary";
        if (!roundsViewModel[i].round.isCompleted) {
            itemClass = "list-group-item-secondary";
        }
        let id = roundsViewModel[i].round.id;
        $('#rounds-id').append('<div id = "round' + id + '" ></div>');
        $('#round'+id).append('<ul id="A' + id + '" class="list-group list-group-horizontal row no-gutters my-row">' +
            '<li class="list-group-item list-group-item-action ' + itemClass + ' col col-sm-1">' +
            '<a href data-toggle="collapse"' +
            'data-target="#B' + id + '" aria-expanded="false"' +
            'aria-controls="B' + id + '">' +
            '# ' + roundsViewModel[i].round.numberRound +
            '</a>' + 
            '</li></ul>');
        ShowRound(roundsViewModel[i]);
    }    
}

function ShowRound(roundM) {
    for (var i = 0; i < roundM.players.length; i++) {
        let itemClass = "";        
        if (roundM.isWins[i]) {
            itemClass = "list-group-item-success";
        }
        if (!roundM.isWins[i]) {
            itemClass = "list-group-item-danger";
        }
        if (roundM.isWins[i] == null) {
            itemClass = "";
        }
        $('#A' + roundM.round.id).append(
            '<li class= "list-group-item ' + itemClass + ' col">' + roundM.players[i] + ': ' + roundM.scores[i] + '</li>');       
    }
    $('#round' + roundM.round.id).append('<ul id="B' + roundM.round.id + '" class="collapse list-group list-group-horizontal row no-gutters my-row">' +
        '<li class="list-group-item col col-sm-1"> cards </li></ul>');
    for (var i = 0; i < roundM.players.length; i++) {
        $('#B' + roundM.round.id).append(
            '<li id="cards-' + roundM.round.id + i + '" class= "list-group-item col"></li>');
        var cards = roundM.cards[i];
        for (var j = 0; j < cards.length; j++) {
            if (cards[j] <= 52) {
                $('#cards-' + roundM.round.id + i).append('<img src="/Images/' + cards[j] + '.png" class="view-img" />');
            }            
        }
    } 
}
