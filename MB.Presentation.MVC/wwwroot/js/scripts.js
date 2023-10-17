//(function ($) {

//	"use strict";

//	var fullHeight = function () {

//		$('.js-fullheight').css('height', $(window).height());
//		$(window).resize(function () {
//			$('.js-fullheight').css('height', $(window).height());
//		});

//	};
//fullHeight();

$("#sidebarCollapse").on("click",
    function() {
        $("#sidebar").toggleClass("active");
    });

//})(jQuery);


//console.log("is start..!")


const resultTest1 = document.getElementById("test1");
const resultTest2 = document.getElementById("test2");
const myForm = document.getElementById("formdata");

if (resultTest1 && resultTest2 && myForm) {
    resultTest1.addEventListener("click",
        (e) => {
            myForm.setAttribute("method", "Get");
            console.log("is run..!");
        });
}

const button = document.getElementById("votebtn");
const number = document.getElementById("votenumber");
button.addEventListener("click",
    function() {
        console.log("is start..!")
        number.innerHTML++
    });


// script.js

//document.addEventListener("DOMContentLoaded", function () {
//    const commentForm = document.getElementById("comment-form");
//    const commentsContainer = document.getElementById("comments");

//    commentForm.addEventListener("submit", function (e) {
//        e.preventDefault();

//        const nameInput = document.getElementById("name");
//        const commentInput = document.getElementById("comment-text");

//        const name = nameInput.value;
//        const commentText = commentInput.value;

//        if (name && commentText) {
//            // Create a new comment element
//            const comment = document.createElement("div");
//            comment.className = "comment";
//            comment.innerHTML = `
//                <h3>${name}</h3>
//                <p>${commentText}</p>
//            `;

//            // Append the comment to the comments container
//            commentsContainer.appendChild(comment);

//            // Clear the form fields
//            nameInput.value = "";
//            commentInput.value = "";
//        }
//    });
//});