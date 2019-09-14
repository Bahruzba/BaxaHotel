$(document).ready(function() {
    "use strict";
    
    // sidebar navigation
    $('.sidebar').metisMenu();

    setTimeout(function () {
        $('.page-loader-wrapper').fadeOut();
    }, 100);
    
    $(window).bind("resize", function () {
        if ($(this).width() < 1201) {
            $("body").addClass("layout-fullwidth");
        } else {
            $("body").removeClass("layout-fullwidth");
        }
    }).trigger('resize');

    
    // right side bar
	$('a.rightbar_btn').on('click', function() {
        $('.right_sidebar').toggleClass('open');
    });

    // navbar-toggle
    $('.menu_toggle').on('click', function () {
        $('body').toggleClass('toggle_menu_active');
    });

    // Dark bg sidebar
    $(".switch-dark").on('change',function() {
        if(this.checked) {
            $("body").addClass('dark-sidebar');
        }else{
            $("body").removeClass('dark-sidebar');
        }
    });

    // mini sidebar 
    $(".switch-sidebar").on('change',function() {
        if(this.checked) {
            $("body").addClass('mini-sidebar');
        }else{
            $("body").removeClass('mini-sidebar');
        }
    });

    // Skin changer
	$('.choose-skin li').on('click', function() {
	    var $body = $('body');
	    var $this = $(this);
  
	    var existTheme = $('.choose-skin li.active').data('theme');
	    $('.choose-skin li').removeClass('active');
	    $body.removeClass('theme-' + existTheme);
	    $this.addClass('active');
	    $body.addClass('theme-' + $this.data('theme'));
    }); 

    // toggle fullwidth layout
	$('.btn-toggle-fullwidth').on('click', function() {
		if(!$('body').hasClass('layout-fullwidth')) {
			$('body').addClass('layout-fullwidth');
			$(this).find(".fa").toggleClass('fa-arrow-left fa-arrow-right');

		} else {
			$('body').removeClass('layout-fullwidth');
			$(this).find(".fa").toggleClass('fa-arrow-left fa-arrow-right');
		}
	});

	// off-canvas menu toggle
	$('.menu_toggle').on('click', function() {
		$('body').toggleClass('offcanvas-active');
	});

    /*
	$('#main-content').on('click', function() {
        $('body').removeClass('toggle_menu_active');
        $('body').removeClass('offcanvas-active');
	});
    */

    $(window).on('load', function() {
		// for shorter main content
		if($('#main-content').height() < $('#left-sidebar').height()) {
			$('#main-content').css('min-height', $('#left-sidebar').innerHeight() - $('footer').innerHeight());
		}
	});
});

$(window).on('load resize', function () {

    // Background image holder - Static hero with fullscreen autosize
    if ($('.spotlight').length) {
        $('.spotlight').each(function () {

            var $this = $(this);
            var holderHeight;

            if ($this.data('spotlight') == 'fullscreen') {
                if ($this.data('spotlight-offset')) {
                    var offsetHeight = $('body').find($this.data('spotlight-offset')).height();
                    holderHeight = $(window).height() - offsetHeight;
                }
                else {
                    holderHeight = $(window).height();
                }


                if ($(window).width() > 991) {
                    $this.find('.spotlight-holder').css({
                        'height': holderHeight + 'px'
                    });
                }
                else {
                    $this.find('.spotlight-holder').css({
                        'height': 'auto'
                    });
                }
            }
        })
    }
}),
    $(document).ready(function () {

        // Plugins init
        $(".scrollbar-inner")[0] && $(".scrollbar-inner").scrollbar().scrollLock();
        $('[data-stick-in-parent="true"]')[0] && $('[data-stick-in-parent="true"]').stick_in_parent();
        $('.selectpicker')[0] && $('.selectpicker').selectpicker();
        $('.textarea-autosize')[0] && autosize($('.textarea-autosize'));
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').each(function () {
            var popoverClass = '';
            if ($(this).data('color')) {
                popoverClass = 'popover-' + $(this).data('color');
            }
            $(this).popover({
                trigger: 'focus',
                template: '<div class="popover ' + popoverClass + '" role="tooltip"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
            })
        });


        // Floating label
        $('.form-control').on('focus blur', function (e) {
            $(this).parents('.form-group').toggleClass('focused', (e.type === 'focus' || this.value.length > 0));
        }).trigger('blur');


        // Custom input file
        $('.custom-input-file').each(function () {
            var $input = $(this),
                $label = $input.next('label'),
                labelVal = $label.html();

            $input.on('change', function (e) {
                var fileName = '';

                if (this.files && this.files.length > 1)
                    fileName = (this.getAttribute('data-multiple-caption') || '').replace('{count}', this.files.length);
                else if (e.target.value)
                    fileName = e.target.value.split('\\').pop();

                if (fileName)
                    $label.find('span').html(fileName);
                else
                    $label.html(labelVal);
            });


            // Firefox bug fix
            $input.on('focus', function () {
                $input.addClass('has-focus');
            })
                .on('blur', function () {
                    $input.removeClass('has-focus');
                });
        });


        // NoUI Slider
        if ($(".input-slider-container")[0]) {
            $('.input-slider-container').each(function () {

                var slider = $(this).find('.input-slider');
                var sliderId = slider.attr('id');
                var minValue = slider.data('range-value-min');
                var maxValue = slider.data('range-value-max');

                var sliderValue = $(this).find('.range-slider-value');
                var sliderValueId = sliderValue.attr('id');
                var startValue = sliderValue.data('range-value-low');

                var c = document.getElementById(sliderId),
                    d = document.getElementById(sliderValueId);

                noUiSlider.create(c, {
                    start: [parseInt(startValue)],
                    connect: [true, false],
                    //step: 1000,
                    range: {
                        'min': [parseInt(minValue)],
                        'max': [parseInt(maxValue)]
                    }
                });

                c.noUiSlider.on('update', function (a, b) {
                    d.textContent = a[b];
                });
            })

        }

        if ($("#input-slider-range")[0]) {
            var c = document.getElementById("input-slider-range"),
                d = document.getElementById("input-slider-range-value-low"),
                e = document.getElementById("input-slider-range-value-high"),
                f = [d, e];

            noUiSlider.create(c, {
                start: [parseInt(d.getAttribute('data-range-value-low')), parseInt(e.getAttribute('data-range-value-high'))],
                connect: !0,
                range: {
                    min: parseInt(c.getAttribute('data-range-value-min')),
                    max: parseInt(c.getAttribute('data-range-value-max'))
                }
            }), c.noUiSlider.on("update", function (a, b) {
                f[b].textContent = a[b]
            })
        }

        // Scroll to anchor with animation
        $('.scroll-me, .toc-entry a').on('click', function (event) {
            var hash = $(this).attr('href');
            var offset = $(this).data('scroll-to-offset') ? $(this).data('scroll-to-offset') : 0;

            // Animate scroll to the selected section
            $('html, body').stop(true, true).animate({
                scrollTop: $(hash).offset().top - offset
            }, 600);

            event.preventDefault();
        });

    }),
    $(document).ready(function () {
        $("body").on("click", "[data-action]", function (e) {

            e.preventDefault();

            var $this = $(this);
            var action = $this.data('action');
            var target = '';

            switch (action) {
                case "offcanvas-open":
                    target = $this.data("target"), $(target).addClass("open"), $("body").append('<div class="body-backdrop" data-action="offcanvas-close" data-target=' + target + " />");
                    break;
                case "offcanvas-close":
                    target = $this.data("target"), $(target).removeClass("open"), $("body").find(".body-backdrop").remove();
                    break;

                case 'aside-open':
                    target = $this.data('target');
                    $this.data('action', 'aside-close');
                    $this.addClass('toggled');
                    $(target).addClass('toggled');
                    $('.content').append('<div class="body-backdrop" data-action="aside-close" data-target=' + target + ' />');
                    break;


                case 'aside-close':
                    target = $this.data('target');
                    $this.data('action', 'aside-open');
                    $('[data-action="aside-open"], ' + target).removeClass('toggled');
                    $('.content, .header').find('.body-backdrop').remove();
                    break;
            }
        })


        $("#BtnSearchCustomer").click(function () {
            var name = $("#SearchCustomer input").val();
            $.ajax({
                url: "/customers/getlist?name=" + name,
                type: "get",
                dataType: "json",
                success: (function (response) {
                    $(".customers tbody tr").remove();
                    for (var i = 0; i < response.length; i++) {
                        var tr = $("<tr></tr>");
                        $(".customers tbody").append(tr);
                        var td1 = $("<td></td>");
                        td1.text(i + 1);
                        $(".customers tbody tr:last-child").append(td1);
                        var td2 = $("<td></td>");
                        td2.text(response[i].FullName);
                        $(".customers tbody tr:last-child").append(td2);
                        var td3 = $("<td></td>");
                        td3.text(response[i].PhoneNumber);
                        $(".customers tbody tr:last-child").append(td3);
                        var td4 = $("<td></td>");
                        td4.text(response[i].Date+" il");
                        $(".customers tbody tr:last-child").append(td4);
                        var td5 = $("<td></td>");
                        if (response[i].Reservations.length == 0) {
                            td5.text("Yoxdur");
                        } else {
                            td5.text(response[i].Reservations.length + " rezervasiya");
                        }
                        $(".customers tbody tr:last-child").append(td5);
                        var td6 = $("<td></td>");
                        if (response[i].Status == true) {
                            td6.text("Aktiv").addClass("stat");
                        } else {
                            td6.text("Passiv").addClass("stat text-danger");
                        }
                        $(".customers tbody tr:last-child").append(td6);

                        var td7 = $("<td></td>");
                        $(".customers tbody tr:last-child").append(td7);
                        var a1 = $("<a></a>");
                        a1.text("Düzəliş et");
                        a1.addClass("btn btn-primary btn-sm");
                        a1.attr("href", "/customers/update/" + response[i].Id);
                        $(".customers tbody tr:last-child td:last-child").append(a1);

                        var td8 = $("<td></td>");
                        $(".customers tbody tr:last-child").append(td8);
                        var a2 = $("<a></a>");
                        if (response[i].Status == true) {
                            a2.text("Passivləşdir");
                            a2.addClass("btn activate btn-warning text-white btn-sm");

                        } else {
                            $(".customers tbody tr:last-child").addClass("table-dark");
                            a2.text("Aktivləşdir");
                            a2.addClass("btn btn-success activate text-white btn-sm").parent().siblings(".stat").addClass("text-danger").parent().addClass("table-dark");
                        }
                        a2.attr("name", "/customers");
                        a2.attr("value", response[i].Id);
                        $(".customers tbody tr:last-child td:last-child").append(a2);

                        var td9 = $("<td></td>");
                        $(".customers tbody tr:last-child").append(td9);
                        var a3 = $("<a></a>");
                        a3.text("Sil");
                        a3.addClass("btn btn-danger text-white btn-sm");
                        a3.attr("name", "/customers");
                        a3.attr("value", response[i].Id);
                        $(".customers tbody tr:last-child td:last-child").append(a3);

                        $(".customers tbody td").addClass("text-center");
                    }
                }),
                error: (function (error) {
                    console.log(error);
                })
            })
        })

        $("#BtnSearchUser").click(function () {
            var name = $("#SearchUser input").val();
            $.ajax({
                url: "/users/getlist?name=" + name,
                type: "get",
                dataType: "json",
                success: (function (response) {
                    $(".users tbody tr").remove();
                    for (var i = 0; i < response.length; i++) {
                        var tr = $("<tr></tr>");
                        $(".users tbody").append(tr);
                        var td1 = $("<td></td>");
                        td1.text(i + 1);
                        $(".users tbody tr:last-child").append(td1);
                        var td2 = $("<td></td>");
                        td2.text(response[i].FullName);
                        $(".users tbody tr:last-child").append(td2);
                        var td3 = $("<td></td>");
                        td3.text(response[i].UserName);
                        $(".users tbody tr:last-child").append(td3);
                        var td4 = $("<td></td>");
                        td4.text(response[i].Date +" il");
                        $(".users tbody tr:last-child").append(td4);
                        var td5 = $("<td></td>");
                        if (response[i].Type == 0) {
                            td5.text("admin");
                        } else if (response[i].Type == 1) {
                            td5.text("restotan");
                        } else if (response[i].Type == 2) {
                            td5.text("qəbul");
                        }
                        $(".users tbody tr:last-child").append(td5);
                        var td6 = $("<td></td>");
                        if (response[i].Status == true) {
                            td6.text("Aktiv").addClass("stat");
                        } else {
                            td6.text("Passiv").addClass("stat text-danger");
                        }
                        $(".users tbody tr:last-child").append(td6);


                        if (response[i].Type != 0) {
                            var td7 = $("<td></td>");
                            $(".users tbody tr:last-child").append(td7);
                            var a1 = $("<a></a>");
                            a1.text("Düzəliş et");
                            a1.addClass("btn btn-primary btn-sm");
                            a1.attr("href", "/users/update/" + response[i].Id);
                            $(".users tbody tr:last-child td:last-child").append(a1);

                            var td8 = $("<td></td>");
                            $(".users tbody tr:last-child").append(td8);
                            var a2 = $("<a></a>");
                            if (response[i].Status == true) {
                                a2.text("Passivləşdir");
                                a2.addClass("btn btn-warning activate text-white btn-sm");
                            } else {
                                a2.text("Aktivləşdir");
                                a2.addClass("btn btn-success activate text-white btn-sm").parent().siblings(".stat").addClass("text-danger").parent().addClass("table-dark");
                                $(".users tbody tr:last-child").addClass("table-dark");
                            }
                            a2.attr("name", "/users");
                            a2.attr("value", response[i].Id);
                            $(".users tbody tr:last-child td:last-child").append(a2);

                            var td9 = $("<td></td>");
                            $(".users tbody tr:last-child").append(td9);
                            var a3 = $("<a></a>");
                            a3.text("Sil");
                            a3.addClass("btn btn-danger text-white btn-sm");
                            a3.attr("name", "/users");
                            a3.attr("value", response[i].Id);
                            $(".users tbody tr:last-child td:last-child").append(a3);
                        } else {
                            var td7 = $("<td></td>");
                            $(".users tbody tr:last-child").append(td7);
                            var td8 = $("<td></td>");
                            $(".users tbody tr:last-child").append(td8);
                            var td9 = $("<td></td>");
                            $(".users tbody tr:last-child").append(td9);
                        }
                        $(".users tbody td").addClass("text-center");
                    }

                }),
                error: (function (error) {
                    console.log(error);
                })
            })
        })

        $("#BtnSearchRoom").click(function () {
            var name = $("#SearchRoom input").val();
            $.ajax({
                url: "/rooms/getlist?name=" + name,
                type: "get",
                dataType: "json",
                success: (function (response) {
                    $(".rooms tbody tr").remove();
                    for (var i = 0; i < response.length; i++) {
                        var tr = $("<tr></tr>");
                        $(".rooms tbody").append(tr);
                        var td1 = $("<td></td>");
                        td1.text(i + 1);
                        $(".rooms tbody tr:last-child").append(td1);
                        var td2 = $("<td></td>");
                        td2.text("№ " + response[i].Number);
                        $(".rooms tbody tr:last-child").append(td2);
                        var td3 = $("<td></td>");
                        td3.text(response[i].Price+".00 AZN");
                        $(".rooms tbody tr:last-child").append(td3);
                        var td4 = $("<td></td>");
                        td4.text(response[i].PairPersonBedroom + " ədəd");
                        $(".rooms tbody tr:last-child").append(td4);
                        var td5 = $("<td></td>");
                        td5.text(response[i].SinglePersonBedroom + " ədəd");
                        $(".rooms tbody tr:last-child").append(td5);
                        var td6 = $("<td></td>");
                        td6.text(response[i].ChildBedroom + " ədəd");
                        $(".rooms tbody tr:last-child").append(td6);
                        var td7 = $("<td></td>");
                        if (response[i].Status == true) {
                            td7.text("Aktiv");
                            td7.addClass("stat");
                        } else {
                            td7.text("Passiv");
                            td7.addClass("stat text-danger");
                        }
                        $(".rooms tbody tr:last-child").append(td7);
                        var td8 = $("<td></td>");
                        td8.text(response[i].Date+" il");
                        $(".rooms tbody tr:last-child").append(td8);


                        var td9 = $("<td></td>");
                        $(".rooms tbody tr:last-child").append(td9);
                        var a1 = $("<a></a>");
                        a1.text("Düzəliş et");
                        a1.addClass("btn btn-primary btn-sm");
                        a1.attr("href", "/rooms/update/" + response[i].Id);
                        $(".rooms tbody tr:last-child td:last-child").append(a1);

                        var td10 = $("<td></td>");
                        $(".rooms tbody tr:last-child").append(td10);
                        var a2 = $("<a></a>");
                        if (response[i].Status == true) {
                            a2.text("Passivləşdir");
                            a2.addClass("btn activate btn-warning text-white btn-sm");
                        } else {
                            a2.text("Aktivləşdir");
                            a2.addClass("btn activate btn-success text-white btn-sm").parent().siblings(".stat").addClass("text-danger").parent().addClass("table-dark");
                            $(".rooms tbody tr:last-child").addClass("table-dark");
                        }
                        a2.attr("name", "/rooms");
                        a2.attr("value", response[i].Id);
                        $(".rooms tbody tr:last-child td:last-child").append(a2);

                        var td11 = $("<td></td>");
                        $(".rooms tbody tr:last-child").append(td11);
                        var a3 = $("<a></a>");
                        a3.text("Sil");
                        a3.addClass("btn btn-danger text-white btn-sm");
                        a3.attr("name", "/rooms");
                        a3.attr("value", response[i].Id);
                        $(".rooms tbody tr:last-child td:last-child").append(a3);
                    }
                    $(".rooms tbody td").addClass("text-center");

                }),
                error: (function (error) {
                    console.log(error);
                })
            })
        })


        $(document).on("click", ".mytable tbody .btn-danger", function () {
            var id = $(this).attr("value");
            var elem = $(this).parent().parent();
            var name = $(this).attr("name");
            $.ajax({
                url: name + "/delete/" + id,
                type: "get",
                dataType: "json",
                success: (function (response) {
                    elem.fadeOut();
                }),
                error: (function (error) {
                    console.log(error);
                })
            })
        })

        $(document).on("click", ".mytable tbody .activate", function () {
            var id = $(this).attr("value");
            var elem = $(this);
            var name = $(this).attr("name");
            $.ajax({
                url: name + "/activate/" + id,
                type: "get",
                dataType: "json",
                success: (function (response) {
                    if (elem.hasClass("btn-warning")) {
                        elem.removeClass("btn-warning").addClass("btn-success").text("Aktivləşdir").parent().siblings(".stat").addClass("text-danger").text("Passiv").parent().addClass("table-dark");
                    } else {
                        elem.removeClass("btn-success").addClass("btn-warning").text("Passivləşdir").parent().siblings(".stat").removeClass("text-danger").text("Aktiv").parent().removeClass("table-dark");
                    }
                }), error: (function (error) {
                    console.log(error);
                })


            })
        })
        var d = new Date();
        var a = "";
        var b = "";
        if (d.getMonth() < 10) { a = "0" };
        if (d.getDate() < 10) { b = "0" };

        $(".booking .date [min]").attr("value", d.getFullYear() + "-" +a+ (d.getMonth()+1) +"-"+b+ d.getDate());

    });

window.bigbucket = {
    colors: {
        'blue': '#467fcf',
        'blue-darkest': '#0e1929',
        'blue-darker': '#1c3353',
        'blue-dark': '#3866a6',
        'blue-light': '#7ea5dd',
        'blue-lighter': '#c8d9f1',
        'blue-lightest': '#edf2fa',
        'azure': '#45aaf2',
        'azure-darkest': '#0e2230',
        'azure-darker': '#1c4461',
        'azure-dark': '#3788c2',
        'azure-light': '#7dc4f6',
        'azure-lighter': '#c7e6fb',
        'azure-lightest': '#ecf7fe',
        'indigo': '#6574cd',
        'indigo-darkest': '#141729',
        'indigo-darker': '#282e52',
        'indigo-dark': '#515da4',
        'indigo-light': '#939edc',
        'indigo-lighter': '#d1d5f0',
        'indigo-lightest': '#f0f1fa',
        'purple': '#a55eea',
        'purple-darkest': '#21132f',
        'purple-darker': '#42265e',
        'purple-dark': '#844bbb',
        'purple-light': '#c08ef0',
        'purple-lighter': '#e4cff9',
        'purple-lightest': '#f6effd',
        'pink': '#f66d9b',
        'pink-darkest': '#31161f',
        'pink-darker': '#622c3e',
        'pink-dark': '#c5577c',
        'pink-light': '#f999b9',
        'pink-lighter': '#fcd3e1',
        'pink-lightest': '#fef0f5',
        'red': '#e74c3c',
        'red-darkest': '#2e0f0c',
        'red-darker': '#5c1e18',
        'red-dark': '#b93d30',
        'red-light': '#ee8277',
        'red-lighter': '#f8c9c5',
        'red-lightest': '#fdedec',
        'orange': '#fd9644',
        'orange-darkest': '#331e0e',
        'orange-darker': '#653c1b',
        'orange-dark': '#ca7836',
        'orange-light': '#feb67c',
        'orange-lighter': '#fee0c7',
        'orange-lightest': '#fff5ec',
        'yellow': '#f1c40f',
        'yellow-darkest': '#302703',
        'yellow-darker': '#604e06',
        'yellow-dark': '#c19d0c',
        'yellow-light': '#f5d657',
        'yellow-lighter': '#fbedb7',
        'yellow-lightest': '#fef9e7',
        'lime': '#7bd235',
        'lime-darkest': '#192a0b',
        'lime-darker': '#315415',
        'lime-dark': '#62a82a',
        'lime-light': '#a3e072',
        'lime-lighter': '#d7f2c2',
        'lime-lightest': '#f2fbeb',
        'green': '#5eba00',
        'green-darkest': '#132500',
        'green-darker': '#264a00',
        'green-dark': '#4b9500',
        'green-light': '#8ecf4d',
        'green-lighter': '#cfeab3',
        'green-lightest': '#eff8e6',
        'teal': '#2bcbba',
        'teal-darkest': '#092925',
        'teal-darker': '#11514a',
        'teal-dark': '#22a295',
        'teal-light': '#6bdbcf',
        'teal-lighter': '#bfefea',
        'teal-lightest': '#eafaf8',
        'cyan': '#17a2b8',
        'cyan-darkest': '#052025',
        'cyan-darker': '#09414a',
        'cyan-dark': '#128293',
        'cyan-light': '#5dbecd',
        'cyan-lighter': '#b9e3ea',
        'cyan-lightest': '#e8f6f8',
        'gray': '#868e96',
        'gray-darkest': '#1b1c1e',
        'gray-darker': '#36393c',
        'gray-dark': '#6b7278',
        'gray-light': '#aab0b6',
        'gray-lighter': '#dbdde0',
        'gray-lightest': '#f3f4f5',
        'gray-dark': '#343a40',
        'gray-dark-darkest': '#0a0c0d',
        'gray-dark-darker': '#15171a',
        'gray-dark-dark': '#2a2e33',
        'gray-dark-light': '#717579',
        'gray-dark-lighter': '#c2c4c6',
        'gray-dark-lightest': '#ebebec'
    }
};

// Wraptheme Website live
var Tawk_API=Tawk_API||{}, Tawk_LoadStart=new Date();
(function(){
var s1=document.createElement("script"),s0=document.getElementsByTagName("script")[0];
s1.async=true;
s1.src='https://embed.tawk.to/5c6d4867f324050cfe342c69/default';
s1.charset='UTF-8';
s1.setAttribute('crossorigin','*');
//s0.parentNode.insertBefore(s1,s0);
})();
