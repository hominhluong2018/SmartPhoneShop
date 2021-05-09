$(function () {
    $('input[name=Quantity]').change(function () {
        var productId = $('#productId').val();
        var quantity = $(this).val();
        var url = "Cart/UpdateCart";
        $.ajax({
            url: url,
            type: "POST",
            dataType: "json",  
            data: { productId: productId, quatity: quantity },
            success: function (response) {
                location.reload();
            }
        });
    });
});