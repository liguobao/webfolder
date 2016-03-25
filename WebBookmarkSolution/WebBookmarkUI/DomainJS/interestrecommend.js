﻿$(function () {
    $("#btnSearch").bind("click", function (e)
    {
        e.preventDefault();
     
        var btnSearch = $("#btnSearch");
        btnSearch.attr("disabled", true);
        btnSearch.html("<i class='am-icon-spinner am-icon-spin'></i>正在努力寻找...");
        var nameOrEmail = $("#searchname").val();
        var divContent = $("#content");


        $.ajax({
            type: "post",
            url: searchURL,
            data: { nameOrEmail: nameOrEmail },
            success:
                function (data) {
                    if (data != null) {
                        btnSearch.html(" <i class='am-icon-search'></i>搜索");
                        divContent.html(data);
                    }
                    btnSearch.html(" <i class='am-icon-search'></i>搜索");
                    btnSearch.attr("disabled", false);
                }
        });
        e.stopPropagation();


    })


    $('body').on("click", "[id='unFollowUser']", function (e) {
        e.preventDefault();
        var $this = $(this);
        var befollowUserID = $this.attr("data-id");;

        $.ajax({
            type: "post",
            url: unFollowUserURL,
            data: { beFollowUserID: befollowUserID },
            success:
                function (result) {
                    if (result.IsSuccess) {
                        $("#followUser").attr("hidden", false);
                    } else {
                        alert(result.ErrorMessage);
                    }

                }
        });
        e.stopPropagation();
    })

    $('body').on('click', "[id='followUser']", function (e) {
        e.preventDefault();
        var $this = $(this);
        var befollowUserID = $this.parent().find("[id='userid']").html();;

        $.ajax({
            type: "post",
            url: followUserURL,
            data: { beFollowUserID: befollowUserID },
            success:
                function (result) {
                    if (result.IsSuccess) {
                        $("#unFollowUser").attr("hidden",false);
                    } else {
                        alert(result.ErrorMessage);
                    }

                }
        });


        e.stopPropagation();

    })



    $('body').on('click', "[id='follow']", function (e)
    {
        e.preventDefault();
        var $this = $(this);
        var befollowUserID = $this.parent().find("[id='userid']").html();;

        $.ajax({
            type: "post",
            url: followUserURL,
            data: { beFollowUserID: befollowUserID },
            success:
                function (result) {
                    if (result.IsSuccess) {
                        $this.removeClass('btn-success');
                        $this.addClass('am-btn-primary');
                        $this.attr('disabled',true);
                        $this.html('<span>已关注</span>');
                    }else
                    {
                        alert(result.ErrorMessage);
                    }
                  
                }
        });


        e.stopPropagation();

    })


    $('body').on('click', "[id='showUserInfo']", function (e) {
        e.preventDefault();
        var $this = $(this);
        var showUserInfoID = $this.attr("data-id");

        $.ajax({
            type: "post",
            url: showUserInfoURL,
            data: { showUserInfoID: showUserInfoID },
            success:
                function (data) {
                    $("#content").html(data);
                }
        });


        e.stopPropagation();

    })


})