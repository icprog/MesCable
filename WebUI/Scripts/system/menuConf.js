// ***********************************************************************
// Assembly         : WebUI
// Author           : ychost
// Created          : 09-11-2016
//
// Last Modified By : ychost
// Last Modified On : 09-11-2016
// ***********************************************************************
// <copyright file="menuConf.js" company="cniots">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
$(function (mcAdmin) {
    function serialForm(form) {
        /// <summary>
        /// Serials the form data
        /// </summary>
        /// <param name="form">the form controller</param>
        var jsonObj = {};
        $(form + "  input").each(function (i, v) {
            jsonObj[$(v).attr("name")] = $(v).val();
        })
        $(form + "  select").each(function (i, v) {
            jsonObj[$(v).attr("name")] = $(v).find("option:selected").val();
        })
        return jsonObj;
    }

    function resetForm(form, dropdown) {
        /// <summary>
        /// Resets the form.
        /// </summary>
        /// <param name="form">The form.</param>
        /// <param name="dropdown">The dropdown.</param>
        $(form + "  input").each(function (i, v) {
            $(v).val("");
        });
        $(form + "  select").each(function (i, v) {
            $(v).html("");
        });
        try {
            $(dropdown).cascadingDropdown('destroy');
        } catch (e) {

        }
    }



    function initFormInput(form, data) {
  
        deserialize(form, data);
    }

    function initFormDropdown(select, selParentId, selSubSeq) {
        /// <summary>
        /// Initializes the form dropdown.
        /// </summary>
        /// <param name="select">The select.</param>
        /// <param name="selParentId">The sel parent identifier.</param>
        /// <param name="selSubSeq">The sel sub seq.</param>
        selSubSeq = selSubSeq ? selSubSeq : -1;
        $(select).cascadingDropdown({
            selectBoxes: [
                {
                    selector: '.step1',
                    source: "/System/GetMenuParentList/" + selParentId,
                    usePost: true,
                    useJson: true
                },
                {
                    selector: '.step2',
                    requires: ['.step1'],
                    source: "/System/GetMenuSeqList/" + selSubSeq,
                    useJson: true,
                    usePost: true
                },
            ],
            onReady: function (event, allValues) {

            }

        });

    }

    //submit a new menu
    $("#menu_create_submit").on("click", function () {
        var menu = serialForm("#menu_create_form");
        if (menu.MenuParentID == "" || menu.MenuSeq == "") {
            alert("请选择父菜单和序号")
            return;
        }
        $.post("/System/CreateMenu", { menu: menu }, function (retData) {
            if (retData.Code == RESULT_CODE.OK) {
                swal({
                    title: "恭喜！",
                    text: retData.Content,
                    type: "success",
                }, function () {
                    mcAdmin.reloadCurrentTab()
                });
            } else {
                swal({
                    title: "您的操作有误！",
                    text: retData.Content,
                    type: "error",
                }, function () {
                    mcAdmin.reloadCurrentTab()
                });
            }
        })
        $("#menu_modal_create").modal("hide");
    })

    // delete a menu
    function deleteMenu(menu) {
        swal({
            title: "您确定要删除此菜单吗，此菜单目录下面的子菜单会一并删除",
            text: "删除后将无法恢复，请谨慎操作！",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "删除",
            cancelButtonText: "取消",
            closeOnConfirm: false
        }, function () {
            $.post("/System/DeleteMenu", { menu: menu }, function (retData) {
                if (retData.Code == RESULT_CODE.OK) {
                    swal({
                        title: "删除成功！",
                        text: retData.Content,
                        type: "success"
                    },
                        function () {
                            mcAdmin.reloadCurrentTab();
                        });
                } else {
                    swal({
                        title: "删除失败！",
                        text: retData.Content,
                        type: "error"
                    },
                      function () {
                          mcAdmin.reloadCurrentTab();
                      });

                }
            })
        });
    }


    function editMenu(menu) {
        /// <summary>
        /// Edits the menu.
        /// </summary>
        /// <param name="menu">The menu.</param>
        resetForm("#menu_edit_form", "#menu_edit_dropdown");
        $.post("/System/GetMenuById", { Id: menu.MenuID }, function (retData) {
            if (retData.Code == RESULT_CODE.OK) {
                initFormDropdown("#menu_edit_dropdown", retData.Content.MenuParentID, retData.Content.MenuSeq)
                initFormInput("#menu_edit_form", retData.Content);

            }
        })
        $("#menu_modal_edit").modal();
    }

    // save a edited menu
    $("#menu_edit_submit").on("click", function () {
        var menu = serialForm("#menu_edit_form");
        console.log(menu)
        if (menu.MenuParentID == "" || menu.MenuSeq == "") {
            alert("请选择父菜单和序号")
            return;
        }
        $.post("/System/EditMenu/", { menu, menu}, function(retData) {
            if (retData.Code == RESULT_CODE.OK) {
                swal({
                title: "恭喜！",
                text: retData.Content,
                type: "success",
        }, function () {
                    mcAdmin.reloadCurrentTab()
        });
        } else {
                swal({
            title: "您的操作有误！",
            text: retData.Content,
            type: "error",
        }, function () {
                    mcAdmin.reloadCurrentTab()
        });
        }
        });
        $("#menu_modal_edit").modal("hide");
        })
    //////////////////////////// menu form end//////////////////////


    ////////////////////////////menu tree  start//////////////////////
    $('#menu_div').jstree({
        'core': {
            'check_callback': true,
            'data': [
              mcAdmin.jsTreeData
            ]
        },
        'plugins': ['dnd', 'contextmenu'],
        "contextmenu": {
            "items": {
                "create": null,
                "rename": null,
                "remove": null,
                "ccp": null,
                "新建菜单": {
                    "label": "新建菜单",
                    "action": function (data) {
                        resetForm("#menu_create_form", "#menu_create_dropdown");
                        var selParentId = $(data.reference).attr("id").split("_")[0];
                        initFormDropdown('#menu_create_dropdown', selParentId);

                        $("#menu_modal_create").modal();
                    }
                },
                "删除菜单": {
                    "label": "删除菜单",
                    "action": function (data) {
                        var inst = jQuery.jstree.reference(data.reference),
                         menuNode = inst.get_node(data.reference);
                        var menu = {};
                        menu.MenuName = menuNode.text;
                        menu.MenuID = menuNode.id;
                        deleteMenu(menu)

                    }
                },
                "编辑菜单": {
                    "label": "编辑菜单",

                    "action": function (data) {
                        var inst = jQuery.jstree.reference(data.reference),
                         menuNode = inst.get_node(data.reference);
                        var menu = {};
                        menu.MenuName = menuNode.text;
                        menu.MenuID = menuNode.id;
                        editMenu(menu);
                    }

                }
            }
        }
    });
    $('#menu_div').on("move_node.jstree", function (e, data) {

    });
    ////////////////////////////menu tree  end//////////////////////

    //delete the temporary property
    delete mcAdmin.jsTreeData;
}(window.parent.mcAdmin));