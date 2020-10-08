/*Downloaded from https://www.codeseek.co/jonathanlcarroll/netflix-style-carousel-aNgRBb */
$('#controlR').click(function () {
    event.preventDefault();
    $('#content').animate({
        marginLeft: "-=400px"
    }, "fast");
});

$('#controlL').click(function () {
    event.preventDefault();
    $('#content').animate({
        marginLeft: "+=400px"
    }, "fast");
});

