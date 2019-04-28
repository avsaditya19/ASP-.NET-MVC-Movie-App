$(document).ready(function () {
    $("#add-actor").click(function () {
        $("#actor-form").show();
    });
    $("#actor-submit").click(function (e) {
        e.preventDefault();
        $.ajax({
            method: "post",
            dataType: "json",
            url: "Actors/Create",
            data: $("#actor-form").serialize(),
            success: function (response) {
                $("#ActorIDs").append($('<option>', {
                    value: response.ID,
                    text: response.Name
                }));
            },
            error: function () {
            }
        });
    });
    $("#add-producer").click(function () {
        $("#producer-form").show();
    });
    $("#producer-submit").click(function (e) {
        e.preventDefault();
        $.ajax({
            method: "post",
            dataType: "json",
            url: 'Producers/Create',
            data: $('#producer-form').serialize(),
            success: function (response) {
                $("#ProducerId").append($('<option>', {
                    value: response.ID,
                    text: response.Name
                }));
            },
            error: function () {

            }
        });
    });
    //$(function () {
    //    $('#fileupload').fileupload({
    //        dataType: 'json',
    //        done: function (e, data) {
    //            $.each(data.result.files, function (index, file) {
    //                $('<p/>').text(file.name).appendTo(document.body);
    //                alert('File Upload');
    //            });
    //        }
    //    });
    //});
  
});