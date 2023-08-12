////document.getElementById("slider-upload").addEventListener("submit", function(event) {
////    event.preventDefault();

////    var fromData = new formData(this);
////    $.ajax({
////        type: "POST",
////        url: "/admin/slider/{id}",
////        data: formData,
////        processData: false,
////        contentData: false,
////        success: function (response) {
////            alert(response);
////        },
////        error: function() {
////            alert("Bir hata oluştu.");
////        }
////    });
////});


$(document).ready(function () {
    $('#slider-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("ImageUrl", file);

        $.ajax({
            type: "POST",
            url: "/admin/slider/yukle",
            data: formData,
            processData: false,
            contentType: false, // contentType olarak düzeltin
            success: function (response) {
                $('#errorModalMessage').html(response);
                $('#errorModal').modal('show');
                
            },
            error: function () {
                $('#errorModalMessage').html(response);
                $('#errorModal').modal('show');
            }
        });
    });
});