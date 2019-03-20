function isValidEmailAddress(emailAddress) {
  var pattern = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
  return pattern.test(emailAddress);
};


$(document).ready(function () {

  // forces a change of selected item and any events attached to the change
  $('#targetControl').focus();
  $("#targetControl option[value='Commodities']").attr('selected', 'selected');
  $('#targetControl').change();

});