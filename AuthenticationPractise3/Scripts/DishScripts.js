$(document).ready();
function DeleteRow() {
    $(".delete").on("click", function () {
        var tr = $(this).closest('tr');
        tr.remove();
    });
}

function AddDish(ID, dishID, changenumber, restaurantID, singlePrice) {
    var id = "#DishAmount_" + ID;
    var Quantity = $(id).text();
    $(id).text(parseInt(Quantity) + 1);

    var totalPriceId = "#TotalPrice_" + ID;
    var TotalPrice = $(totalPriceId).text();

    $(totalPriceId).text((parseFloat(TotalPrice) + parseFloat(singlePrice)).toFixed(2));

    var OldTotal = $("#Total_All").text();
    var TotalAll = $("#Total_All").text((parseFloat(OldTotal) + parseFloat(singlePrice)).toFixed(2));

    var cartItem = {
        DishID: dishID,
        ChangeNumber: changenumber,
        RestaurantID: restaurantID
    };

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //dataType: "json", // since the method called doesn't return anything, so don't set dataType
        //url: '@Url.Action("UpdateCart", "Customers")', razor engine is not working here
        url: "http://localhost:57450/Customers/UpdateCart",
        data: JSON.stringify(cartItem),
    });
}

function MinDish(ID, dishID, changenumber, restaurantID, singlePrice) {
    var id = "#DishAmount_" + ID;
    var Quantity = $(id).text();

    var totalPriceId = "#TotalPrice_" + ID;
    var TotalPrice = $(totalPriceId).text();


    if (Quantity > 1) {
        $(id).text(parseInt(Quantity) - 1);
        $(totalPriceId).text((parseFloat(TotalPrice) - parseFloat(singlePrice)).toFixed(2));
    }
    else {
        var rowId = "#cartItem_" + ID;
        var tr = $(rowId).closest('tr');
        tr.remove();
    }

    var OldTotal = $("#Total_All").text();
    var TotalAll = $("#Total_All").text((parseFloat(OldTotal) - parseFloat(singlePrice)).toFixed(2));

    var cartItem = {
        DishID: dishID,
        ChangeNumber: changenumber,
        RestaurantID: restaurantID
    }

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //dataType: "json", // since the method called doesn't return anything, so don't set dataType
        url: "http://localhost:57450/Customers/UpdateCart",
        data: JSON.stringify(cartItem),
    });
}

function CancelDish(ID, dishID, changenumber, restaurantID) {
    var id = "#DishAmount_" + ID;
    var Quantity = $(id).text();

    var totalPriceId = "#TotalPrice_" + ID;
    var TotalPrice = $(totalPriceId).text();

    var rowId = "#cartItem_" + ID;
    var tr = $(rowId).closest('tr');
    tr.remove();

    var cartItem = {
        DishID: dishID,
        ChangeNumber: changenumber,
        RestaurantID: restaurantID
    }

    var OldTotal = $("#Total_All").text();
    var TotalAll = $("#Total_All").text((parseFloat(OldTotal) - parseFloat(TotalPrice)).toFixed(2));

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //dataType: "json", // since the method called doesn't return anything, so don't set dataType
        url: "http://localhost:57450/Customers/UpdateCart",
        data: JSON.stringify(cartItem),
    });
}