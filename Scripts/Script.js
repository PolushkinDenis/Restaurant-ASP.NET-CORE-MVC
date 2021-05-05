function SubmitForm(Name, Price, Structure, Photo, Vegetarian, Type)
{
    $.ajax(
        {
            method: "POST",
            url: "/Home/Form",
            data: { Name: Name, Price: Price, Structure: Structure, Photo: Photo, Vegetarian: Vegetarian, Type: Type }
        }).fail(function () {
            alert("При передачи данных произошла ошибка");
        }).done(function (context) {
            alert(context);
        });
}