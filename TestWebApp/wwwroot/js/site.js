// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//var player = videojs('my-video', { autoplay: true });
this.onFileChange = function () {
    let file = document.getElementById('file');

    let video = videojs("my-video", { autoplay: true }); // Ref to your video el
    video.src("\\test.mp4");
};
