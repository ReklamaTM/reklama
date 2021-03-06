$(document).ready(function () {
	
	$('#CategoryId').change(function () {
        var categoryId = $.attr(this, 'value');
		var shopId = $('#ShopId').val();
        var url = "/AjaxServices/GetSecondCategories";

        $.post(
            url,
            { shopId: shopId, categoryId: categoryId },
            function (data) {
                $.fn.loadSecondCategoryBox(data);
				var selectSecondCategoryId = data[0].Id;
				$.post(
					"/AjaxServices/GetThirdCategories",
					{ secondCategoryId: selectSecondCategoryId },
					function (data) {
						$.fn.loadThirdCategoryBox(data);
					}
				);
            }
        );
    });
	
	$('#SecondCategoryId').change(function() {
		var secondCategoryId = $.attr(this, 'value');
		
		$.post(
			"/AjaxServices/GetThirdCategories",
			{ secondCategoryId: secondCategoryId },
			function (data) {
				$.fn.loadThirdCategoryBox(data);
			}
		);
	});
	
    $.fn.loadSecondCategoryBox = function (data) {
        $("#SecondCategoryId").html("");

        if (data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                $("#SecondCategoryId").append("<option value='" + data[i].Id + "'>" + data[i].Name + "</option>");
            }
        }
    };
	
	$.fn.loadThirdCategoryBox = function (data) {		
		$(".persProdSection").html("");
		if (data.length > 0) {
			$(".persProdSection").append('<span>Производитель:</span> <select id="ThirdCategoryId" name="ThirdCategoryId">');
			$("#ThirdCategoryId").html("");
			for(var i = 0; i < data.length; i++) {
				$("#ThirdCategoryId").append("<option value='" + data[i].Id + "'>" + data[i].Name + "</option>");
			}
			$(".persProdSection").append('</select>');
		}
	};
	
	
	$('.changeButton').bind('click', function() {
		var id = $(this).attr('Id');
		var price = $(this).parent().parent().children('.ppInfo').children('input').val();
		
		$.post(
		"/AjaxServices/UpdateShopProduct",
		{ id : id, price: price },
		function (data) {
			if(data.status == 'success') {
				alert('Цена успешно изменена');
			}
			else {
				alert('Возникла ошибка при измении цены товара');
			}
		},
		"json"
		);
	});
	
 	$('.removeButton').bind('click', function() { 
		var _confirm = confirm('Удалить товар?');
		if(_confirm)
		{
			document.location.href = $(this).attr('href');
		}
	}); 
});