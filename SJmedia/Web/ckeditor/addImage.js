function show() {

    $("#ele6")[0].click();
}
function upimg(str) {//上传文件页面上传成功后将返回图片的完整路径名，然后我们就可以将其插入编辑其中 

    if (str == "undefined" || str == "") {
        return;
    }
    str = "<img src='" + str + "'></img>";
    CKEDITOR.instances.ckedit1.insertHtml(str); //调用CKEditor的JS接口将图片插入 
    close();
}
function close() {

    $("#close6")[0].click();
}
$(document).ready(function () {
    new PopupLayer({ trigger: "#ele6", popupBlk: "#blk6", closeBtn: "#close6", useOverlay: true, offsets: { x: 50, y: 0} });
}); 