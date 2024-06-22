function redirectTo(url) {
	window.location.href = url;
}



function submitFormWithSelectedReservation() {
    var selectedReservation = document.querySelector('input[name="selectedReservation"]:checked');

    if (!selectedReservation) {
        alert("Lütfen bir randevu seçin.");
        return;
    }
    var reservationId = selectedReservation.value;

    document.getElementById('selectedReservationId').value = reservationId;
    document.getElementById('manageReservationForm').submit();
}



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


