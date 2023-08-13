

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

$(document).ready(function () {
    $('#notice-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("NoticeUrl", file);

        $.ajax({
            type: "POST",
            url: "/admin/duyurular/yukle",
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

$(document).ready(function () {
    $('#notice-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("NoticeUrl", file);

        $.ajax({
            type: "POST",
            url: "/admin/duyurular/guncelle",
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

$(document).ready(function () {
    $('#news-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("NewsUrl", file);

        $.ajax({
            type: "POST",
            url: "/admin/haberler/yukle",
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

$(document).ready(function () {
    $('#news-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("NewsUrl", file);

        $.ajax({
            type: "POST",
            url: "/admin/haberler/guncelle",
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

$(document).ready(function () {
    $('#academic-staff-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("file", file);

        $.ajax({
            type: "POST",
            url: "/admin/akademik-kadro/yukle",
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

$(document).ready(function () {
    $('#academic-staff-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("file", file);

        $.ajax({
            type: "POST",
            url: "/admin/akademik-kadro/guncelle",
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