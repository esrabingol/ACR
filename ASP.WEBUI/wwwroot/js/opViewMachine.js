function redirectTo(url) {
	window.location.href = url;
}

$(document).ready(function () {
	$("#editButton").on("click", function () {
		var selectedMachineId = $("input[name='selectedMachineId']:checked").val();
		if (selectedMachineId) {

			$("input[name='Id']").val(selectedMachineId);
			// Formu submit et
			$("form").submit();
		} else {
			alert("Lütfen bir makine seçin.");
		}
	});
});

$(document).ready(function () {
	$("#deleteButton").on("click", function () {
		var selectedMachineId = $("input[name='selectedMachineId']:checked").val();
		if (selectedMachineId) {

			$("input[name='Id']").val(selectedMachineId);
			// Formu submit et
			$("form").submit();
		} else {
			alert("Lütfen bir makine seçin.");
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