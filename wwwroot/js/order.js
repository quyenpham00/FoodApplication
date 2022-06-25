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

  placeOrder() {
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

