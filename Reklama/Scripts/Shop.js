$(document).ready(function() {
    var button = $('.uploadLogo'), interval;
    var previousLogo = $('.logoShop').attr('src');
	var shopId = $('#Id').attr('value');
    $.ajax_upload(button, {
        action: '/AjaxServices/UploadShopLogo',
        name: 'myfile',
		data: { logo: previousLogo, id : shopId },
        onSubmit: function (file, ext) {
            // показываем картинку загрузки файла
            $("img#load").attr("src", "/Images/System/loader.gif").attr("class", "visible");

            /*
             * Выключаем кнопку на время загрузки файла
             */
            this.disable();

        },
        onComplete: function (file, response) {
            var resp = JSON.parse(response);

            // убираем картинку загрузки файла
            $("img#load").attr("class", "unvisible");

            // снова включаем кнопку
            this.enable();
            
            if(resp.status == "fail") {
                alert("Возникла ошибка");
            }
            else {
                // показываем что файл загружен
                $('.logoShop').attr('src', '/Images/Catalog/ShopLogos/' + resp.newFilename);
				$('.deleteLogo').removeAttr('style');
            }
        }
    });
	
	$('.deleteLogo').bind('click', function () {
		var logo = $('.logoShop').attr('src');
		$.post(
			"/AjaxServices/RemoveShopLogo",
			{ shopId: shopId, image: logo},
			function (data) {
				if (data.status == 'success') {
					$('.deleteLogo').css('display','none');
					$('.logoShop').attr('src', '/Images/System/no_logo.png');
				}
				else {
					alert('Возникла ошибка при удалении логотипа');
				}
			},
			"json"
		);

		return false;
	});
});