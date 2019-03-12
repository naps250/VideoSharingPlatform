// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

function uploadFiles(inputId) {
    var progressEle = $("#progress");
    progressEle.css("background", "blue");

    var data = document.getElementById(inputId).files[0];

    var formData = new FormData();
    formData.append("Hero", $("#Hero").val());
    formData.append("Tags", $("#Tags").val());
    formData.append("__RequestVerificationToken", $('[name="__RequestVerificationToken"]').val());

    formData.append("FileData", data);

    $.ajax({
        url: "Home/UploadVideo",
        data: formData,
        processData: false,
        contentType: false,
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
        success: function (data, xhr) {
            if (xhr == "success" && data != undefined) {
                progressEle.css("background", "green");
                var $videoLink = $('#videoLinkId');
                $videoLink[0].href += "Video/Watch/" + data;
                $videoLink.html($videoLink[0].href);
                $videoLink.parent().css("display", "");
            }
        },
        error: function (data) {

        }
    }); 
}
