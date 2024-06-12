function redirectTo(url) {
	window.location.href = url;
}

function submitFormForCancellationAdmin() {
	var selectedReservation = document.querySelector('input[name="selectedReservationId"]:checked');

	if (!selectedReservation) {
		alert("Lütfen bir randevu seçin.");
		return;
	}
	var reservationId = selectedReservation.value;

	var form = document.getElementById('canceledReservationFormAdmin');
	form.action = '/Admin/AdCanceledReservation';

	var hiddenInput = document.getElementById('selectedReservationId');
	hiddenInput.value = reservationId;

	form.submit();
}
function submitFormWithSelectedReservationAdmin() {

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


