/**
 * jQuery Hotspot : A jQuery Plugin to create hotspot for an HTML element
 *
 * Author: Aniruddha Nath
 * Version: 1.0.0
 * 
 * Website: https://github.com/Aniruddha22/jquery-hotspot
 * 
 * Description: A jquery plugin for creating and displaying Hotspots in an HTML element.
 *	It operates in two mode, admin and display. The design of the hotspot created are fully customizable.
 *	User can add their own CSS class to style the hotspots.
 * 
 * License: http://www.opensource.org/licenses/mit-license.php
 *
 * add pixel property to fit the image size
 * add refreshData function to update the spot info when spot changed
 *
 *
 * add API: 
 *        hp.setSpot(spot)   can change the right click spot's info
 *        hp.getSpots()      can get the whole data in the picture
 * add config:
 *        2016-09-13
*             expandAll
*                         true:   expand all hotspot message
*                         false:  hide   all hotspot message
*            2016-09-16    
*             funciton 
*                        spotLeftClickWhenHover (div, spot, spotIndex, e);
 */

; (function ($) {

    // Default settings for the plugin
    var defaults = {

        // Data
        data: {},

        // Hotspot Tag
        tag: 'img',

        // Mode of the plugin
        // Options: admin, display
        mode: 'display',

        // HTML5 LocalStorage variable
        LS_Variable: '__HotspotPlugin_LocalStorage',

        // Hidden class for hiding the data
        hiddenClass: 'hidden',

        // Event on which the data will show up
        // Options: click, hover, none,'mousedown'
        interactivity: 'hover',

        // Buttons' id (Used only in Admin mode)
        done_btnId: 'HotspotPlugin_Done',
        remove_btnId: 'HotspotPlugin_Remove',
        sync_btnId: 'HotspotPlugin_Server',

        // Buttons class
        done_btnClass: 'btn btn-success HotspotPlugin_Done',
        remove_btnClass: 'btn btn-danger HotspotPlugin_Remove',
        sync_btnClass: 'btn btn-info HotspotPlugin_Server',

        // Classes for Hotspots
        hotspotClass: 'HotspotPlugin_Hotspot',
        hotspotAuxClass: 'HotspotPlugin_inc',
        hotspotNormalClass: "HotspotPlugin_Hotspot_Normal",
        hotspotWarnClass: "HotspotPlugin_Hotspot_Warn",
        hotspotErrorClass: "HotspotPlugin_Hotspot_Error",
        hotspotOfflineClass: "HotspotPlugin_Hotspot_Offline",
        hotspotBlockClass: "Hotspot_Block",
        hotspotZIndex: 1000,

        stateNormalCode: 0,
        stateWarnCode: 1,
        stateErrorCode: 2,
        stateOfflineCode: -1,

        // Overlay
        hotspotOverlayClass: 'HotspotPlugin_Overlay',

        expandAll: false,

        // Enable ajax
        ajax: false,

        ajaxOptions: {
            url: ''
        },

        // No. of variables included in the spots
        dataStuff: [
		{
		    'property': 'Title',
		    'default': ''
		},
		{
		    'property': 'Message',
		    'default': ''
		}
        ],
        spotRightClick: function (div, spot, spotIndex, e) {

        },
        spotLeftClickWhenHover: function (div, spot, spotIndex, e) {

        },
        imgRightClick: function (e) {

        }

    };




    var selectSpot;
    var widget;
    //Constructor
    function Hotspot(element, options) {

        // Overwriting defaults with options
        this.config = $.extend(false, {}, defaults, options);
        widget = this;
    
        //extend method
        this.getAllSpots = function() {
            return widget.config.data.Spots;
        };
        this.setSpot = function (Id, newSpot) {
            if (Id != newSpot.Id) {
                return;
            }
            $.each(widget.config.data.Spots, function (spotIndex, val) {
                if (val.Id == Id) {
                    val.Message = newSpot.Message;
                    val.Title = newSpot.Title;
                    refreshData(newSpot, spotIndex);
                    return;
                }
            })
        }

        this.addSpot = function (event, spot) {
            if (spot == null) {
                return;
            }
            addSpotToView(event, spot);

        }
        this.getRelativeXY = function (event) {
            return getSpotRelativeXY(event);
        }

        this.setState = function (spot, newState) {
            var $spot = $("#spot_" + spot.LayoutPictureID);
            var oldClass = stateToClass(spot.State);
            $spot.removeClass(oldClass);
            var newClass = stateToClass(newState)
            $spot.addClass(newClass);
        }
        //ÉèÖÃÄ£¿é×´Ì¬´íÎó
        this.setStateError = function (spot) {
            this.setState(spot, widget.config.stateErrorCode)
        }
        //ÉèÖÃÄ£¿é×´Ì¬Õý³£
        this.setStateNormal = function (spot) {
            this.setState(spot, widget.config.stateNormalCode);
        }

        this.deleteSpot = function (Id) {
            $.each(widget.config.data.Spots, function (spotIndex, val) {
                if (val.Id == Id) {
                    refreshData(null, spotIndex);
                    widget.config.data.Spots.splice(spotIndex, 1);

                    return;
                }
            })
        }
        this.updateSpot = function (id, newSpot) {
            var spot = this.getSpot(id);
            spot = newSpot;
        }
        this.getSelectSpot = function () {
            return selectSpot;
        }
        this.updateSpotMessage = function (id, message) {
            oldSpot = this.getSpot(id);

        }
        this.getSpot = function (id) {
            var spot = {};
            $(this.config.data.Spots).each(function (i, val) {
                if (val.id == id) {
                    spot = val;
                    return;
                }
            })
            return spot;
        }
        this.element = element;
        this.imageEl = element.find(this.config.tag);

        this.imageParent = this.imageEl.parent();

        this.broadcast = '';

   

        // Event API for users
        $.each(this.config, function (index, val) {
            if (typeof val === 'function') {
                widget.element.on(index + '.hotspot', function () {
                    val(widget.broadcast);
                });
            };
        });

        this.init();

    }

    Hotspot.prototype.init = function () {

        this.getData();

        if (this.config.mode != 'admin') {
            return;
        };


        var height = this.imageEl[0].height;
        var width = this.imageEl[0].width;



        var widget = this;
        var data = {};
        data.Spots = [];


    }

    Hotspot.prototype.getData = function () {
        var widget = this;

        if (localStorage.getItem(this.config.LS_Variable) === null && this.config.data.Spots == null) {

            if (this.config.ajax) {
                // Making AJAX call to fetch Data
                var dataObject = {
                    data: {
                        HotspotPlugin_mode: "Retrieve"
                    }
                };
                var ajaxSettings = $.extend({}, this.config.ajaxOptions, dataObject);
                $.ajax(ajaxSettings)
				.done(function (data) {
				    localStorage.setItem(widget.config.LS_Variable, data);
				    var obj = JSON.parse(data);
				    widget.beautifyData();
				})
				.fail(function () {
				    return;
				});
            } else {
                return;
            }

        }

        if (this.config.mode == 'admin' && (localStorage.getItem(this.config.LS_Variable) === null && this.config.data.Spots == null)) {
            return;
        }

        this.beautifyData();

    }

    Hotspot.prototype.beautifyData = function () {
 

        //if (this.config.mode != 'admin' && this.config.data != null) {
        if (this.config.data.Spots != null) {
            var obj = this.config.data;


        } else {
            var raw = localStorage.getItem(this.config.LS_Variable);
            var obj = this.config.data = JSON.parse(raw);
        }

        var spots = obj.Spots;
         
        for (var i = spots.length - 1; i >= 0; i--) {
       
            var el = spots[i];


            if (this.config.interactivity === 'none') {
                var htmlBuilt = $('<div/>')
            } else {
                if (this.config.expandAll == true) {
                    var htmlBuilt = $('<div/>');
                } else {
                    var htmlBuilt = $('<div/>').addClass(this.config.hiddenClass);

                }
            }
            htmlBuilt.addClass(this.config.hotspotBlockClass);

           
            $('<div/>', {
                html: el.Title
            }).addClass('Hotspot_Title').appendTo(htmlBuilt);
  
            $('<div class="Hotspot_Message">' + el.Message + '</div>').appendTo(htmlBuilt);
    
            var imgHeight = this.imageEl[0].height;
            var imgWidth = this.imageEl[0].width;
            var storeHeight = spots[i].PicHeight;//obj.Pixel.height;
            var storeWidth = spots[i].PicWidth;// obj.Pixel.width;
            var offset = $(this.imageEl[0]).offset();
            ;
            var div = $('<div/>', {
                html: htmlBuilt
            }).css({
                'top': el.Y * imgHeight / storeHeight + offset.top + 'px',
                'left': el.X * imgWidth / storeWidth + offset.left + 'px'
            }).addClass(this.config.hotspotClass).appendTo(this.element).attr("spotIndex", i).attr("id", "spot_" + el.LayoutPictureID);


            if (el.State == this.config.stateNormalCode) {
                div.addClass(this.config.hotspotNormalClass);
            } else if (el.State == this.config.stateWarnCode) {
                div.addClass(this.config.hotspotWarnClass);
            } else if (el.State == this.config.stateErrorCode) {
                div.addClass(this.config.hotspotErrorClass);
            } else if (el.State == this.config.stateOfflineCode) {
                div.addClass(this.config.hotspotOfflineClass)
            } else {
                div.addClass(this.config.hotspotErrorClass)

            }


            if (widget.config.interactivity === 'click') {
                div.on(widget.config.interactivity, function (event) {
                    //console.log(widget.config.hiddenClass);
                    $(this).children('div').toggleClass(widget.config.hiddenClass);

                });
                htmlBuilt.css('display', 'block');
            } else if (widget.config.interactivity == 'mousedown') {
                //bind right button click
                div.bind("contextmenu", function () {
                    if (event.button == 2) {
                        var spotIndex = $(this).attr("spotIndex");
                        widget.config.spotRightClick(this, widget.config.data.Spots[spotIndex], spotIndex, event);
                        spotChanged(widget.config.data.Spots[spotIndex], spotIndex);
                    }
                    return true;
                });
                // left button click event
                div.on("click", function (event) {
                    $(this).children('div').toggleClass(widget.config.hiddenClass);

                });


                htmlBuilt.css('display', 'block');
            } else if (widget.config.interactivity = "hover") {
                htmlBuilt.removeClass(this.config.hiddenClass);
                div.on("click", function (event) {
                    var spotIndex = $(this).attr("spotIndex");
                    spotChanged(widget.config.data.Spots[spotIndex], spotIndex);
                    if (typeof (widget.config.spotLeftClickWhenHover) == "function")
                        widget.config.spotLeftClickWhenHover(this, widget.config.data.Spots[spotIndex], spotIndex, event);

                });
            } else {
                htmlBuilt.removeClass(this.config.hiddenClass);
            }

            if (this.config.interactivity === 'none') {
                htmlBuilt.css('display', 'block');
            }

        };


        $("." + this.config.hotspotBlockClass).click(function () {
            /// <summary>
            /// when click the info blok also can change the selected spot
            /// </summary>
            var parent = $(this).parent();
            $(parent).css("z-index", ++widget.config.hotspotZIndex);
            var spotIndex = $(parent).attr("spotIndex");
            spotChanged(widget.config.data.Spots[spotIndex], spotIndex);

        })


    };

    Hotspot.prototype.storeData = function (data) {

        if (data.Spots.length == 0) {
            return;
        };

        var raw = localStorage.getItem(this.config.LS_Variable);
        obj = {};
        obj.Spots = [];
        if (raw) {
            obj = JSON.parse(raw);
        };

        $.each(data.Spots, function (index) {
            var node = data.Spots[index];
            obj.Spots.push(node);

        });

        var pixel = {};
        pixel.width = this.imageEl[0].width;
        pixel.height = this.imageEl[0].height;

        obj.Pixel = pixel;


        localStorage.setItem(this.config.LS_Variable, JSON.stringify(obj));
        //localStorage.setItem(this.config.LS_Variable, JSON.stringify(obj));

        //this.broadcast = 'Saved to LocalStorage';
        //this.element.trigger('afterSave.hotspot');
    };

    Hotspot.prototype.removeData = function () {
        if (localStorage.getItem(this.config.LS_Variable) === null) {
            return;
        };
        if (!confirm("Are you sure you wanna do everything?")) {
            return;
        };
        localStorage.removeItem(this.config.LS_Variable);
        this.broadcast = 'Removed successfully';
        this.element.trigger('afterRemove.hotspot');
    };

    Hotspot.prototype.syncToServer = function () {
        if (localStorage.getItem(this.config.LS_Variable) === null) {
            return;
        };

        if (this.config.ajax) {
            // AJAX call to sync to server
            var widget = this;
            var dataObject = {
                data: {
                    HotspotPlugin_data: localStorage.getItem(this.config.LS_Variable),
                    HotspotPlugin_mode: "Store"
                }
            };
            var ajaxSettings = $.extend({}, this.config.ajaxOptions, dataObject);
            $.ajax(ajaxSettings)
			.done(function () {
			    widget.broadcast = 'Sync was successful';
			    widget.element.trigger('afterSyncToServer.hotspot');
			})
			.fail(function () {
			    widget.broadcast = 'Error';
			    widget.element.trigger('afterSyncToServer.hotspot');
			});
        } else {
            return;
        }
    };

    $.fn.hotspot = function (options) {
        new Hotspot(this, options);
        $(this).bind("contextmenu", function (e) { widget.config.imgRightClick(e); return true; })
        return widget;
    }

    function spotChanged(node, spotIndex) {
        //  widget.setSpot(node);
        //select the click divrefreshData(node,spotIndex);
        selectSpot = node;
        // refreshData(node, spotIndex);
    }

    function refreshData(node, spotIndex) {
        var nodeDiv;
        $(widget.imageParent.find("div")).each(function (i, val) {
            if ($(val).attr("spotIndex") == spotIndex) {
                nodeDiv = val;
                return;
            }
        });
        if (node != null) {
            $($(nodeDiv).find('div')).each(function (i, val) {
                //update title
                if ($(val).attr("class") == "Hotspot_Title") {
                    $(val).text(node.Title);
                }
                if ($(val).attr("class") == "Hotspot_Message") {
                    $(val).text(node.Message);
                }
            })
            //delete div
        } else {
            $(nodeDiv).remove();
        }
    }

    function stateToClass(state) {
        if (state == widget.config.stateNormalCode) {
            return (widget.config.hotspotNormalClass);
        } else if (state == widget.config.stateWarnCode) {
            return (widget.config.hotspotWarnClass);
        } else if (state == widget.config.stateErrorCode) {
            return (widget.config.hotspotErrorClass);
        } else if (state == widget.config.stateOfflineCode) {
            return (widget.config.hotspotOfflineClass)
        }
        return (widget.config.hotspotErrorClass)

    }

    function getSpotRelativeXY(event) {
        var offset = $(widget.imageEl[0]).offset();
        var relativeX = (event.pageX);
        var relativeY = (event.pageY);
        var relativeXY = { X: relativeX - offset.left, Y: relativeY - offset.top };
        return relativeXY;
    }

    function addSpotToView(spot, event) {
        event.preventDefault();
        // var offset = $(widget.imageEl[0]).offset();

        //console.log(offset);
        // var relativeX = (event.pageX);
        //  var relativeY = (event.pageY);

        // console.log(relativeX);
        var dataStuff = widget.config.dataStuff;

        // var dataBuild = { X: relativeX - offset.left, Y: relativeY - offset.top };

        var dataBuild = getSpotRelativeXY(event);
        var relativeX = (event.pageX);
        var relativeY = (event.pageY);
        dataBuild["Title"] = spot.Title;
        dataBuild["Message"] = spot.Message;
        dataBuild["Id"] = spot.Id;
        if (widget.config.data.Spots == null || widget.config.data.Spots == "undefined") {
            widget.config.data.Spots = [];
        }
        widget.config.data.Spots.push(dataBuild);
        // console.log(dataBuild);
        if (widget.config.interactivity === 'none') {
            var htmlBuilt = $('<div/>');
        } else {
            var htmlBuilt = $('<div/>').addClass(widget.config.hiddenClass);
        }


        $.each(dataBuild, function (index, val) {
            if (typeof val === "string") {
                $('<div/>', {
                    html: val
                }).addClass('Hotspot_' + index).appendTo(htmlBuilt);
            };
        });

        var div = $('<div/>', {
            html: htmlBuilt
        }).css({
            'top': relativeY + 'px',
            'left': relativeX + 'px'
        }).addClass(widget.config.hotspotClass + ' ' + widget.config.hotspotAuxClass).appendTo(widget.element).attr("spotIndex", widget.config.data.Spots.length - 1);;
        if (widget.config.interactivity === 'click') {
            div.on(widget.config.interactivity, function (event) {
                $(this).children('div').toggleClass(widget.config.hiddenClass);
            });
            htmlBuilt.css('display', 'block');
        } else if (widget.config.interactivity == 'mousedown') {
            div.on(widget.config.interactivity, function (event) {
                $(this).bind("contextmenu", function () {
                    //right button click	
                    if (event.button == 2) {
                        var spotIndex = $(this).attr("spotIndex");
                        widget.config.spotRightClick(this, widget.config.data.Spots[spotIndex], spotIndex, event);
                        spotChanged(widget.config.data.Spots[spotIndex], spotIndex);
                    }
                    return true;
                });
                //left button click
                if (event.button == 0) {

                    $(this).children('div').toggleClass(widget.config.hiddenClass);
                }
                htmlBuilt.css('display', 'block');

            });
        }
        else {
            htmlBuilt.removeClass(widget.config.hiddenClass);
        }

        if (widget.config.interactivity === 'none') {
            htmlBuilt.css('display', 'block');
        };
        return dataBuild
    }
}(jQuery));