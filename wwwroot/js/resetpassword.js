// ****************************************************************************
// Script for resetpassword.html
// ****************************************************************************

function optionCheck() {
   if (document.getElementById("radio-email").checked) {
     document.getElementById("row-questions").style.display = "none";
     document.getElementById("row-email").style.display = "block";
   }
   else {
     document.getElementById("row-questions").style.display = "block";
     document.getElementById("row-email").style.display = "none";
   }
}
