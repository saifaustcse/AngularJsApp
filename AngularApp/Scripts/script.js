var listBox = document.querySelector('.contact-body.box-right');
var formBox = document.querySelector('.contact-body.box-left');
var allContacts = document.querySelectorAll('.list-group-item');
function toggleExc(strClassName, item1, item2){
	var strRegExPattern = '(?:^|\\s)'+strClassName+'(?!\\S)';
	if ( item1.className.match(new RegExp(strRegExPattern,'g')) ){
		item1.className = item1.className.replace( new RegExp(strRegExPattern,'g') , '' )
		item2.className += " " + strClassName;
	}
	else{
		item2.className = item2.className.replace( new RegExp(strRegExPattern,'g') , '' )
		item1.className += " " + strClassName;
	}
}
function changeClasses() {
	toggleExc('visible', listBox, formBox);
}
function toggleClass() {
	var input = document.querySelectorAll('.data-input');
	var view = document.querySelectorAll('.data-read');
	for (var i = 0; i < input.length; i++){
		toggleExc('hide', input[i], view[i]);
	}
}
for (var i = 0; i < allContacts.length; i++){
	allContacts[i].onclick = changeClasses;
}