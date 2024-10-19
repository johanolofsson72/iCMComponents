function ChangeFontStyle(obj){
	if(obj != '')
	getIFrameDocument("ContentView").execCommand('fontname', false, obj);
}

function ChangeFontSize(obj){
	if(obj != '')
	getIFrameDocument("ContentView").execCommand('fontsize', false, obj);
}

function ChangeFontHead(obj){
	if(obj != ''){
		getIFrameDocument("ContentView").execCommand('formatblock', false, obj);  
		ChangeFontStyle(FontStyle.options[FontStyle.selectedIndex].value);
	}
}
