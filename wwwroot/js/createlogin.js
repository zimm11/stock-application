// ****************************************************************************
// Script for createlogin.HTML
// ****************************************************************************

// When the user clicks on the password field, show the message box
function showMessage() {
  document.getElementById("message").style.display = "block";
}

// When the user clicks outside of the password field, hide the message box
function hideMessage() {
  document.getElementById("message").style.display = "none";
}

// Function to validate the user inputted passport
function passwordValidation() {

  var userInput = document.getElementById("Input_Password");
  var letter = document.getElementById("letter");
  var capital = document.getElementById("capital");
  var number = document.getElementById("number");
  var specChar = document.getElementById("specChar");
  var length = document.getElementById("length");

  // Validate capital letters
  var upperCaseLetters = /[A-Z]/g;
  if(userInput.value.match(upperCaseLetters)) {
    capital.classList.remove("invalid");
    capital.classList.add("valid");
  } else {
    capital.classList.remove("valid");
    capital.classList.add("invalid");
  }

  // Validate lowercase letters
  var lowerCaseLetters = /[a-z]/g;
  if(userInput.value.match(lowerCaseLetters)) {
    letter.classList.remove("invalid");
    letter.classList.add("valid");
  } else {
    letter.classList.remove("valid");
    letter.classList.add("invalid");
  }

  // Validate numbers
  var numbers = /[0-9]/g;
  if(userInput.value.match(numbers)) {
    number.classList.remove("invalid");
    number.classList.add("valid");
  } else {
    number.classList.remove("valid");
    number.classList.add("invalid");
  }

  // Validate a special character
  var specialChars = /[@$!%*?&#]/g;
  if(userInput.value.match(specialChars)) {
    specChar.classList.remove("invalid");
    specChar.classList.add("valid");
  } else {
    specChar.classList.remove("valid");
    specChar.classList.add("invalid");
  }
  // Validate length
  if(userInput.value.length >= 10) {
    length.classList.remove("invalid");
    length.classList.add("valid");
  } else {
    length.classList.remove("valid");
    length.classList.add("invalid");
  }

  // Code to test the password strength
  var passwordStrength = {
    0: "Weak",
    1: "Low",
    2: "Good",
    3: "Strong",
    4: "Excellent"
  }

  var password = document.getElementById('Input_Password');
  var description = document.getElementById('password-str-text');

  password.addEventListener('input', function() {
    var val = password.value;
    var result = zxcvbn(val);

    //// Update the password strength meter
    //meter.value = result.score;

    // Update the description indicator
    if (val !== "") {
      description.innerHTML = "Password Strength: " + passwordStrength[result.score];
    } else {
      description.innerHTML = "";
    }
  });
}
