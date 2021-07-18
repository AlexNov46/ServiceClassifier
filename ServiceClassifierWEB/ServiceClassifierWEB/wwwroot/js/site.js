
//обработчик нажатия кнопки
jQuery(document).ready(async function ($)
{

    $('.button#Start').on('click', async function (e)
    {
        await Query();
    });
});

//работа с текстом формы
async function Query()
{
    var inputText = $("#Input").val();
    var outputBox = document.getElementById('Output');
    outputBox.innerHTML = "...";
    var outputText = await GetAPIResult(inputText);
    outputBox.innerHTML = outputText;
}


//JSON запрос в API
async function GetAPIResult(inputText)
{
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var raw = JSON.stringify({
        "Input": inputText
    });

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    var url = "api/classification/jsonquery";

    var response = await fetch(url, requestOptions);
    var output = await response.json();
    var result = output.output;

    return output.output;
}


