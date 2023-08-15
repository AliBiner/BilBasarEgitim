
//Slider
$(document).ready(function () {
    $('#slider-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        
     
        var fileInput = document.getElementById("fileInput");
        var isValid = true;
        var maxFileSize = 5*1024*1024;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (isValid == true)
        {
            var formData = new FormData(this);
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
        }
      
    });
});

//Gallery
$(document).ready(function () {
    $('#gallery-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var fileInput = document.getElementById("fileInput");

        var maxFileSize = 5*1024*1024;
        var isValid = true;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 49) {
            document.getElementById("description-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
       
        if (isValid == true) {
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
        }
       
    });
});

//Document
$(document).ready(function () {
    $('#document-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var isValid = true;
        var fileInput = document.getElementById("fileInput");

        var maxFileSize = 5 * 1024 * 1024;
        var isValid = true;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 49) {
            document.getElementById("description-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
        if (isValid == true) {
            var formData = new FormData(this);
            var fileInput = document.getElementById("fileInput");
            var file = fileInput.files[0];
            formData.append("File", file);

            $.ajax({
                type: "POST",
                url: "/admin/dokumanlar/yukle",
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
        }

    });
});

//Send Email
$(document).ready(function () {
    $('#sendEmail-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        function validateEmail(email) {
            var pattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
            return pattern.test(email);
        }
        var email = document.getElementById("sendEmail").value;
        var isValid = true;

        if (email === "") {
            document.getElementById("sendEmail-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (validateEmail(email)) {
            document.getElementById("sendEmail-error").textContent = "";
            
        }
        else {
            document.getElementById("sendEmail-error").textContent = "Lütfen Geçerli Bir E-Posta Adresi Giriniz.";
            isValid = false;
        }
        if (isValid == true) {
            var formData = new FormData(this);

            $.ajax({
                type: "POST",
                url: "/admin/email",
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
        }

    });
});
//Profile Update
$(document).ready(function () {
    $('#form-profile-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
       
        var email = document.getElementById("yourEmail").value;
        var fullname = document.getElementById("full-name").value;
        var isValid = true;
       
        if (fullname === "") {
            document.getElementById("full-name-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else {
            document.getElementById("full-name-error").textContent = "";
           
        }
        if (email === "") {
            document.getElementById("your-email-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else{
            document.getElementById("your-email-error").textContent = "";

        }
      
        if (isValid == true) {
            var formData = new FormData(this);

            $.ajax({
                type: "POST",
                url: "/admin/profil/guncelle",
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
        }

    });
});
$(document).ready(function () {
    $('#change-password').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var currentPassword = document.getElementById("currentPassword").value;
        var newPassword = document.getElementById("newPassword").value;
        var renewPassword = document.getElementById("renewPassword").value;
        var isValid = true;

        if (currentPassword === "") {
            document.getElementById("currentPassword-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else {
            document.getElementById("currentPassword-error").textContent = "";

        }
        if (newPassword === "") {
            document.getElementById("newPassword-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else {
            document.getElementById("newPassword-error").textContent = "";

        }
        if (renewPassword === "") {
            document.getElementById("renewPassword-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else {
            document.getElementById("renewPassword-error").textContent = "";

        }
        if (newPassword !== renewPassword) {
            document.getElementById("renewPassword-error").textContent = "Yeni Şifreler Eşleşmiyor";
            isValid = false;
        } else {
            document.getElementById("renewPassword-error").textContent = "";
        }

        if (isValid == true) {
            var formData = new FormData(this);

            $.ajax({
                type: "POST",
                url: "/admin/profil/sifre-degister",
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
        }

    });
});
//TrainingPublication
$(document).ready(function () {
    $('#publication-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var isValid = true;
        var fileInput = document.getElementById("fileInput");

        var maxFileSize = 5 * 1024 * 1024;
        var isValid = true;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 49) {
            document.getElementById("description-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
        if (isValid == true)
        {
            var formData = new FormData(this);
            var fileInput = document.getElementById("fileInput");
            var file = fileInput.files[0];
            formData.append("ImageUrl", file);

            $.ajax({
                type: "POST",
                url: "/admin/yayinlar/yukle",
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
        }
        
    });
});
//Notice
$(document).ready(function () {
    $('#notice-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var head = document.getElementById("head").value;
        var isValid = true;
        var fileInput = document.getElementById("fileInput");

        var maxFileSize = 5 * 1024 *1024;
        var isValid = true;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 143) {
            document.getElementById("description-error").textContent = "Max. 143 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
        if (head === "") {
            document.getElementById("head-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
            console.log("burada");
        }
        else if (head.length > 49) {
            document.getElementById("head-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("head-error").textContent = "";
        }
        if (isValid == true)
        {
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
        }
       
    });
});

$(document).ready(function () {
    $('#notice-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var header = document.getElementById("head").value;
        var isValid = true;
        var fileInput = document.getElementById("fileInput");

        var maxFileSize = 5 * 1024 *1024;
        var isValid = true;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 143) {
            document.getElementById("description-error").textContent = "Max. 143 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
        if (header === "") {
            document.getElementById("head-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (header.length > 49) {
            document.getElementById("head-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("head-error").textContent = "";
        }
        if (isValid == true)
        {
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
        }
       
    });
});

//News
$(document).ready(function () {
    $('#news-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var isValid = true;
        var fileInput = document.getElementById("fileInput");
        var maxFileSize = 5 * 1024 *1024;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 49) {
            document.getElementById("description-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
        if (isValid == true) {
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
            });}
        
    });
});

$(document).ready(function () {
    $('#news-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin
        var description = document.getElementById("description").value;
        var fileInput = document.getElementById("fileInput");
        var isValid = true;
        var maxFileSize = 5 * 1024 * 1024;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (description === "") {
            document.getElementById("description-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (description.length > 49) {
            document.getElementById("description-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("description-error").textContent = "";
        }
        if (isValid == true) {
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
        }
       
    });
});

//Academic Staff
$(document).ready(function () {
    $('#academic-staff-upload').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var name = document.getElementById("yourName").value;
        var surname = document.getElementById("yourSurname").value;
        var educatorField = document.getElementById("educatorfield").value;
        var fileInput = document.getElementById("fileInput");
        var isValid = true;
        var maxFileSize = 5 * 1024 * 1024;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (name === "" ) {
            document.getElementById("name-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (name.length > 143) {
            document.getElementById("name-error").textContent = "Max. 143 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("name-error").textContent = "";
        }
        if (surname === "" ) {
            document.getElementById("surname-error").textContent = "Bu Alan Boş Bırakılamaz";
            isValid = false;
        }
        else if (surname.length > 143) {
            document.getElementById("surname-error").textContent = "Max. 143 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("surname-error").textContent = "";
        }
        if (educatorField === "") {
            document.getElementById("educator-error").textContent = "Bu Alan Boş Bırakılamaz";
            isValid = false;
        }
        else if (educatorField.length > 49) {
            document.getElementById("educator-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("educator-error").textContent = "";
           
        }
        if (isValid == true) {
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
        }
      
      
    });
});

$(document).ready(function () {
    $('#academic-staff-update').submit(function (event) {
        event.preventDefault(); // () parantezlerini ekleyin

        var name = document.getElementById("yourName").value;
        var surname = document.getElementById("yourSurname").value;
        var educatorField = document.getElementById("educatorfield").value;
        var fileInput = document.getElementById("fileInput");
        var isValid = true;
        var maxFileSize = 5 * 1024 * 1024;
        if (fileInput.files.length > 0) {
            var filesize = fileInput.files[0].size;
            if (filesize > maxFileSize) {
                document.getElementById("fileInput-error").textContent = "Max. 5 Mb Dosya Yüklenebilir.";
                isValid = false;
            }
            else {
                document.getElementById("fileInput-error").textContent = "";
            }
        }
        if (name === "") {
            document.getElementById("name-error").textContent = "Bu Alan Boş Bırakılamaz.";
            isValid = false;
        }
        else if (name.length > 143) {
            document.getElementById("name-error").textContent = "Max. 143 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("name-error").textContent = "";
        }
        if (surname === "") {
            document.getElementById("surname-error").textContent = "Bu Alan Boş Bırakılamaz";
            isValid = false;
        }
        else if (surname.length > 143) {
            document.getElementById("surname-error").textContent = "Max. 143 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("surname-error").textContent = "";
        }
        if (educatorField === "") {
            document.getElementById("educator-error").textContent = "Bu Alan Boş Bırakılamaz";
            isValid = false;
        }
        else if (educatorField.length > 49) {
            document.getElementById("educator-error").textContent = "Max. 49 Karakter Olmalıdır.";
            isValid = false;
        }
        else {
            document.getElementById("educator-error").textContent = "";
        }
        if (isValid == true) {
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
        }
        
    });
});