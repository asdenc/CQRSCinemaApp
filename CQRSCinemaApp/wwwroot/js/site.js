// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function onLoaderFunc() {
    $(".seatStructure *").prop("disabled", true);
    $(".displayerBoxes *").prop("disabled", true);
}
function takeData() {
    if (($("#Username").val().length == 0) || ($("#Numseats").val().length == 0)) {
        alert("Please Enter your Name and Number of Seats");
    }
    else {
        $(".inputForm *").prop("disabled", true);
        $(".seatStructure *").prop("disabled", false);
        document.getElementById("notification").innerHTML = "<b style='margin-bottom:0px;background:yellow;'>Please Select your Seats NOW!</b>";
    }
}


function updateTextArea() {

    if ($("input:checked").length == ($("#Numseats").val())) {
        $(".seatStructure *").prop("disabled", true);

        var allFNameVals = [];
        var allLNameVals = [];
        var allDobVals = [];
        var allMovieVals = [];
        var allNumberVals = [];
        var allSeatsVals = [];

        //Storing in Array
        allFNameVals.push($("#FirstName").val());
        allLNameVals.push($("#LastName").val());
        allDobVals.push($("#Dob").val());
        allMovieVals.push($("#Movies").val());
        allNumberVals.push($("#Numseats").val());
        $('#seatsBlock :checked').each(function () {
            allSeatsVals.push($(this).val());
        });

        //Displaying 
        $('#nameDisplay').val(allFNameVals);
        $('#nameDisplay').val(allLNameVals);
        $('#dateOfBirthDisplay').val(allDobVals);
        $('#movieDisplay').val(allMovieVals);
        $('#NumberDisplay').val(allNumberVals);
        $('#seatsDisplay').val(allSeatsVals);

    }
    else {
        alert("Please select " + ($("#Numseats").val()) + " seats")
    }
}


function myFunction() {
    alert($("input:checked").length);
}


$(":checkbox").click(function () {
    if ($("input:checked").length == ($("#Numseats").val())) {
        $(":checkbox").prop('disabled', true);
        $(':checked').prop('disabled', false);
    }
    else {
        $(":checkbox").prop('disabled', false);
    }
});


