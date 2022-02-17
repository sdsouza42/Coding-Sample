function validateMobile(mobile){
	var str = mobile.value;
	var rx = /\d{10}/;

	if(!rx.test(str)){
		alert("Invalid mobile!");
	}
}
