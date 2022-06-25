class Cart {
  constructor(products = []) {
    this.products = products;
  }

  addProduct(product) {
    let quantity = parseInt($("#quantity").val());
    let existProduct = this.products.find(c => c.productId === product.productId);
    if (existProduct) {
      existProduct.quantity = parseInt(existProduct.quantity) + quantity;
    } else {
      product.notes = $("#notes").val();
      product.quantity = quantity;
      this.products.push(product);
    }
    cart.update();
    this.gotoCart();
  }

  getTotalQuantity(cartItems) {
    return cartItems.reduce((count, { quantity }) => count + parseInt(quantity), 0);
  }

  update() {
    $("#cartNumber").text(this.getTotalQuantity(this.products));
    localStorage.setItem("cart", JSON.stringify(this.products));
  }

  gotoCart() {
    $(location).prop('href', '/cart');
  }

  deleteProduct(id) {
    this.products = this.products.filter(data => data.productId != id);
    $("#cartTable tbody #" + id).remove();
    localStorage.setItem("cart", JSON.stringify(this.products));
  }

  renderCartPage() {
    this.products.forEach(function (e, i) {
      $("#cartTable tbody").append(`<tr id="${e.productId}">
                    <td>
                        <div class="w-50 mx-auto">
                            <img src="..${e.imageUrl}"
                                 alt="pizza"
                                 style="max-width: 150px" />
                        </div>
                    </td>
                    <td class="align-middle">
                        <h3 class="m-0">${e.name}</h3>
                    </td>
                    <td class="align-middle">
                        <input type="number" min="1" value="${e.quantity}" />
                    </td>
                    <td class="align-middle"><h3 class="m-0">$${e.price}</h3></td>
                    <td class="align-middle">
                        <i style="cursor:poiter;" onclick="cart.deleteProduct('${e.productId}')" class="fas fa-trash-alt fs-3 ms-2"></i>
                    </td>
                </tr>`);
    })
  }
}

