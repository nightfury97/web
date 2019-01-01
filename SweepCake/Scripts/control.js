$('.buy a').click(function () {
    buyItem(this);
});


/* Remove item from cart */
function buyItem(buyButton) {
    /* Remove row from DOM and recalc cart total */
    var cake_id = $(buyButton).data('id');


        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (xhttp.readyState == 4 && xhttp.status == 200) {
                document.getElementById("demo").innerHTML = xhttp.responseText;
            }
        };
    xhttp.open("POST", "/AddCake?productId=" + cake_id +"&quantity=1", true);
        xhttp.send();
    });
}