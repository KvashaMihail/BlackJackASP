$(window).on('load', function () {
    var heightMain = $(document).height() - $("#nav-id").outerHeight();
    $("#main-container").css("height", heightMain + 'px');
    console.log(heightMain);
});