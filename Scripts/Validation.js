function checkName() {
    var name = document.getElementById("name").value;

    if (/^[А-я]+((\-\)?([А-я])+))?$/i.test(name) == true) { }

    else if (/^[а-я]+((\s)?([а-я])(?!(?:.* ))+)*$/.test(name) == true) {

    }
    else {
        document.getElementById("error_name").style.display = 'block'
    }
    if (name == "") {
        document.getElementById("error_name").style.display = 'none'
    }
}
function checkPrice() {
    var name = document.getElementById("price").value;

    if (/^[0-9]+$/.test(name) == true) { }

    else {
        document.getElementById("error_price").style.display = 'block'
    }
    if (name == "") {
        document.getElementById("error_price").style.display = 'none'
    }
}
function checkStructure() {

}
function no_error_name() {
    document.getElementById("error_name").style.display = 'none'
}
function no_error_price() {
    document.getElementById("error_price").style.display = 'none'
}
function no_error_structure() {
    document.getElementById("error_structure").style.display = 'none'
}
