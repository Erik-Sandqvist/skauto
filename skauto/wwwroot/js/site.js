// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var num1 = 5;
var num2 = 3;
var num3 = 2;
var result = num1 * num2 * num3;

console.log(result);

var form = document.getElementById('multiplicationForm');
var resultElement = document.getElementById('result');

form.addEventListener('submit', function (event) {
    event.preventDefault(); // Förhindra att formuläret skickas

    var num1 = parseFloat(document.getElementById('num1Input').value);
    var num2 = parseFloat(document.getElementById('num2Input').value);
    var num3 = parseFloat(document.getElementById('num3Input').value);

    var result = num1 * num2 * num3;

    resultElement.textContent = 'Resultat: ' + result;
});