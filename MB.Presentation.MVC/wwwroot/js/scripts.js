(function ($) {

	"use strict";

	var fullHeight = function () {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function () {
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
	});

})(jQuery);


console.log("is start..!")


    const resultTest1 = document.getElementById('test1');
    const resultTest2 = document.getElementById('test2');
    const myForm = document.getElementById('formdata');
    
        resultTest1.addEventListener('click' , (e) => {
    myForm.setAttribute("method","Get")
    console.log("is run..!")
        });


