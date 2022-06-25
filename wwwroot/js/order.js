class Order {
    constructor(p) {
    }

    renderOrder(products) {
        products.forEach(function (e, i) {
            $("#tableOrder tbody").append(`<tr>
                                <td>
                                    <div class="w-50 mx-auto">
                                        <img src="${e.imageUrl}"
                                             alt="pizza"
                                             style="max-width: 150px" />
                                    </div>
                                </td>
                                <td>
                                    <p>${e.name}</p>
                                </td>
                                <td>
                                    <p>${e.quantity}</p>
                                </td>
                                <td><p>${e.price}</p></td>

                            </tr>`);
        })
    }

    calculate(cartItems) {
        return cartItems.reduce((count, { quantity, price }) => count + parseInt(quantity) * price, 0);
    }



    validatePhone = (txtPhone) => {
        var filter = /^((\+[1-9]{1,4}[ \-]*)|(\([0-9]{2,3}\)[ \-]*)|([0-9]{2,4})[ \-]*)*?[0-9]{3,4}?[ \-]*[0-9]{3,4}?$/;
        if (filter.test(txtPhone)) {
            return true;
        }
        else {
            return false;
        }
    }

    validate = () => {
        let errorMessage = "";
        if ($("#address").val() == "") {
            errorMessage = "Customer Address is required.";
        }
        if ($("#phoneNumber").val() == "") {
            errorMessage = "Phone Number is required.";
        } else {
            if (!this.validatePhone($("#phoneNumber").val())) {
                errorMessage = "Phone Number is invalid.";
                $("#validateMessage").text(errorMessage);
                $("#validateMessageContainer").show();
                return errorMessage;
            }
        }
        if ($("#customerName").val() == "") {
            errorMessage = "Customer Name is required.";
        }

        $("#validateMessage").text(errorMessage);
        $("#validateMessageContainer").show();
        return errorMessage;
    }

    placeOrder() {
        debugger
        if (this.validate() != "") {
            return;
        }
        let data = {
            customerName: $("#customerName").val(),
            customerAddress: $("#address").val(),
            phoneNumber: $("#phoneNumber").val(),
            notes: $("#orderNote").val(),
            quantity: cart.getTotalQuantity(cart.products),
            discount: discount,
            products: cart.products,
            totalPrice: this.calculate(cart.products)
        };

        var settings = {
            "async": true,
            "url": "/order/PlaceOrder",
            "method": "POST",
            "headers": {
                "content-type": "application/json",
                "cache-control": "no-cache",
            },
            "processData": false,
            "data": JSON.stringify(data)
        }
        $.ajax(settings).done(function (response) {
            if (response.status) {
                localStorage.removeItem("cart");
                $(location).prop('href', '/order/orderhistory');
            } else {
                $(location).prop('href', '/Identity/Account/Register');
            }
        });
    }
}

