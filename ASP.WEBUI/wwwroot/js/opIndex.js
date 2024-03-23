function redirectTo(url) {
	window.location.href = url;
}

$(document).ready(function () {
	$("#updateButton").on("click", function () {
		var selectedReservationId = $("input[name='selectedReservationId']:checked").val();
		if (selectedReservationId) {

			$("input[name='Id']").val(selectedReservationId);
			// Formu submit et
			$("form").submit();
		} else {
			alert("Lütfen bir randevu seçin.");
		}
	});
});

function clearFiltersAndResults() {
	$('input[type=text]').val('');
	$('input[type=number]').val('');
	$('select').val('');

	$('table tbody').empty();
}
$(document).ready(function () {
	$("#clearButton").on("click", function () {
		clearFiltersAndResults();
	});
});





