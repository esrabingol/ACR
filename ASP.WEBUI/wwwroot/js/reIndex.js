function redirectTo(url) {
	window.location.href = url;
}

function submitFormForCancellation() {
	var selectedReservation = document.querySelector('input[name="selectedReservationId"]:checked');

	if (!selectedReservation) {
		alert("Lütfen bir randevu seçin.");
		return;
	}
	var reservationId = selectedReservation.value;

	var form = document.getElementById('cancelReservationForm');
	form.action = '/Requester/ReCanceledReservation';

	var hiddenInput = document.getElementById('cancelReservationId');
	hiddenInput.value = reservationId;

	form.submit();
}
function submitFormWithSelectedReservation() {

	var selectedReservation = document.querySelector('input[name="selectedReservationId"]:checked');

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


