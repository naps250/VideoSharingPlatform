// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

function uploadFiles(inputId) {
    var progressEle = $("#progress");
    progressEle.css("background", "blue");

    var data = document.getElementById(inputId).files[0];

    var formData = new FormData();
    formData.append("Hero", $("#Hero").val());
    formData.append("Tags", $("#Tags").val());

    formData.append("files", data);

    $.ajax({
        url: "Home/UploadVideo",
        data: formData,
        processData: false,
        contentType: "multipart/form-data",
        type: "POST",
        xhr: function () {
            var xhr = new window.XMLHttpRequest();
            xhr.upload.addEventListener("progress", function (evt) {
                if (evt.lengthComputable) {
                    var progress = Math.round((evt.loaded / evt.total) * 100);
                    progressEle.width(progress + "%");
                }
            }, false);
            return xhr;
        },
        success: function (data) {
            if (data.state == 0) {
                progressEle.css("background", "green");
            }
        },
        error: function (data) {

        }
    }); 
}
