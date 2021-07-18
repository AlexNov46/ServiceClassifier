// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//обработчик нажатия кнопки

jQuery(document).ready(function ($)
{

    $('.button#Start').on('click', function (e)
    {
        //alert('hello');
        Query();
    });
});

//работа с текстом формы
function Query()
{
    var inputText = $("#Input").val();
    var outputBox = document.getElementById('Output');
    var outputText = GetAPIResult(inputText);
    outputBox.innerHTML = outputText;
}

//JSON запрос в API
async function GetAPIResult(inputText)
{
    const url = "/api/Classification/jsonquery/";
    const input = { input: inputText };
    const response = await fetch(url,
        {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            mode: 'cors',
            cache: 'default',
            body: JSON.stringify(input)
        });
    const result = await response.json();
}


