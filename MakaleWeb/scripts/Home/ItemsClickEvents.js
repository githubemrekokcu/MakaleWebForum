function showPopupEditPost(id) {
    // alert(id);
    $("#popupArticleTitle").val($("#" + id).attr("data-articleTitle"));
    $("#popupArticleContent").val($("#" + id).attr("data-articleContent"));
    $("#popupArticleTitleCode").val($("#" + id).attr("data-articlecode"));

}




$("#btn_sentComment").click(function () {
    var _comment = $("#textarea_comment").val();
    var _sessionlogin = $("#hdnSession").data('usercode');
    var _article = $("#hdnSession").data('article');
    $.ajax({
        url: "/Home/sentComment",
        type: "POST",
        data: { comment: _comment, usercode: _sessionlogin, articlecode: _article },
        success: SuccessResult,
    })
    function SuccessResult(result) {
        if (result == "success") {
            location.reload();
        }

            
    }
})

$("#btn_sendArticle").click(function () {
    var _title = $("#popupArticleTitle").val();
    var _articleContent = $("#popupArticleContent").val();
    var _sessionlogin = $("#hdnSession").data('usercode');
    var _categoryCode = $("#article_category").val();
    var _articleCode = $("#popupArticleTitleCode").val();
    if (_articleCode == "") {
        $.ajax({
            url: "/Home/sendArticle",
            type: "POST",
            data: { title: _title, articlecontent: _articleContent, loginUserCode: _sessionlogin, categoryCode: _categoryCode },
            success: SuccessResult,
        })
        function SuccessResult(result) {
            if (result == "success") {
                location.reload();
            }


        }
    } else {
        $.ajax({
            url: "/Home/updateArticle",
            type: "POST",
            data: { title: _title, articlecontent: _articleContent, articleCode: _articleCode },
            success: SuccessResult,
        })
        function SuccessResult(result) {
            if (result == "success") {
                location.reload();
            }


        }
    }
   

})

$("#ArticleCancel").on("click", function () {
    $(".post-popup.job_post").removeClass("active");
    $(".wrapper").removeClass("overlay");
    $("#popupArticleTitle").val("");
    $("#popupArticleContent").val("");
    $("#popupArticleTitleCode").val("");
    return false;
});


function setLike(_userCode,_articleCode,btnID) {
    //alert(_userCode);
    //alert(_articleCode);
    //alert(btnID);
    var _btnLikeString = $("#" + btnID).text();
    var IsValueBegen = _btnLikeString.substring(_btnLikeString.length - 5, _btnLikeString.length);
    if (IsValueBegen == "Beğen") { // Beğenilmemiş makale
        $.ajax({
            url: "/Home/setLike",
            type: "POST",
            data: { userCode: _userCode, articleCode: _articleCode, like : 'True' },
            success: SuccessResult,
        })
        function SuccessResult(result) {
            if (result == "liked") {
                var _btnLikeCount = _btnLikeString.substring(0, _btnLikeString.length - 5);
                if (_btnLikeCount != "") {
                    _btnLikeCount++;
                }
                $("#" + btnID).text(_btnLikeCount + " Beğendin");
                $("#" + btnID).css("color", "#e44d3a");
            }


        }
    } else { // Beğenilmiş makale
        $.ajax({
            url: "/Home/setLike",
            type: "POST",
            data: { userCode: _userCode, articleCode: _articleCode, like : 'False' },
            success: SuccessResult,
        })
        function SuccessResult(result) {
            if (result == "unliked") {
                var _btnLikeCount = _btnLikeString.substring(0, _btnLikeString.length - 8);
                _btnLikeCount--;
                if (_btnLikeCount == 0) {
                    $("#" + btnID).text(" Beğen");

                } else {
                    $("#" + btnID).text(_btnLikeCount + " Beğen");

                }
                $("#" + btnID).css("color", "#b2b2b2");
            }
        }
    }
}
