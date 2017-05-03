// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-01-2016
//
// Last Modified By : ychost
// Last Modified On : 09-01-2016
// ***********************************************************************
// <copyright file="index.js" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <var>The  admin overall object</var>
var mcAdmin = {};

(function ($, mcAdmin) {


    /// <summary>
    /// 
    /// </summary>
    /// <param name="$">The $.</param>
    /// <param name="mcAdmin">The mc admin.</param>
    mcAdmin.genMenuList = function (menuId, rootMenu) {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuId">The menu identifier.</param>
        /// <param name="rootMenu">The root menu.</param>
        var menuTag = $("#" + menuId);
        var firstMenus = rootMenu.SubMenus;
        for (var i = 0; i < firstMenus.length; i++) {
            var first = firstMenus[i];
            var firstTag;
            if (first.SubMenus.length > 0) {
                firstTag = "<li><a href='#'>\
                                     <i class='"+ first.MenuICON + "'></i>\
                                           <span class='nav-label'>"+ first.MenuName + "</span>";
                firstTag += "<span class='fa arrow'></span></a>";
                var secondTag = "<ul class='nav nav-second-level'>";
                for (var j = 0; j < first.SubMenus.length; j++) {
                    var second = first.SubMenus[j];
                    if (second.SubMenus.length > 0) {
                        secondTag += "<li><a href='#'>" + second.MenuName + "<span class='fa arrow'></span></a>";
                        var thirdTag = "<ul class='nav nav-third-level'>";
                        for (var k = 0; k < second.SubMenus.length; k++) {
                            var third = second.SubMenus[k];
                            thirdTag += "<li><a class='J_menuItem' href='" + third.MenuUrl + "'>" + third.MenuName + "</a></li>";
                        }
                        thirdTag += "</ul>"
                        secondTag += thirdTag
                    } else {
                        secondTag += "<li><a class='J_menuItem' href='" + second.MenuUrl + "'>" + second.MenuName + "</a></li>";
                    }
                }

                secondTag += "</ul>"
                firstTag += secondTag;

            } else {
                firstTag = "<li><a class='J_menuItem' href='" + first.MenuUrl + "'>\
                                     <i class='"+ first.MenuICON + "'></i>\
                                           <span class='nav-label'>"+ first.MenuName + "</span>\
                                             </a>";
            }
            firstTag += "</li>"
            menuTag.append(firstTag);
        }
    }

    mcAdmin.dealRetData = function (retData, successFunc, errorFunc) {
        if (retData.Code == RESULT_CODE.OK) {
            if (typeof successFunc == "function") {
                successFunc();
            } else {
                swal({
                    title: "恭喜！",
                    text: retData.Content,
                    type: "success",
                }, function () {
                    mcAdmin.reloadCurrentTab();
                })
            }
        } else {
            swal({
                title: "抱歉！",
                text: retData.Content + "" != "" ? retData.Content : "网络异常",
                type: "error",
            }, function () {
                if (typeof errorFunc == "function") {
                    errorFunc();
                }
            })

        }
    }

    mcAdmin.deleteNullFeature = function (obj) {
        $.each(obj, function (i, v) {
            if (v == null) {
                delete obj[i];
            }
        })
    }

}($, mcAdmin))