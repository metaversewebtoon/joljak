// Read the token from a cookie or local storage
var token = document.cookie; // Get cookies
console.log(token);
// var rootPath = window.location.origin;
// console.log(rootPath);
var loginBtn = document.getElementById("loginBtn");
var logoutBtn = document.getElementById("logoutBtn");
var userinfoBtn = document.getElementById("userinfoBtn");

// Use the token to determine if the login was successful or not
if (token.startsWith("token=")) {
  loginBtn.style.display = "none";
  logoutBtn.style.display = "block";
  userinfoBtn.style.display = "block";
} else {
  logoutBtn.style.display = "none";
  loginBtn.style.display = "block";
  userinfoBtn.style.display = "none";
}
