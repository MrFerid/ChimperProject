$(function () {

    // Change cover photo
    $(".change-photo").on("click", function () {
        $(".cover-uploader").trigger("click");
    });

    $(".cover-uploader").change(function () {

        let url = $(this).attr("data-url");
        let path = $(this).attr("data-path");
        let data = new FormData();
        data.append("file", $(this).get(0).files[0]);

        $.ajax({
            type: "POST",
            data: data,
            dataType: "json",
            url: url,
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            success: function (result, message, xhr) {
                $(".cover-photo").attr("src", path + result);
            },
            error: function (result, message, xhr) {
                alert(message);
            }
        });
    });


    // Remove from table
    $(".btn-remove").on("click", function (e) {
        e.preventDefault();
        let id = $(this).attr("data-id");
        let url = $(this).attr("data-url");
        $this = $(this);

        if (confirm("Silmek istediyinize eminmisiniz?")) {
            $.ajax({
                type: "POST",
                data: {
                    "id": id
                },
                dataType: "json",
                url: url,
                success: function (result, message, xhr) {
                    $this.parent().parent().remove();
                },
                error: function (result, message, xhr) {
                    alert(message);
                }
            });
        }
    });


    // Disable icons when article selected
    $("input:radio").click(function () {

        if ($("#s2").is(":checked")) {
            $(".custom-radio").val("");
            $(".custom-radio").attr("disabled", true);
            $(".radio-icon").addClass("disabled");
        }
        else {
            $(".custom-radio").attr("disabled", false);
            $(".radio-icon").removeClass("disabled");
        }
    });


});