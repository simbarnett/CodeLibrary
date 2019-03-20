
function handleSubmit(event) {



	var targetUrl           = "http://localhost/CodeLibrary/CodeLibraryMVC/home/PostEmailPreferences";		
	var emailValue          = $('input[name=X6522_388844pi_6522_388844]').val();	
	var chinaValue          = $('input[name=X6522_388846pi_6522_388846]:checked').val();	
	var environSocGovValue  = $('input[name=X6522_388848pi_6522_388848]:checked').val();
	var equityValue         = $('input[name=X6522_388850pi_6522_388850]:checked').val();
	var fixedIncomeValue    = $('input[name=X6522_388852pi_6522_388852]:checked').val();
	var realEstateValue     = $('input[name=X6522_388854pi_6522_388854]:checked').val();
	var smartBetaValue      = $('input[name=X6522_388856pi_6522_388856]:checked').val();
	var etpValue            = $('input[name=X6522_388858pi_6522_388858]:checked').val();
	var smallCapPerspValue  = $('input[name=X6522_392646pi_6522_392646]:checked').val();
	var chinaFixedIncValue  = $('input[name=X6522_392648pi_6522_392648]:checked').val();
	var submitForm			= false;

	var blah = {
		"emailPreferencesFormData": {
			"emailField"        : emailValue         + '#6522_388844pi_6522_388844',
			"chinaField"        : chinaValue         + '#6522_388846pi_6522_388846[]',
			"environSocGovField": environSocGovValue + '#6522_388848pi_6522_388848[]',
			"equityField"       : equityValue        + '#6522_388850pi_6522_388850[]',
			"fixedIncomeField"  : fixedIncomeValue   + '#6522_388852pi_6522_388852[]',
			"realEstateField"   : realEstateValue    + '#6522_388854pi_6522_388854[]',
			"smartBetaField"    : smartBetaValue     + '#6522_388856pi_6522_388856[]',
			"etpField"          : etpValue           + '#6522_388858pi_6522_388858[]',
			"smallCapPerspField": smallCapPerspValue + '#6522_392646pi_6522_392646[]',
			"chinaFixedIncField": chinaFixedIncValue + '#6522_392648pi_6522_392648[]',
		}
	}

	//var blah = {
	//	"emailPreferencesFormData": {
	//		"X6522_388844pi_6522_388844": emailValue,
	//		"X6522_388846pi_6522_388846": chinaValue,
	//		"X6522_388848pi_6522_388848": environSocGovValue,
	//		"X6522_388850pi_6522_388850": equityValue,
	//		"X6522_388852pi_6522_388852": fixedIncomeValue,
	//		"X6522_388854pi_6522_388854": realEstateValue,
	//		"X6522_388856pi_6522_388856": smartBetaValue,
	//		"X6522_388858pi_6522_388858": etpValue,
	//		"X6522_392646pi_6522_392646": smallCapPerspValue,
	//		"X6522_392648pi_6522_392648": chinaFixedIncValue,
	//	}
	//}
		
	
	$.ajax({
		url: targetUrl,
		//contentType: 'application/json',
		type: 'post',
		data: blah //$('#testSubmit').serialize()
		//success: function () {
		//	console.log('registrationPreferencesForm submission: success');
		//}
	});
	

	//event.preventDefault();
}


//$('#testSubmit').submit(function (event) {

//	console.log(64644);


//});