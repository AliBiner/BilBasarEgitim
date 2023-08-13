
//Slider
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

//Gallery
$(document).ready(function () {
    $('#gallery-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var formData = new FormData(this);
        var fileInput = document.getElementById("fileInput");
        var file = fileInput.files[0];
        formData.append("ImageUrl", file);

        $.ajax({
            type: "POST",
            url: "/admin/galeri/yukle",
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
    $('#submitButton').click(function () {
        var products = []; // Doldurulacak ürün listesi
        // products listesini doldurmak için gerekli kodlar

        var data = { Products: products };

        $.ajax({
            type: 'POST',
            url: '@Url.Action("PostProducts", "Product")',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (result) {
                // Başarılı yanıt işlemleri
            },
            error: function () {
                // Hata işlemleri
            }
        });
    });
});

//Notice
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

//News
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

//Academic Staff
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